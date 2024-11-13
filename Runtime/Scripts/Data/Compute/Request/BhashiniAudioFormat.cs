using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Uralstech.UBhashini.Data.Compute
{
    /// <remarks>
    /// These enum values were taken from <see href="https://app.swaggerhub.com/apis/ulca/ULCA/0.7.0">SwaggerHub</see> and only <see cref="Wav"/> is guaranteed to work.
    /// </remarks>
    /// <remarks>
    /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-compute-call/request-payload"/>
    /// </remarks>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BhashiniAudioFormat
    {
        /// <summary>
        /// Default value. Do not use.
        /// </summary>
        Default = 0,

        /// <summary>
        /// WAV
        /// </summary>
        [EnumMember(Value = "wav")]
        Wav,

        /// <summary>
        /// PCM
        /// </summary>
        [EnumMember(Value = "pcm")]
        Pcm,

        /// <summary>
        /// MP3
        /// </summary>
        [EnumMember(Value = "mp3")]
        Mp3,

        /// <summary>
        /// FLAC
        /// </summary>
        [EnumMember(Value = "flac")]
        Flac
    }
}
