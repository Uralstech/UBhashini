using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.ComponentModel;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

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

    /// <remarks>
    /// These enum values were taken from <see href="https://app.swaggerhub.com/apis/ulca/ULCA/0.7.0">SwaggerHub</see> and only <see cref="Male"/> and <see cref="Female"/> are guaranteed to work.
    /// </remarks>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BhashiniVoiceType
    {
        UNSPECIFIED_UNKNOWN_DONTUSE_DEFAULT = -1,

        [EnumMember(Value = "male")]
        Male,

        [EnumMember(Value = "female")]
        Female,

        [EnumMember(Value = "transgender")]
        Transgender,

        [EnumMember(Value = "non-specified")]
        NonSpecified,

        [EnumMember(Value = "others")]
        Others,
    }
}
