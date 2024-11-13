using Newtonsoft.Json;

namespace Uralstech.UBhashini.Data.Compute
{
    /// <summary>
    /// Audio input for STT requests, encoded in base64.
    /// </summary>
    public class BhashiniAudioInput
    {
        /// <summary>
        /// Audio input for STT requests, encoded in base64.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-compute-call/request-payload"/>
        /// </remarks>
        [JsonProperty("audioContent")]
        public string Base64Data;

        /// <param name="base64Data">Audio input for STT requests, encoded in base64.</param>
        public BhashiniAudioInput(string base64Data)
        {
            Base64Data = base64Data;
        }
    }
}
