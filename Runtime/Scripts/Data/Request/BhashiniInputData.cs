using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;

namespace Uralstech.UBhashini.Data
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class BhashiniInputData
    {
        [JsonProperty("input"), DefaultValue(null)]
        public BhashiniTextSource[] Text = null;

        [DefaultValue(null)]
        public BhashiniAudioSource[] Audio = null;
    }
}
