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
using Uralstech.UBhashini.Data.Compute;

namespace Uralstech.UBhashini.Exceptions
{
    /// <summary>
    /// Exception thrown during IO-related audio processing failures.
    /// </summary>
    public class BhashiniAudioIOException : SystemException
    {
        internal BhashiniAudioIOException(string message, BhashiniAudioFormat format) : base($"Unsupported Bhashini API audio format \"{format}\": {message}") { }

        internal BhashiniAudioIOException(string message, Exception innerException) : base(message, innerException) { }

        internal BhashiniAudioIOException(string message) : base(message) { }
    }
}
