using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Uralstech.UBhashini.Data
{
    /// <remarks>
    /// These enum values were taken from <see href="https://app.swaggerhub.com/apis/ulca/ULCA/0.7.0">SwaggerHub</see> and only <see cref="Wav"/> is guaranteed to work.
    /// </remarks>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BhashiniAudioFormat
    {
        UNSPECIFIED_UNKNOWN_DONTUSE_DEFAULT,

        [EnumMember(Value = "wav")]
        Wav,

        [EnumMember(Value = "pcm")]
        Pcm,

        [EnumMember(Value = "mp3")]
        Mp3,

        [EnumMember(Value = "flac")]
        Flac
    }
}
