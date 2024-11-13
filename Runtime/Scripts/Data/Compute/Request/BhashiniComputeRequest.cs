using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UBhashini.Data.Compute
{
    /// <summary>
    /// Request for inferencing a pipeline. Response type is <see cref="BhashiniComputeResponse"/>.
    /// </summary>
    public class BhashiniComputeRequest
    {
        /// <summary>
        /// The tasks to be carried out by the pipeline.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-compute-call/request-payload"/>
        /// </remarks>
        [JsonProperty("pipelineTasks")]
        public BhashiniComputeTask[] Tasks;

        /// <summary>
        /// The input for the pipeline.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-compute-call/request-payload"/>
        /// </remarks>
        [JsonProperty("inputData")]
        public BhashiniInputData Input;
    }
}
