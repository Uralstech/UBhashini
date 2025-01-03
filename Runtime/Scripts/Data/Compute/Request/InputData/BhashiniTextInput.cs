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
