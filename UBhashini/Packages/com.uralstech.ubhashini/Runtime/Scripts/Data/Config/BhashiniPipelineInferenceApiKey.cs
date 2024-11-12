using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace Uralstech.UBhashini.Data
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class BhashiniPipelineInferenceApiKey
    {
        public string Name;
        public string Value;
    }
}
