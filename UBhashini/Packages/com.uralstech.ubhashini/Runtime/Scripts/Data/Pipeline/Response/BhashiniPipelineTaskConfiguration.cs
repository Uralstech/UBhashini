using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UBhashini.Data.Pipeline
{
    /// <summary>
    /// A configuration for a pipeline's task.
    /// </summary>
    public class BhashiniPipelineTaskConfiguration
    {
        /// <summary>
        /// The service providing this task configuration.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-config-call/response-payload"/>
        /// </remarks>
        [JsonProperty("serviceId")]
        public string ServiceId;

        /// <summary>
        /// The model which will perform the task.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-config-call/response-payload"/>
        /// </remarks>
        [JsonProperty("modelId")]
        public string ModelId;

        /// <summary>
        /// The languages supported for the task.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-config-call/response-payload"/>
        /// </remarks>
        [JsonProperty("language")]
        public BhashiniLanguageData Language;

        /// <summary>
        /// Only for TTS tasks. The voice types the model supports.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-config-call/response-payload"/>
        /// </remarks>
        [JsonProperty("supportedVoices")]
        public BhashiniVoiceType[] SupportedVoices;

        /// <summary>
        /// Only for STT tasks. The domain the model is trained for, like "agricultural", "medical", etc.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-config-call/response-payload"/>
        /// </remarks>
        [JsonProperty("domain")]
        public string[] Domains;
    }
}
