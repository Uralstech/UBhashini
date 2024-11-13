using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UBhashini.Data.Pipeline
{
    /// <summary>
    /// Request to configure a pipeline for inference. Response type is <see cref="BhashiniPipelineResponse"/>.
    /// </summary>
    public class BhashiniPipelineRequest
    {
        /// <summary>
        /// The tasks to be performed using the pipeline.
        /// </summary>
        /// <remarks>
        /// As per the documentation:
        /// <code>
        /// This parameter takes an array of tasks, in the form of dictionary of taskType
        /// as defined above, that are to be done by the integrator. The sequence of tasks
        /// matter.
        /// </code>
        /// 
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-config-call/request-payload"/>
        /// </remarks>
        [JsonProperty("pipelineTasks")]
        public BhashiniPipelineRequestTask[] Tasks;

        /// <summary>
        /// Data on which pipeline provider to use.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-config-call/request-payload"/>
        /// </remarks>
        [JsonProperty("pipelineRequestConfig")]
        public BhashiniPipelineRequestConfiguration Configuration;
    }
}
