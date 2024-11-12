using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Uralstech.UBhashini.Data
{

    [JsonConverter(typeof(StringEnumConverter))]
    public enum BhashiniPipelineTaskType
    {
        UNSPECIFIED_UNKNOWN_DONTUSE_DEFAULT,

        [EnumMember(Value = "asr")]
        SpeechToText,

        [EnumMember(Value = "translation")]
        TextTranslation,

        [EnumMember(Value = "tts")]
        TextToSpeech,
    }
}
