using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UBhashini.Data.Compute
{
    /// <summary>
    /// A computation task for a pipeline.
    /// </summary>
    public class BhashiniComputeTask
    {
        /// <summary>
        /// The task type.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-compute-call/request-payload"/>
        /// </remarks>
        [JsonProperty("taskType")]
        public BhashiniTask Type;

        /// <summary>
        /// The configuration for the task.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-compute-call/request-payload"/>
        /// </remarks>
        [JsonProperty("config")]
        public BhashiniComputeTaskConfiguration Configuration;

        /// <param name="type">The task type.</param>
        public BhashiniComputeTask(BhashiniTask type)
        {
            Type = type;
        }

        /// <param name="type">The task type.</param>
        /// <param name="configuration">The task configuration from a <see cref="Pipeline.BhashiniPipelineResponse"/>.</param>
        public BhashiniComputeTask(BhashiniTask type, Pipeline.BhashiniPipelineTaskConfiguration configuration) : this(type)
        {
            Configuration = new BhashiniComputeTaskConfiguration()
            {
                ServiceId = configuration.ServiceId,
                Language = configuration.Language,
                VoiceType = ((BhashiniVoiceType?)configuration.SupportedVoices?.GetValue(0)) ?? BhashiniVoiceType.Default,
            };
        }
    }
}
