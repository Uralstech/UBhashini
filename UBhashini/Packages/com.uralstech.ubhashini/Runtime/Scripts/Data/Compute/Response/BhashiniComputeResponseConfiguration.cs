using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace Uralstech.UBhashini.Data.Compute
{
    /// <summary>
    /// The configuration of the task's result.
    /// </summary>
    public class BhashiniComputeResponseConfiguration
    {
        /// <summary>
        /// The service used to compute the result.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-compute-call/response-payload"/>
        /// </remarks>
        [JsonProperty("serviceId")]
        public string ServiceId;

        /// <summary>
        /// The language metadata for the text input/output.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-compute-call/response-payload"/>
        /// </remarks>
        [JsonProperty("language")]
        public BhashiniComputeLanguageMetadata LanguageMetadata;

        /// <summary>
        /// Format of the input/output audio data.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-compute-call/response-payload"/>
        /// </remarks>
        [JsonProperty("audioFormat")]
        public BhashiniAudioFormat AudioFormat;

        /// <summary>
        /// Sample rate of the input/output audio data.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-compute-call/response-payload"/>
        /// </remarks>
        [JsonProperty("samplingRate")]
        public int SampleRate;

        /// <summary>
        /// Additional data of an unknown format.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-compute-call/response-payload"/>
        /// </remarks>
        [JsonExtensionData]
        public IDictionary<string, JToken> AdditionalData;
    }
}
