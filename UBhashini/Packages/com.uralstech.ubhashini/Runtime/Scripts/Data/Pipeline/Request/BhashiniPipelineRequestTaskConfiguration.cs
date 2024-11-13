using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UBhashini.Data.Pipeline
{
    /// <summary>
    /// Data to configure a task for a pipeline request.
    /// </summary>
    public class BhashiniPipelineRequestTaskConfiguration
    {
        /// <summary>
        /// Language configuration data for the pipeline.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-config-call/request-payload"/>
        /// </remarks>
        [JsonProperty("language")]
        public BhashiniLanguageData Language;
    }
}
