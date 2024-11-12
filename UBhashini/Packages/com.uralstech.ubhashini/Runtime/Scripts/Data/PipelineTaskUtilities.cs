using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Uralstech.UBhashini.Exceptions;

namespace Uralstech.UBhashini.Data
{
    public static class PipelineComputationExtensions
    {
        public static BhashiniPipelineTask GetSpeechToTextTask(this BhashiniPipelineData pipelineData, string sourceLanguage = null, BhashiniAudioFormat audioFormat = BhashiniAudioFormat.Wav, int sampleRate = 44100)
        {
            sourceLanguage ??= pipelineData.Language.SourceLanguage;

            return new()
            {
                TaskType = BhashiniPipelineTaskType.SpeechToText,
                Config = new()
                {
                    Language = new()
                    {
                        SourceLanguage = sourceLanguage,
                    },

                    ServiceId = pipelineData.ServiceId,
                    AudioFormat = audioFormat,
                    SamplingRate = sampleRate,
                },
            };
        }

        public static BhashiniPipelineTask GetTextToSpeechTask(this BhashiniPipelineData pipelineData, BhashiniVoiceType voiceType, string sourceLanguage = null)
        {
            sourceLanguage ??= pipelineData.Language.SourceLanguage;

            return new()
            {
                TaskType = BhashiniPipelineTaskType.TextToSpeech,
                Config = new()
                {
                    Language = new()
                    {
                        SourceLanguage = sourceLanguage,
                    },

                    ServiceId = pipelineData.ServiceId,
                    Gender = voiceType,
                },
            };
        }

        public static BhashiniPipelineTask GetTextTranslateTask(this BhashiniPipelineData pipelineData, string sourceLanguage = null, string targetLanguage = null)
        {
            sourceLanguage ??= pipelineData.Language.SourceLanguage;
            targetLanguage ??= pipelineData.Language.TargetLanguage;

            return new()
            {
                TaskType = BhashiniPipelineTaskType.TextTranslation,
                Config = new()
                {
                    Language = new()
                    {
                        SourceLanguage = sourceLanguage,
                        TargetLanguage = targetLanguage,
                    },

                    ServiceId = pipelineData.ServiceId,
                },
            };
        }
    
        public static string GetSpeechToTextResult(this BhashiniComputeResponse pipelineResponse)
        {
            BhashiniTextSource[] sources = pipelineResponse.PipelineResponse[^1].Text;

            return sources.Length == 0 ? null : sources[0].Source;
        }

        public static string GetTextTranslateResult(this BhashiniComputeResponse pipelineResponse)
        {
            BhashiniTextSource[] sources = pipelineResponse.PipelineResponse[^1].Text;

            return sources.Length == 0 ? null : sources[0].Target;
        }

        /// <remarks>
        /// This method only supports <see cref="BhashiniAudioFormat.Wav"/>, <see cref="BhashiniAudioFormat.Mp3"/> and *<see cref="BhashiniAudioFormat.Pcm"/>.
        /// <br/><br/>
        /// *<see href="https://openupm.com/packages/com.utilities.audio/">Utilities.Audio</see> is required.
        /// </remarks>
        public static async Task<AudioClip> GetTextToSpeechResult(this BhashiniComputeResponse pipelineResponse)
        {
            BhashiniComputeResponseData data = pipelineResponse.PipelineResponse[^1];
            if (data.Audio.Length == 0)
                return null;

            byte[] audioData = Convert.FromBase64String(data.Audio[0].AudioContent);

#if UTILITIES_AUDIO_1_0_0_OR_GREATER
            if (data.Config.AudioFormat is BhashiniAudioFormat.Pcm)
            {
                AudioClip pcmClip = AudioClip.Create("Bhashini_TTS_Response-PCM", 0, 0, 0, false);
                Utilities.Audio.AudioClipExtensions.DecodeFromPCM(pcmClip, audioData);

                return pcmClip;
            }
#endif

            AudioType audioType = data.Config.AudioFormat switch
            {
                BhashiniAudioFormat.Wav => AudioType.WAV,
                BhashiniAudioFormat.Mp3 => AudioType.MPEG,

                _ => throw new BhashiniAudioIOException($"The format is not supported by {nameof(UnityWebRequestMultimedia)} and thus is not supported by {nameof(GetTextToSpeechResult)}.", data.Config.AudioFormat),
            };

            string path = Path.Combine(Application.temporaryCachePath, UnityEngine.Random.Range(int.MinValue, int.MaxValue).ToString());

            try
            {
                await File.WriteAllBytesAsync(path, audioData);
            }
            catch (SystemException exception)
            {
                throw new BhashiniAudioIOException("Failed to write to cached Bhashini audio file!", exception);
            }

            using UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip($"file://{path}", audioType);
            UnityWebRequestAsyncOperation operation = request.SendWebRequest();

            while (!operation.isDone)
                await Task.Yield();

            if (request.result != UnityWebRequest.Result.Success)
                throw new BhashiniAudioIOException($"Failed to read cached Bhashini audio file: {request.error} | {request.downloadHandler.text}");

            try
            {
                return DownloadHandlerAudioClip.GetContent(request);
            }
            catch (Exception exception)
            {
                throw new BhashiniAudioIOException("Failed to load cached Bhashini audio file!", exception);
            }
        }
    }
}
