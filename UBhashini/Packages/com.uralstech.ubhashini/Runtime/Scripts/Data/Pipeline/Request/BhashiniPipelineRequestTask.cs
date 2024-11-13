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
