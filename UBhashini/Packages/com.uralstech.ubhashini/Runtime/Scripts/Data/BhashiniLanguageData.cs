using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;

namespace Uralstech.UBhashini.Data
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class BhashiniLanguageData
    {
        /// <summary>
        /// [SET: REQUIRED] The source language of the data.
        /// </summary>
        public string SourceLanguage;

        /// <summary>
        /// [SET: OPTIONAL] Can be <see cref="string.Empty"/>; the target language of the data.
        /// </summary>
        [DefaultValue("")]
        public string TargetLanguage = string.Empty;

        /// <summary>
        /// [DO NOT SET] May be <see langword="null"/>; used in ConfigurePipeline responses.
        /// </summary>
        [DefaultValue(null)]
        public string[] TargetLanguageList = null;

        /// <summary>
        /// [DO NOT SET] May be <see cref="string.Empty"/>; the iso-15924 script code of the resposne.
        /// </summary>
        [DefaultValue("")]
        public string SourceScriptCode = string.Empty;
    }
}
