using Newtonsoft.Json;

namespace Uralstech.UBhashini.Data.Compute
{
    /// <summary>
    /// Text input for translation and TTS requests.
    /// </summary>
    public class BhashiniTextInput
    {
        /// <summary>
        /// Text input for translation and TTS requests.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-compute-call/request-payload"/>
        /// </remarks>
        [JsonProperty("source")]
        public string Data;

        /// <param name="data">Text input for translation and TTS requests.</param>
        public BhashiniTextInput(string data)
        {
            Data = data;
        }
    }
}
