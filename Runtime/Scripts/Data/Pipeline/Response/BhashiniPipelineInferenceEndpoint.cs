using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UBhashini.Data.Pipeline
{
    /// <summary>
    /// Endpoint for inferencing a pipeline.
    /// </summary>
    public class BhashiniPipelineInferenceEndpoint
    {
        /// <summary>
        /// The URI to call back to for inference.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-config-call/response-payload"/>
        /// </remarks>
        [JsonProperty("callbackUrl")]
        public string CallbackUrl;

        /// <summary>
        /// The API key (Header, Token) for authenticating with the API.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-config-call/response-payload"/>
        /// </remarks>
        [JsonProperty("inferenceApiKey")]
        public BhashiniPipelineInferenceKey ApiKey;

        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-config-call/response-payload"/>
        /// </remarks>
        [JsonProperty("isMultilingualEnabled")]
        public bool IsMultilingual;

        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-config-call/response-payload"/>
        /// </remarks>
        [JsonProperty("isSyncApi")]
        public bool IsSynchronous;
    }
}
