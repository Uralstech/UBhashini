// Copyright 2024 URAV ADVANCED LEARNING SYSTEMS PRIVATE LIMITED
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Uralstech.UBhashini.Data
{
    /// <remarks>
    /// These enum values were taken from <see href="https://app.swaggerhub.com/apis/ulca/ULCA/0.7.0">SwaggerHub</see> and only <see cref="Male"/> and <see cref="Female"/> are guaranteed to work.
    /// </remarks>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BhashiniVoiceType
    {
        /// <summary>
        /// Default value. Do not use.
        /// </summary>
        Default = 0,

        /// <summary>
        /// Male voice.
        /// </summary>
        [EnumMember(Value = "male")]
        Male,

        /// <summary>
        /// Female voice.
        /// </summary>
        [EnumMember(Value = "female")]
        Female,

        /// <summary>
        /// Trans voice.
        /// </summary>
        [EnumMember(Value = "transgender")]
        Transgender,

        /// <summary>
        /// Non specified voice.
        /// </summary>
        [EnumMember(Value = "non-specified")]
        NonSpecified,

        /// <summary>
        /// Other voice.
        /// </summary>
        [EnumMember(Value = "others")]
        Others,
    }
}
