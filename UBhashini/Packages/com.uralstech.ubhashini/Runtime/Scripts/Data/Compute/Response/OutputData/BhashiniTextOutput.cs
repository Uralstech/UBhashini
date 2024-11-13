using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UBhashini.Data.Compute
{
    /// <summary>
    /// Text output for STT and translation tasks.
    /// </summary>
    public class BhashiniTextOutput
    {

        /// <summary>
        /// This is source text for translation tasks, transcribed output for STT tasks.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-compute-call/response-payload"/>
        /// </remarks>
        [JsonProperty("source")]
        public string Source;

        /// <summary>
        /// Result for translation tasks.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-compute-call/response-payload"/>
        /// </remarks>
        [JsonProperty("target")]
        public string Target;
    }
}
