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
