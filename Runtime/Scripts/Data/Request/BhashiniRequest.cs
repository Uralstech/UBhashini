using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;

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
}
