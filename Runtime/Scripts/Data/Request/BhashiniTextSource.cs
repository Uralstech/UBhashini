using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;

namespace Uralstech.UBhashini.Data
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class BhashiniTextSource
    {
        public string Source;

        /// <summary>
        /// [DO NOT SET] Only for ComputeOnPipeline translate output.
        /// </summary>
        [DefaultValue(null)]
        public string Target = null;

    }
}
