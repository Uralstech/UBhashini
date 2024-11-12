using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UBhashini.Data
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class BhashiniPipelineInferenceData
    {
        public string CallbackUrl;
        public BhashiniPipelineInferenceApiKey InferenceApiKey;
        public bool IsMultilingualEnabled;
        public bool IsSyncApi;
    }
}
