using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Uralstech.UBhashini.Data
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class BhashiniPipelineTaskConfig
    {
        public BhashiniLanguageData Language;

        /// <summary>
        /// Required for ComputeOnPipeline tasks, but must be empty for ConfigurePipeline tasks.
        /// </summary>
        [DefaultValue("")]
        public string ServiceId = string.Empty;

        /// <summary>
        /// Required for ComputeOnPipeline STT tasks, but must be empty for any other tasks.
        /// </summary>
        /// <remarks>
        /// Not all methods provided by this plugin support all audio formats, so here's a table of supported formats per method.
        /// 
        /// <list type="table">
        ///     <listheader>
        ///         <term>Method</term>
        ///         <description>Supported formats</description>
        ///     </listheader>
        ///     
        ///     <item>
        ///         <term><see cref="BhashiniApiManager.ComputeOnPipeline(BhashiniPipelineInferenceData, BhashiniPipelineTask[], string, UnityEngine.AudioClip, string)">BhashiniApiManager.ComputeOnPipeline</see></term>
        ///         <description>*WAV, **PCM, for other formats use the "rawBase64AudioSource" parameter.</description>
        ///     </item>
        ///     
        ///     <item>
        ///         <term><see cref="PipelineComputationExtensions.GetTextToSpeechResult(BhashiniComputeResponse)">BhashiniComputeResponse.TextToSpeechResult</see></term>
        ///         <description>WAV, MP3, **PCM.</description>
        ///     </item>
        /// </list>
        /// 
        /// *<see href="https://openupm.com/packages/com.utilities.encoder.wav/">Utilities.Encoding.Wav</see> and <see href="https://openupm.com/packages/com.utilities.audio/">Utilities.Audio</see> are required.
        /// <br/>
        /// *<see href="https://openupm.com/packages/com.utilities.audio/">Utilities.Audio</see> is required.
        /// </remarks>
        public BhashiniAudioFormat AudioFormat;

        /// <summary>
        /// Required for ComputeOnPipeline STT tasks, but must be empty for any other tasks.
        /// </summary>
        public int SamplingRate;

        /// <summary>
        /// Required for ComputeOnPipeline TTS tasks, but must be empty for any other tasks.
        /// </summary>
        [DefaultValue(-1)]
        public BhashiniVoiceType Gender = BhashiniVoiceType.UNSPECIFIED_UNKNOWN_DONTUSE_DEFAULT;
    }
}
