using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Linq;

namespace Uralstech.UBhashini.Data.Pipeline
{
    /// <summary>
    /// Response of a <see cref="BhashiniPipelineRequest"/>.
    /// </summary>
    public class BhashiniPipelineResponse
    {
        /// <summary>
        /// The supported languages for the pipeline's tasks.
        /// </summary>
        /// <remarks>
        /// As per the documentation:
        /// <code>
        /// This parameter helps integrator to know what languages are available that can
        /// be used for the requested pipeline tasks in that sequence.
        /// 
        /// For example, consider scenarios where Integrator requests for either:
        ///     - Individual Task i.e., either ASR or Translation or TTS as shown here:
        ///     https://bhashini.gitbook.io/bhashini-apis/pipeline-config-call/request-payload#integrators-want-to-do-individual-tasks
        ///     - Combination of Tasks in that sequence i.e.,
        ///         - ASR+Translation or
        ///         - Translation+TTS or
        ///         - ASR+Translation+TTS as shown here:
        ///         https://bhashini.gitbook.io/bhashini-apis/pipeline-config-call/request-payload#integrators-want-to-do-combination-of-tasks-in-that-order
        /// 
        /// For Single Tasks, the understanding is straight-forward that the languages appearing in the response corresponds to that task. e.g.
        ///     - If the integrator wants to do  only ASR, the languages appearing shows that Server can do ASR in these languages. In this case, parameters
        ///     sourceLanguage and targetLanguageList will contain the same value since for ASR involves only one language unlike Translation where source
        ///     and target (two) languages are involved. In this case, targetLanguageList can safely be ignored and only sourceLanguage can be used. 
        /// 
        ///     - If the integrator wants to do only TTS, the languages appearing shows that Server can do TTS in these languages. In this case, parameters
        ///     sourceLanguage and targetLanguageList will contain the same value since for TTS too only one language is involved. In this case too,
        ///     targetLanguageList can safely be ignored and only sourceLanguage can be used.
        /// </code>
        /// 
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-config-call/response-payload"/>
        /// </remarks>
        [JsonProperty("languages")]
        public BhashiniPipelineSupportedLanguages[] SupportedLanguages;

        /// <summary>
        /// List of available pipeline configurations for the given tasks.
        /// </summary>
        /// <remarks>
        /// As per the documentation:
        /// <code>
        /// This parameter helps the integrator to obtain the Service ID for a particular
        /// task type and language(s) associated with that task.
        /// 
        /// The task types appearing here will be the same as the ones that the integrator
        /// requested while sending the pipelineTasks parameter in Request Payload e.g.
        ///     - Integrator request for configuration of the combination of ASR, Translation
        ///     and TTS together, the pipelineResponseConfig parameter in the output will
        ///     contain the JSON data as shown below. It will contain three dictionaries for
        ///     each task type ASR, Translation and TTS. If Integrator requested for a
        ///     combination of ASR and Translation, this parameter would contain JSON data
        ///     for ASR and Translation only.
        /// </code>
        /// 
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-config-call/response-payload"/>
        /// </remarks>
        [JsonProperty("pipelineResponseConfig")]
        public BhashiniPipelineConfiguration[] PipelineConfigurations;

        /// <summary>
        /// The pipeline's inference endpoint.
        /// </summary>
        /// <remarks>
        /// As per the documentation:
        /// <code>
        /// This parameter helps the integrator to know the details of the Pipeline Compute Callwhere to send
        /// (callbackURL parameter) and shall be sent along with the Authorization Key-Value pair received under
        /// inferenceApiKey parameter which will be used for authentication of the same.
        /// </code>
        /// 
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-config-call/response-payload"/>
        /// </remarks>
        [JsonProperty("pipelineInferenceAPIEndPoint")]
        public BhashiniPipelineInferenceEndpoint InferenceEndpoint;

        /// <summary>
        /// Gets the first <see cref="BhashiniTask.SpeechToText"/> type <see cref="BhashiniPipelineConfiguration"/> in <see cref="PipelineConfigurations"/>.
        /// </summary>
        [JsonIgnore]
        public BhashiniPipelineConfiguration SpeechToTextConfiguration => _speechToTextConfiguration ??= PipelineConfigurations.Where(config => config.Type == BhashiniTask.SpeechToText).FirstOrDefault();
        private BhashiniPipelineConfiguration _speechToTextConfiguration;

        /// <summary>
        /// Gets the first <see cref="BhashiniTask.Translation"/> type <see cref="BhashiniPipelineConfiguration"/> in <see cref="PipelineConfigurations"/>.
        /// </summary>
        [JsonIgnore]
        public BhashiniPipelineConfiguration TranslateConfiguration => _translateConfiguration ??= PipelineConfigurations.Where(config => config.Type == BhashiniTask.Translation).FirstOrDefault();
        private BhashiniPipelineConfiguration _translateConfiguration;

        /// <summary>
        /// Gets the first <see cref="BhashiniTask.TextToSpeech"/> type <see cref="BhashiniPipelineConfiguration"/> in <see cref="PipelineConfigurations"/>.
        /// </summary>
        [JsonIgnore]
        public BhashiniPipelineConfiguration TextToSpeechConfiguration => _textToSpeechConfiguration ??= PipelineConfigurations.Where(config => config.Type == BhashiniTask.TextToSpeech).FirstOrDefault();
        private BhashiniPipelineConfiguration _textToSpeechConfiguration;
    }
}
