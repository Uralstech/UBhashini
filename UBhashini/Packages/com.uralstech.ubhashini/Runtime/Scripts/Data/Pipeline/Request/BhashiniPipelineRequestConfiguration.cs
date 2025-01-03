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
    /// Data on which pipeline provider to use.
    /// </summary>
    public class BhashiniPipelineRequestConfiguration
    {
        /// <summary>
        /// The ID of the pipeline provider.
        /// </summary>
        /// <remarks>
        /// As per the documentation:
        /// <code>
        /// pipelineId takes a string value of the specific pipeline integrator wants to use.
        /// The pipeline ID can be obtained either via Pipeline Search Call or via ULCA Web
        /// based on the description which helps the integrator to understand what a pipeline
        /// can or cannot do. Each pipeline ID may support multiple task and task sequences.
        /// </code>
        /// 
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-config-call/request-payload"/>
        /// </remarks>
        [JsonProperty("pipelineId")]
        public string ProviderId;
    }
}
