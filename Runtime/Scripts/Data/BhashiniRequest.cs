using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Uralstech.UBhashini.Data
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class BhashiniRequest
    {
        public BhashiniPipelineTask[] PipelineTasks;

        /// <summary>
        /// Required for ConfigurePipelinetasks, but must be empty for ComputeOnPipeline tasks.
        /// </summary>
        [DefaultValue(null)]
        public BhashiniPipelineConfig PipelineRequestConfig = null;

        /// <summary>
        /// Required for ComputeOnPipeline, but must be empty for ConfigurePipelinetasks tasks.
        /// </summary>
        [DefaultValue(null)]
        public BhashiniInputData InputData = null;
    }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class BhashiniInputData
    {
        [JsonProperty("input"), DefaultValue(null)]
        public BhashiniTextSource[] Text = null;

        [DefaultValue(null)]
        public BhashiniAudioSource[] Audio = null;
    }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class BhashiniTextSource
    {
        public string Source;

        /// <summary>
        /// [DO NOT SET] Only for ComputeOnPipeline translate output.
        /// </summary>
        [DefaultValue(null)]
        public string Target = null;

    }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class BhashiniAudioSource
    {
        public string AudioContent;

        /// <summary>
        /// [DO NOT SET] Only for ComputeOnPipeline output.
        /// </summary>
        [DefaultValue(null)]
        public string AudioUri = null;
    }

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
