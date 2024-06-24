using Newtonsoft.Json;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Uralstech.UBhashini.Utils.Singleton;
using Uralstech.UBhashini.Data;
using System;
using Uralstech.UBhashini.Exceptions;

#if UTILITIES_ENCODING_WAV_1_0_0_OR_GREATER && UTILITIES_AUDIO_1_0_0_OR_GREATER
using Utilities.Encoding.Wav;
using Utilities.Audio;
#elif UTILITIES_AUDIO_1_0_0_OR_GREATER
using Utilities.Audio;
#endif

namespace Uralstech.UBhashini
{
    /// <summary>
    /// The script for managing all interactions with the Bhashini ULCA API.
    /// </summary>
    [AddComponentMenu("Uralstech/UBhashini/Bhashini API Manager")]
    public class BhashiniApiManager : Singleton<BhashiniApiManager>
    {
        /// <summary>
        /// JSON serializer for data. (DefaultValueHandling = true)
        /// </summary>
        private static readonly JsonSerializerSettings s_jsonSerializerSettings = new()
        {
            DefaultValueHandling = DefaultValueHandling.Ignore,
        };

        /// <summary>
        /// The pipeline configuration API endpoint.
        /// </summary>
        [Tooltip("The pipeline configuration API endpoint.")]
        public string PipelineConfigurationEndpoint = "https://meity-auth.ulcacontrib.org/ulca/apis/v0/model/getModelsPipeline";

        /// <summary>
        /// The ID of the pipeline search service to use.
        /// </summary>
        [Tooltip("The ID of the pipeline search service to use. Defaults to MeitY service.")]
        public string PipelineId = "64392f96daac500b55c543cd";

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
        public async Task<BhashiniPipelineConfigResponse> ConfigurePipeline(BhashiniPipelineTask[] tasks)
        {
            BhashiniRequest request = new()
            {
                PipelineTasks = tasks,

                PipelineRequestConfig = new()
                {
                    PipelineId = PipelineId,
                },
            };

            Debug.Log("Starting pipeline configuration...");

            string requestJson = JsonConvert.SerializeObject(request, s_jsonSerializerSettings);
            using UnityWebRequest webRequest = UnityWebRequest.Post(PipelineConfigurationEndpoint, requestJson, "application/json");

            webRequest.SetRequestHeader("userId", _ulcaUserId);
            webRequest.SetRequestHeader("ulcaApiKey", _ulcaApiKey);

            UnityWebRequestAsyncOperation operation = webRequest.SendWebRequest();
            while (!operation.isDone)
                await Task.Yield();

            if (webRequest.result is not UnityWebRequest.Result.Success)
            {
                Debug.LogError($"Failed {nameof(ConfigurePipeline)} request: {webRequest.error} | {webRequest.downloadHandler.text}");
                return null;
            }

            BhashiniPipelineConfigResponse response = JsonConvert.DeserializeObject<BhashiniPipelineConfigResponse>(webRequest.downloadHandler.text);
            if (response is null)
            {
                Debug.LogError($"Failed {nameof(ConfigurePipeline)} request: Could not deserialize \"{webRequest.downloadHandler.text}\"");
                return null;
            }

            Debug.Log("Pipeline configuration completed.");
            return response;
        }

        /// <summary>
        /// Encodes the given <see cref="AudioClip"/> to *WAV or **PCM base64.
        /// </summary>
        /// <remarks>
        /// *<see href="https://openupm.com/packages/com.utilities.encoder.wav/">Utilities.Encoding.Wav</see> and <see href="https://openupm.com/packages/com.utilities.audio/">Utilities.Audio</see> are required.
        /// <br/>
        /// **<see href="https://openupm.com/packages/com.utilities.audio/">Utilities.Audio</see> is required.
        /// </remarks>
        /// <param name="clip">The clip to encode.</param>
        /// <param name="tasks">The tasks which specify the required audio format.</param>
        /// <returns>The encoding string, or <see langword="null"/> if the task was not found.</returns>
        /// <exception cref="BhashiniAudioIOException">Thrown when an unsupported audio encoding is encountered.</exception>
        private async Task<string> GetBase64Audio(AudioClip clip, BhashiniPipelineTask[] tasks)
        {
            int taskIndex = Array.FindIndex(tasks, task => task.TaskType == BhashiniPipelineTaskType.SpeechToText);
            if (taskIndex < 0)
                return null;

            BhashiniPipelineTask task = tasks[taskIndex];
            return task.Config.AudioFormat switch
            {
#if UTILITIES_ENCODING_WAV_1_0_0_OR_GREATER && UTILITIES_AUDIO_1_0_0_OR_GREATER
                BhashiniAudioFormat.Wav => Convert.ToBase64String(await clip.EncodeToWavAsync()),
#endif

#if UTILITIES_AUDIO_1_0_0_OR_GREATER
                BhashiniAudioFormat.Pcm => Convert.ToBase64String(clip.EncodeToPCM()),
#endif

                _ => throw new BhashiniAudioIOException($"Format not supported in operation!", task.Config.AudioFormat)
            };
        }

        /// <summary>
        /// Runs the given computation tasks on a pipeline.
        /// </summary>
        /// <remarks>
        /// Provide audio data through <paramref name="rawBase64AudioSource"/>, not <paramref name="audioSource"/> if you are using any audio other than *<see cref="BhashiniAudioFormat.Wav"/> or **<see cref="BhashiniAudioFormat.Pcm"/>.
        /// <br/>
        /// <br/>
        /// *<see href="https://openupm.com/packages/com.utilities.encoder.wav/">Utilities.Encoding.Wav</see> and <see href="https://openupm.com/packages/com.utilities.audio/">Utilities.Audio</see> are required.
        /// <br/>
        /// **<see href="https://openupm.com/packages/com.utilities.audio/">Utilities.Audio</see> is required.
        /// </remarks>
        /// <param name="inferenceData">The pipeline's inference data.</param>
        /// <param name="tasks">The tasks to run on the pipeline.</param>
        /// <param name="textSource">The text input for the computation (ONLY for text to speech and translate input).</param>
        /// <param name="audioSource">The audio input for the computation (ONLY for speech to text input).</param>
        /// <param name="rawBase64AudioSource">The audio input for the computation (ONLY for speech to text input).</param>
        /// <returns>The computation response if successful and <see langword="null"/> otherwise.</returns>
        /// <exception cref="BhashiniAudioIOException">Thrown when an unsupported audio encoding is encountered.</exception>
        public async Task<BhashiniComputeResponse> ComputeOnPipeline(BhashiniPipelineInferenceData inferenceData,
            BhashiniPipelineTask[] tasks, string textSource = null, AudioClip audioSource = null, string rawBase64AudioSource = null)
        {
            if (textSource is null && rawBase64AudioSource is null && audioSource == null)
            {
                Debug.LogError($"{nameof(textSource)}, {nameof(rawBase64AudioSource)} and {nameof(audioSource)} cannot all be null!");
                return null;
            }

            BhashiniRequest request = new()
            {
                PipelineTasks = tasks,
                InputData = new()
                {
                    Text = textSource is not null ? new[]
                    {
                        new BhashiniTextSource()
                        {
                            Source = textSource,
                        }
                    } : null,
                    Audio = (rawBase64AudioSource is not null || audioSource != null) ? new[]
                    {
                        new BhashiniAudioSource()
                        {
                            AudioContent = audioSource != null
                                            ? await GetBase64Audio(audioSource, tasks)
                                            : rawBase64AudioSource,
                        }
                    } : null,
                }
            };

            string requestJson = JsonConvert.SerializeObject(request, s_jsonSerializerSettings);
            Debug.Log($"Computation request: {requestJson}");

            using UnityWebRequest webRequest = UnityWebRequest.Post(inferenceData.CallbackUrl, requestJson, "application/json");

            webRequest.SetRequestHeader(inferenceData.InferenceApiKey.Name, inferenceData.InferenceApiKey.Value);

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

            Debug.Log($"Pipeline computation completed: {webRequest.downloadHandler.text}");
            return response;
        }
    }
}
