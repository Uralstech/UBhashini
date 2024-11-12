using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UBhashini.Data
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class BhashiniComputeResponseData
    {
        public BhashiniPipelineTaskType TaskType;
        public BhashiniPipelineTaskConfig Config;

        [JsonProperty("output")]
        public BhashiniTextSource[] Text;

        public BhashiniAudioSource[] Audio;
    }
}
