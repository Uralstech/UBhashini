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
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace Uralstech.UBhashini.Data.Compute
{
    /// <summary>
    /// The configuration of the task's result.
    /// </summary>
    public class BhashiniComputeResponseTaskConfiguration
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
        /// Additional data.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-compute-call/response-payload"/>
        /// </remarks>
        [JsonExtensionData]
        public IDictionary<string, JToken> AdditionalData;
    }
}
