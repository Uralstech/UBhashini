using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;

namespace Uralstech.UBhashini.Data.Compute
{
    /// <summary>
    /// Configuration for a computation task.
    /// </summary>
    public class BhashiniComputeTaskConfiguration
    {
        /// <summary>
        /// The service to use for computation.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-compute-call/request-payload"/>
        /// </remarks>
        [JsonProperty("serviceId")]
        public string ServiceId;

        /// <summary>
        /// The language of the computation input and output.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-compute-call/request-payload"/>
        /// </remarks>
        [JsonProperty("language")]
        public BhashiniLanguageData Language;

        /// <summary>
        /// Only for STT requests. The format to encode the input audio in.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-compute-call/request-payload"/>
        /// </remarks>
        [JsonProperty("audioFormat", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(BhashiniAudioFormat.Default)]
        public BhashiniAudioFormat AudioFormat = BhashiniAudioFormat.Default;

        /// <summary>
        /// Only for STT requests. The sample rate of the input audio.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-compute-call/request-payload"/>
        /// </remarks>
        [JsonProperty("samplingRate", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(0)]
        public int SampleRate = 0;

        /// <summary>
        /// Only for TTS requests. The voice type.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-compute-call/request-payload"/>
        /// </remarks>
        [JsonProperty("gender", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(BhashiniVoiceType.Default)]
        public BhashiniVoiceType VoiceType = BhashiniVoiceType.Default;
    }
}
