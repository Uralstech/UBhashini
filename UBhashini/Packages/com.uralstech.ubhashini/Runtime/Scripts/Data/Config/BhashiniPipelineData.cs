using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace Uralstech.UBhashini.Data
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class BhashiniPipelineData
    {
        public string ServiceId;
        public string ModelId;
        public BhashiniLanguageData Language;
        public BhashiniVoiceType[] SupportedVoices;
        public string[] Domain;
    }
}
