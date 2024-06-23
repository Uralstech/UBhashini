using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

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
 
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class BhashiniPipelineResponseConfig
    {
        public BhashiniPipelineTaskType TaskType;

        [JsonProperty("config")]
        public BhashiniPipelineData[] Data;
    }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class BhashiniPipelineData
    {
        public string ServiceId;
        public string ModelId;
        public BhashiniLanguageData Language;
        public BhashiniVoiceType[] SupportedVoices;
        public string[] Domain;
    }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class BhashiniPipelineInferenceData
    {
        public string CallbackUrl;
        public BhashiniPipelineInferenceApiKey InferenceApiKey;
        public bool IsMultilingualEnabled;
        public bool IsSyncApi;
    }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class BhashiniPipelineInferenceApiKey
    {
        public string Name;
        public string Value;
    }
}
