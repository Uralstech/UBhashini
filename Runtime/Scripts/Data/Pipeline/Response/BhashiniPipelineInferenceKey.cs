using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UBhashini.Data.Pipeline
{
    /// <summary>
    /// The API key (Header, Token) for authenticating with the API.
    /// </summary>
    public class BhashiniPipelineInferenceKey
    {
        /// <summary>
        /// The header to send the API key in.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-config-call/response-payload"/>
        /// </remarks>
        [JsonProperty("name")]
        public string Header;

        /// <summary>
        /// The actual API key/token.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-config-call/response-payload"/>
        /// </remarks>
        [JsonProperty("value")]
        public string Token;
    }
}
