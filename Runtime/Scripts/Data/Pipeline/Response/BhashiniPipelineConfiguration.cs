using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UBhashini.Data.Pipeline
{
    /// <summary>
    /// A list of supported pipeline configurations for a task.
    /// </summary>
    public class BhashiniPipelineConfiguration
    {
        /// <summary>
        /// The type of the task.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-config-call/response-payload"/>
        /// </remarks>
        [JsonProperty("taskType")]
        public BhashiniPipelineTaskType Type;

        /// <summary>
        /// The supported configurations.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-config-call/response-payload"/>
        /// </remarks>
        [JsonProperty("config")]
        public BhashiniPipelineTaskConfiguration[] Configurations;
    }
}
