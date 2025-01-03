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

namespace Uralstech.UBhashini.Data.Pipeline
{
    /// <summary>
    /// A list of supported pipeline configurations for a task.
    /// </summary>
    public class BhashiniPipelineConfiguration
    {
        /// <summary>
        /// The type of the task.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-config-call/response-payload"/>
        /// </remarks>
        [JsonProperty("taskType")]
        public BhashiniTask Type;

        /// <summary>
        /// The supported configurations.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-config-call/response-payload"/>
        /// </remarks>
        [JsonProperty("config")]
        public BhashiniPipelineTaskConfiguration[] Configurations;

        /// <summary>
        /// Gets the first <see cref="BhashiniPipelineTaskConfiguration"/> in <see cref="Configurations"/>.
        /// </summary>
        [JsonIgnore]
        public BhashiniPipelineTaskConfiguration First => Configurations.Length > 0 ? Configurations[0] : null;
    }
}
