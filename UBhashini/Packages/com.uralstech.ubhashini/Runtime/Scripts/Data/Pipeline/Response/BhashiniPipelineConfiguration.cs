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
        public BhashiniTask Type;

        /// <summary>
        /// The supported configurations.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-config-call/response-payload"/>
        /// </remarks>
        [JsonProperty("config")]
        public BhashiniPipelineTaskConfiguration[] Configurations;

        /// <summary>
        /// Gets the first <see cref="BhashiniPipelineTaskConfiguration"/> in <see cref="Configurations"/>.
        /// </summary>
        public BhashiniPipelineTaskConfiguration First => Configurations.Length > 0 ? Configurations[0] : null;
    }
}
