using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace Uralstech.UBhashini.Data
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class BhashiniPipelineResponseConfig
    {
        public BhashiniPipelineTaskType TaskType;

        [JsonProperty("config")]
        public BhashiniPipelineData[] Data;
    }
}
