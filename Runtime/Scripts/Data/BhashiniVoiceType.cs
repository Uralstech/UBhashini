using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Uralstech.UBhashini.Data
{
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
