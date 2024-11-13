using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UBhashini.Data.Compute
{
    /// <summary>
    /// The result of a <see cref="BhashiniComputeRequest"/>.
    /// </summary>
    public class BhashiniComputeResponse
    {
        /// <summary>
        /// The results for each computed task.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-compute-call/response-payload"/>
        /// </remarks>
        [JsonProperty("pipelineResponse")]
        public BhashiniComputeResponseTask[] TaskResults;
    }
}
