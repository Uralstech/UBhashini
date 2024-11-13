using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UBhashini.Data
{
    /// <summary>
    /// Language data for requests.
    /// </summary>
    public class BhashiniLanguageData
    {
        /// <summary>
        /// The source language of the data.
        /// </summary>
        [JsonProperty("sourceLanguage")]
        public string Source;

        /// <summary>
        /// The target language of the data. For translation tasks.
        /// </summary>
        [JsonProperty("targetLanguage", NullValueHandling = NullValueHandling.Ignore)]
        public string Target = null;
    }
}
