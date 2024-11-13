using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UBhashini.Data.Compute
{
    /// <summary>
    /// Response data for a computed task result.
    /// </summary>
    public class BhashiniComputeResponseData
    {
        /// <summary>
        /// The task type.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-compute-call/response-payload"/>
        /// </remarks>
        [JsonProperty("taskType")]
        public BhashiniPipelineTaskType TaskType;

        /// <summary>
        /// The configuration of the task's result. Can be <see langword="null"/> for translation tasks.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-compute-call/response-payload"/>
        /// </remarks>
        [JsonProperty("config")]
        public BhashiniComputeResponseConfiguration TaskConfiguration;

        /// <summary>
        /// Text outputs for STT and translation tasks.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-compute-call/response-payload"/>
        /// </remarks>
        [JsonProperty("output")]
        public BhashiniTextOutput[] TextOutputs;

        /// <summary>
        /// Audio output for TTS tasks.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-compute-call/response-payload"/>
        /// </remarks>
        [JsonProperty("audio")]
        public BhashiniAudioOutput[] AudioOutputs;
    }
}
