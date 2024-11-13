using Newtonsoft.Json;

namespace Uralstech.UBhashini.Data.Compute
{
    /// <summary>
    /// Input data for pipeline inference.
    /// </summary>
    public class BhashiniInputData
    {
        /// <summary>
        /// Text input for translation and TTS requests.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-compute-call/request-payload"/>
        /// </remarks>
        [JsonProperty("input", NullValueHandling = NullValueHandling.Ignore)]
        public BhashiniTextInput[] TextData;

        /// <summary>
        /// Audio input for STT requests.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-compute-call/request-payload"/>
        /// </remarks>
        [JsonProperty("audio", NullValueHandling = NullValueHandling.Ignore)]
        public BhashiniAudioInput[] AudioData;

        /// <param name="text">Text input for translation and TTS requests.</param>
        /// <param name="audio">Audio input for STT requests.</param>
        public BhashiniInputData(string text = null, string audio = null)
        {
            if (!string.IsNullOrEmpty(text))
                TextData = new BhashiniTextInput[1]
                {
                    new(text)
                };
            else if (!string.IsNullOrEmpty(audio))
                AudioData = new BhashiniAudioInput[1]
                {
                    new(audio)
                };
        }
    }
}
