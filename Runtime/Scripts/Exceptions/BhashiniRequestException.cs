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

using System;
using UnityEngine.Networking;

namespace Uralstech.UBhashini.Exceptions
{
    /// <summary>
    /// Exception thrown due to request-related failures.
    /// </summary>
    public class BhashiniRequestException : Exception
    {
        internal BhashiniRequestException(UnityWebRequest request)
            : base($"Failed Bhashini API request! URI: {request.uri.AbsoluteUri} | Reason: {request.error} | Details:\n{request.downloadHandler.text}") { }

        internal BhashiniRequestException(string message) : base(message) { }
    }
}
