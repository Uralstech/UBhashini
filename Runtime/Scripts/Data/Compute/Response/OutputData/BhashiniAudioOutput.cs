using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UBhashini.Data.Compute
{
    /// <summary>
    /// Audio output for TTS tasks.
    /// </summary>
    public class BhashiniAudioOutput
    {
        /// <summary>
        /// Base64 encoded audio data.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-compute-call/response-payload"/>
        /// </remarks>
        [JsonProperty("audioContent")]
        public string Base64Audio;

        /// <summary>
        /// A URI to the audio data.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-compute-call/response-payload"/>
        /// </remarks>
        [JsonProperty("audioUri")]
        public string AudioUri;
    }
}
