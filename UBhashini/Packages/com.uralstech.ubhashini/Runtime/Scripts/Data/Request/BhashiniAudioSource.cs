using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;

namespace Uralstech.UBhashini.Data
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class BhashiniAudioSource
    {
        public string AudioContent;

        /// <summary>
        /// [DO NOT SET] Only for ComputeOnPipeline output.
        /// </summary>
        [DefaultValue(null)]
        public string AudioUri = null;
    }
}
