using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UBhashini.Data
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class BhashiniPipelineConfigResponse
    {
        public BhashiniLanguageData[] Languages;

        public BhashiniPipelineResponseConfig[] PipelineResponseConfig;

        [JsonProperty("pipelineInferenceAPIEndPoint")]
        public BhashiniPipelineInferenceData PipelineEndpoint;
    }
}
