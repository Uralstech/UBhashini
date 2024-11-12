using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;

namespace Uralstech.UBhashini.Data
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class BhashiniPipelineTask
    {
        public BhashiniPipelineTaskType TaskType;

        [DefaultValue(null)]
        public BhashiniPipelineTaskConfig Config = null;

        public static BhashiniPipelineTask GetConfigurationTask(BhashiniPipelineTaskType type)
        {
            return new()
            {
                TaskType = type,
            };
        }

        public static BhashiniPipelineTask GetConfigurationTask(BhashiniPipelineTaskType type, string sourceLanguage, string targetLanguage = null)
        {
            return new()
            {
                TaskType = type,
                Config = new()
                {
                    Language = new()
                    {
                        SourceLanguage = sourceLanguage,
                        TargetLanguage = targetLanguage ?? string.Empty,
                    },
                },
            };
        }
    }
}
