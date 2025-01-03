// Copyright 2024 URAV ADVANCED LEARNING SYSTEMS PRIVATE LIMITED
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

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
