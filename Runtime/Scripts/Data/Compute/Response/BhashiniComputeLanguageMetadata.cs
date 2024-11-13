using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UBhashini.Data.Compute
{
    /// <summary>
    /// The language metadata for the text input/output.
    /// </summary>
    public class BhashiniComputeLanguageMetadata
    {
        /// <summary>
        /// The language code.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-compute-call/response-payload"/>
        /// </remarks>
        [JsonProperty("sourceLanguage")]
        public string Language;

        /// <summary>
        /// The script code which the text was in.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-compute-call/response-payload"/>
        /// </remarks>
        [JsonProperty("sourceScriptCode")]
        public string LanguageScript;
    }
}
