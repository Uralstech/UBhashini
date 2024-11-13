using Newtonsoft.Json;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Uralstech.UBhashini.Data.Compute;
using Uralstech.UBhashini.Data.Pipeline;
using Uralstech.UBhashini.Exceptions;
using Uralstech.Utils.Singleton;

namespace Uralstech.UBhashini
{
    /// <summary>
    /// The script for managing all interactions with the Bhashini ULCA API.
    /// </summary>
    [AddComponentMenu("Uralstech/UBhashini/Bhashini Manager")]
    public class BhashiniManager : Singleton<BhashiniManager>
    {
        /// <summary>
        /// Header for the User ID in pipeline config requests.
        /// </summary>
        private const string AuthUserIdHeader = "userId";

        /// <summary>
        /// Header for the API key in pipeline config requests.
        /// </summary>
        private const string AuthUlcaApiKeyHeader = "ulcaApiKey";

        /// <summary>
        /// The pipeline configuration API endpoint.
        /// </summary>
        [Tooltip("The pipeline configuration API endpoint.")]
        public string PipelineConfigurationEndpoint = "https://meity-auth.ulcacontrib.org/ulca/apis/v0/model/getModelsPipeline";

        /// <summary>
        /// The ID of the pipeline provider to use.
        /// </summary>
        [Tooltip("The ID of the pipeline search service to use. Defaults to MeitY service.")]
        public string PipelineProvider = "64392f96daac500b55c543cd";

        /// <summary>
        /// The ULCA account's user ID.
        /// </summary>
        [Tooltip("Your ULCA account's user ID.")]
        [SerializeField] private string _ulcaUserId;

        /// <summary>
        /// The ULCA API key.
        /// </summary>
        [Tooltip("Your ULCA API key.")]
        [SerializeField] private string _ulcaApiKey;

        /// <summary>
        /// Sets the user ID and API key.
        /// </summary>
        /// <param name="ulcaUserId">The new user ID.</param>
        /// <param name="ulcaApiKey">The new API key.</param>
        public void SetDetails(string ulcaUserId, string ulcaApiKey)
        {
            _ulcaUserId = ulcaUserId;
            _ulcaApiKey = ulcaApiKey;
        }

        /// <summary>
        /// Configures a pipeline for the given tasks for computation.
        /// </summary>
        /// <param name="tasks">The pipeline tasks.</param>
        /// <returns>The configuration response if successful and <see langword="null"/> otherwise.</returns>
        public async Task<BhashiniPipelineResponse> ConfigurePipeline(params BhashiniPipelineRequestTask[] tasks)
        {
            BhashiniPipelineRequest request = new()
            {
                Tasks = tasks,
                Configuration = new()
                {
                    ProviderId = PipelineProvider,
                },
            };

            Debug.Log("Starting pipeline configuration...");

            string requestJson = JsonConvert.SerializeObject(request);
            using UnityWebRequest webRequest = UnityWebRequest.Post(PipelineConfigurationEndpoint, requestJson, "application/json");

            webRequest.SetRequestHeader(AuthUserIdHeader, _ulcaUserId);
            webRequest.SetRequestHeader(AuthUlcaApiKeyHeader, _ulcaApiKey);

            UnityWebRequestAsyncOperation operation = webRequest.SendWebRequest();
            while (!operation.isDone)
                await Task.Yield();

            if (webRequest.result is not UnityWebRequest.Result.Success)
            {
                Debug.LogError($"Failed {nameof(ConfigurePipeline)} request: {webRequest.error} | {webRequest.downloadHandler.text}");
                return null;
            }

            BhashiniPipelineResponse response = JsonConvert.DeserializeObject<BhashiniPipelineResponse>(webRequest.downloadHandler.text);
            if (response is null)
            {
                Debug.LogError($"Failed {nameof(ConfigurePipeline)} request: Could not deserialize \"{webRequest.downloadHandler.text}\"");
                return null;
            }

            Debug.Log("Pipeline configuration completed.");
            return response;
        }

        /// <summary>
        /// Runs the given computation tasks on a pipeline.
        /// </summary>
        /// <remarks>
        /// Provide audio data through <paramref name="rawBase64AudioSource"/>, not <paramref name="audioSource"/> if you are using any audio other than <see cref="BhashiniAudioFormat.Wav"/>* or <see cref="BhashiniAudioFormat.Pcm"/>**.
        /// <br/>
        /// <br/>
        /// *<see href="https://openupm.com/packages/com.utilities.encoder.wav/">Utilities.Encoding.Wav</see> and <see href="https://openupm.com/packages/com.utilities.audio/">Utilities.Audio</see> are required.
        /// <br/>
        /// **<see href="https://openupm.com/packages/com.utilities.audio/">Utilities.Audio</see> is required.
        /// </remarks>
        /// <param name="inferenceEndpoint">The pipeline's inference endpoint.</param>
        /// <param name="input">Input data for the computation.</param>
        /// <param name="tasks">The tasks to run on the pipeline.</param>
        /// <returns>The computation response if successful and <see langword="null"/> otherwise.</returns>
        /// <exception cref="BhashiniAudioIOException">Thrown when an unsupported audio encoding is encountered.</exception>
        public async Task<BhashiniComputeResponse> ComputeOnPipeline(BhashiniPipelineInferenceEndpoint inferenceEndpoint, BhashiniInputData input, params BhashiniComputeTask[] tasks)
        {
            BhashiniComputeRequest request = new()
            {
                Tasks = tasks,
                Input = input,
            };

            Debug.Log("Starting pipeline computation...");

            string requestJson = JsonConvert.SerializeObject(request);
            using UnityWebRequest webRequest = UnityWebRequest.Post(inferenceEndpoint.CallbackUrl, requestJson, "application/json");

            webRequest.SetRequestHeader(inferenceEndpoint.ApiKey.Header, inferenceEndpoint.ApiKey.Token);

            UnityWebRequestAsyncOperation operation = webRequest.SendWebRequest();
            while (!operation.isDone)
                await Task.Yield();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"Failed {nameof(ComputeOnPipeline)} request: {webRequest.error} | {webRequest.downloadHandler.text}");
                return null;
            }

            BhashiniComputeResponse response = JsonConvert.DeserializeObject<BhashiniComputeResponse>(webRequest.downloadHandler.text);
            if (response is null)
            {
                Debug.LogError($"Failed {nameof(ComputeOnPipeline)} request: Could not deserialize \"{webRequest.downloadHandler.text}\"");
                return null;
            }

            Debug.Log("Pipeline computation completed!");
            return response;
        }
    }
}
