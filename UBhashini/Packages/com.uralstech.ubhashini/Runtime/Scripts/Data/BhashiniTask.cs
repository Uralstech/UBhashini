using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Uralstech.UBhashini.Data
{
    /// <summary>
    /// The type of task a pipeline should compute.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BhashiniTask
    {
        /// <summary>
        /// Default value. Do not use.
        /// </summary>
        Default = 0,

        /// <summary>
        /// Speech To Text.
        /// </summary>
        [EnumMember(Value = "asr")]
        SpeechToText,

        /// <summary>
        /// Translation.
        /// </summary>
        [EnumMember(Value = "translation")]
        Translation,

        /// <summary>
        /// Text To Speech.
        /// </summary>
        [EnumMember(Value = "tts")]
        TextToSpeech,
    }
}
