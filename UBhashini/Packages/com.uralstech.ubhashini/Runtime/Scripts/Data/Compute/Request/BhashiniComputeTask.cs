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

namespace Uralstech.UBhashini.Data.Compute
{
    /// <summary>
    /// A computation task for a pipeline.
    /// </summary>
    public class BhashiniComputeTask
    {
        /// <summary>
        /// The task type.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-compute-call/request-payload"/>
        /// </remarks>
        [JsonProperty("taskType")]
        public BhashiniTask Type;

        /// <summary>
        /// The configuration for the task.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-compute-call/request-payload"/>
        /// </remarks>
        [JsonProperty("config")]
        public BhashiniComputeTaskConfiguration Configuration;

        /// <param name="type">The task type.</param>
        public BhashiniComputeTask(BhashiniTask type)
        {
            Type = type;
        }

        /// <param name="type">The task type.</param>
        /// <param name="configuration">The task configuration from a <see cref="Pipeline.BhashiniPipelineResponse"/>.</param>
        public BhashiniComputeTask(BhashiniTask type, Pipeline.BhashiniPipelineTaskConfiguration configuration) : this(type)
        {
            Configuration = new BhashiniComputeTaskConfiguration()
            {
                ServiceId = configuration.ServiceId,
                Language = configuration.Language,
                VoiceType = ((BhashiniVoiceType?)configuration.SupportedVoices?.GetValue(0)) ?? BhashiniVoiceType.Default,
            };
        }
    }
}
