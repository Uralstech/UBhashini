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
    /// The supported languages for a pipeline's tasks.
    /// </summary>
    public class BhashiniPipelineSupportedLanguages
    {
        /// <summary>
        /// The supported source language for this task.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-config-call/response-payload"/>
        /// </remarks>
        [JsonProperty("sourceLanguage")]
        public string SupportedSource;

        /// <summary>
        /// The supported target language(s) for this task.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-config-call/response-payload"/>
        /// </remarks>
        [JsonProperty("targetLanguageList")]
        public string[] SupportedTargets;
    }
}
