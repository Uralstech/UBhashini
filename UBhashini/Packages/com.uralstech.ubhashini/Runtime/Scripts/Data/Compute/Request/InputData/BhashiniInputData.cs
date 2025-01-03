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
using System;
using UnityEngine;
using Uralstech.UBhashini.Exceptions;

#if UTILITIES_ENCODING_WAV_1_0_0_OR_GREATER
using Utilities.Encoding.Wav;
#endif

#if UTILITIES_AUDIO_1_0_0_OR_GREATER
using Utilities.Audio;
#endif

namespace Uralstech.UBhashini.Data.Compute
{
    /// <summary>
    /// Input data for pipeline inference.
    /// </summary>
    public class BhashiniInputData
    {
        /// <summary>
        /// Text input for translation and TTS requests.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-compute-call/request-payload"/>
        /// </remarks>
        [JsonProperty("input", NullValueHandling = NullValueHandling.Ignore)]
        public BhashiniTextInput[] TextData;

        /// <summary>
        /// Audio input for STT requests.
        /// </summary>
        /// <remarks>
        /// <seealso href="https://bhashini.gitbook.io/bhashini-apis/pipeline-compute-call/request-payload"/>
        /// </remarks>
        [JsonProperty("audio", NullValueHandling = NullValueHandling.Ignore)]
        public BhashiniAudioInput[] AudioData;

        /// <param name="text">Text input for translation and TTS requests.</param>
        /// <param name="audio">Base64 encoded audio input for STT requests.</param>
        public BhashiniInputData(string text = null, string audio = null)
        {
            if (!string.IsNullOrEmpty(text))
                TextData = new BhashiniTextInput[1]
                {
                    new(text)
                };
            else if (!string.IsNullOrEmpty(audio))
                AudioData = new BhashiniAudioInput[1]
                {
                    new(audio)
                };
        }

#if UTILITIES_ENCODING_WAV_1_0_0_OR_GREATER || UTILITIES_AUDIO_1_0_0_OR_GREATER
        /// <remarks>
        /// Encodes the given <see cref="AudioClip"/> to WAV* or PCM** base64.
        /// <br/><br/>
        /// *<see href="https://openupm.com/packages/com.utilities.encoder.wav/">Utilities.Encoding.Wav</see> and <see href="https://openupm.com/packages/com.utilities.audio/">Utilities.Audio</see> are required.
        /// <br/>
        /// **<see href="https://openupm.com/packages/com.utilities.audio/">Utilities.Audio</see> is required.
        /// </remarks>
        /// <param name="audio">Audio input for STT requests. Defaults to <see cref="BhashiniAudioFormat.Wav"/>.</param>
        /// <param name="audioFormat">The format to encode the audio in.</param>
        public BhashiniInputData(AudioClip audio, BhashiniAudioFormat audioFormat = BhashiniAudioFormat.Wav)
        {
            AudioData = new BhashiniAudioInput[1]
            {
                new(GetBase64Audio(audio, audioFormat))
            };
        }

#pragma warning disable CS1998
        /// <param name="clip">The clip to encode.</param>
        /// <param name="audioFormat">The format to encode the audio in.</param>
        /// <returns>The encoded audio.</returns>
        /// <exception cref="BhashiniAudioIOException">Thrown when an unsupported audio encoding is encountered.</exception>
        private string GetBase64Audio(AudioClip clip, BhashiniAudioFormat audioFormat)
        {
            return audioFormat switch
            {
#if UTILITIES_ENCODING_WAV_1_0_0_OR_GREATER
                BhashiniAudioFormat.Wav => Convert.ToBase64String(clip.EncodeToWav()),
#endif

#if UTILITIES_AUDIO_1_0_0_OR_GREATER
                BhashiniAudioFormat.Pcm => Convert.ToBase64String(clip.EncodeToPCM()),
#endif

                _ => throw new BhashiniAudioIOException($"Format not supported in operation!", audioFormat)
            };
        }
#pragma warning restore CS1998
#endif
    }
}
