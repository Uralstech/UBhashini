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
