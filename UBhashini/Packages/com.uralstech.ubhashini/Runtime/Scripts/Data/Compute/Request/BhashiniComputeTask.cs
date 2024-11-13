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
        public BhashiniPipelineTaskType Type;

        /// <summary>
        /// The configuration for the task.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-compute-call/request-payload"/>
        /// </remarks>
        [JsonProperty("config")]
        public BhashiniComputeConfiguration Configuration;

        /// <param name="type">The task type.</param>
        public BhashiniComputeTask(BhashiniPipelineTaskType type)
        {
            Type = type;
        }

        /// <param name="type">The task type.</param>
        /// <param name="configuration">The task configuration from a <see cref="Pipeline.BhashiniPipelineResponse"/>.</param>
        public BhashiniComputeTask(BhashiniPipelineTaskType type, Pipeline.BhashiniPipelineTaskConfiguration configuration) : this(type)
        {
            Configuration = new BhashiniComputeConfiguration()
            {
                ServiceId = configuration.ServiceId,
                Language = configuration.Language,
                VoiceType = ((BhashiniVoiceType?)configuration.SupportedVoices?.GetValue(0)) ?? BhashiniVoiceType.Default,
            };
        }
    }
}
