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
    /// A specific task (like STT, TTS or translation) to be carried out by a pipeline.
    /// </summary>
    public class BhashiniPipelineRequestTask
    {
        /// <summary>
        /// The type of the task.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-config-call/request-payload"/>
        /// </remarks>
        [JsonProperty("taskType")]
        public BhashiniTask Type;

        /// <summary>
        /// Optional extra configurations for the task.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-config-call/request-payload"/>
        /// </remarks>
        [JsonProperty("config", NullValueHandling = NullValueHandling.Ignore)]
        public BhashiniPipelineRequestTaskConfiguration Configuration = null;

        /// <param name="type">The type of the task.</param>
        public BhashiniPipelineRequestTask(BhashiniTask type)
        {
            Type = type;
        }

        /// <param name="type">The type of the task.</param>
        /// <param name="sourceLanguage">Source language for the task.</param>
        /// <param name="targetLanguage">Target language for the task. Optional, only for translation.</param>
        public BhashiniPipelineRequestTask(BhashiniTask type, string sourceLanguage, string targetLanguage = null) : this(type)
        {
            Configuration = new BhashiniPipelineRequestTaskConfiguration()
            {
                Language = new BhashiniLanguageData()
                {
                    Source = sourceLanguage,
                    Target = targetLanguage,
                },
            };
        }
    }
}
