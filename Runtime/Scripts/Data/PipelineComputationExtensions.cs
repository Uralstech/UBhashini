using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Uralstech.UBhashini.Data.Compute;
using Uralstech.UBhashini.Data.Pipeline;
using Uralstech.UBhashini.Exceptions;

namespace Uralstech.UBhashini.Data
{
    /// <summary>
    /// QOL extensions for pipeline computation tasks and results.
    /// </summary>
    public static class PipelineComputationExtensions
    {
        /// <summary>
        /// Converts the current <see cref="BhashiniPipelineTaskConfiguration"/> to an STT <see cref="BhashiniComputeTask"/>.
        /// </summary>
        /// <param name="pipelineData">The current <see cref="BhashiniPipelineTaskConfiguration"/>.</param>
        /// <param name="sourceLanguage">The language of the speech. If <see langword="null"/>, takes it from the <see cref="BhashiniPipelineTaskConfiguration"/>.</param>
        /// <param name="audioFormat">The format the audio should be sent in, defaults to <see cref="BhashiniAudioFormat.Wav"/>.</param>
        /// <param name="sampleRate">The sample rate of the audio, defaults to 44100.</param>
        /// <returns>A configured <see cref="BhashiniComputeTask"/> object.</returns>
        public static BhashiniComputeTask ToSpeechToTextTask(this BhashiniPipelineTaskConfiguration pipelineData, string sourceLanguage = null, BhashiniAudioFormat audioFormat = BhashiniAudioFormat.Wav, int sampleRate = 44100)
        {
            BhashiniComputeTask task = new(BhashiniTask.SpeechToText, pipelineData);
            task.Configuration.AudioFormat = audioFormat;
            task.Configuration.SampleRate = sampleRate;

            if (!string.IsNullOrEmpty(sourceLanguage))
                task.Configuration.Language.Source = sourceLanguage;

            return task;
        }

        /// <summary>
        /// Converts the current <see cref="BhashiniPipelineTaskConfiguration"/> to a TTS <see cref="BhashiniComputeTask"/>.
        /// </summary>
        /// <param name="pipelineData">The current <see cref="BhashiniPipelineTaskConfiguration"/>.</param>
        /// <param name="voiceType">The voice type. If not given, takes the first available one from the <see cref="BhashiniPipelineTaskConfiguration"/>.</param>
        /// <param name="sourceLanguage">The language of the text. If <see langword="null"/>, takes it from the <see cref="BhashiniPipelineTaskConfiguration"/>.</param>
        /// <returns>A configured <see cref="BhashiniComputeTask"/> object.</returns>
        public static BhashiniComputeTask ToTextToSpeechTask(this BhashiniPipelineTaskConfiguration pipelineData, BhashiniVoiceType voiceType = BhashiniVoiceType.Default, string sourceLanguage = null)
        {
            BhashiniComputeTask task = new(BhashiniTask.TextToSpeech, pipelineData);

            if (!string.IsNullOrEmpty(sourceLanguage))
                task.Configuration.Language.Source = sourceLanguage;

            if (voiceType != BhashiniVoiceType.Default)
                task.Configuration.VoiceType = voiceType;

            return task;
        }

        /// <summary>
        /// Converts the current <see cref="BhashiniPipelineTaskConfiguration"/> to a translation <see cref="BhashiniComputeTask"/>.
        /// </summary>
        /// <param name="pipelineData">The current <see cref="BhashiniPipelineTaskConfiguration"/>.</param>
        /// <param name="sourceLanguage">The language of the input text. If <see langword="null"/>, takes it from the <see cref="BhashiniPipelineTaskConfiguration"/>.</param>
        /// <param name="targetLanguage">The language of the output text. If <see langword="null"/>, takes it from the <see cref="BhashiniPipelineTaskConfiguration"/>.</param>
        /// <returns>A configured <see cref="BhashiniComputeTask"/> object.</returns>
        public static BhashiniComputeTask ToTranslateTask(this BhashiniPipelineTaskConfiguration pipelineData, string sourceLanguage = null, string targetLanguage = null)
        {
            BhashiniComputeTask task = new(BhashiniTask.Translation, pipelineData);

            if (!string.IsNullOrEmpty(sourceLanguage))
                task.Configuration.Language.Source = sourceLanguage;

            if (!string.IsNullOrEmpty(targetLanguage))
                task.Configuration.Language.Target = targetLanguage;

            return task;
        }

        /// <summary>
        /// Gets the transcribed text from a <see cref="BhashiniComputeResponse"/>.
        /// </summary>
        /// <param name="pipelineResponse">The current <see cref="BhashiniComputeResponse"/>.</param>
        /// <returns>The transcribed text.</returns>
        public static string GetSpeechToTextResult(this BhashiniComputeResponse pipelineResponse)
        {
            foreach (BhashiniComputeResponseTask result in pipelineResponse.TaskResults)
            {
                if (result.Task == BhashiniTask.SpeechToText)
                    return result.TextOutputs[0].Source;
            }

            return string.Empty;
        }

        /// <summary>
        /// Gets the translated text from a <see cref="BhashiniComputeResponse"/>.
        /// </summary>
        /// <param name="pipelineResponse">The current <see cref="BhashiniComputeResponse"/>.</param>
        /// <returns>The translated text.</returns>
        public static string GetTranslateResult(this BhashiniComputeResponse pipelineResponse)
        {
            foreach (BhashiniComputeResponseTask result in pipelineResponse.TaskResults)
            {
                if (result.Task == BhashiniTask.Translation)
                    return result.TextOutputs[0].Target;
            }

            return string.Empty;
        }

        /// <summary>
        /// Gets the audio from a <see cref="BhashiniComputeResponse"/>.
        /// </summary>
        /// <remarks>
        /// This method only supports <see cref="BhashiniAudioFormat.Wav"/>, <see cref="BhashiniAudioFormat.Mp3"/> and <see cref="BhashiniAudioFormat.Pcm"/>*.
        /// <br/><br/>
        /// *<see href="https://openupm.com/packages/com.utilities.audio/">Utilities.Audio</see> is required.
        /// </remarks>
        /// <param name="pipelineResponse">The current <see cref="BhashiniComputeResponse"/>.</param>
        /// <returns>The synthesized audio.</returns>
        public static async Task<AudioClip> GetTextToSpeechResult(this BhashiniComputeResponse pipelineResponse)
        {
            byte[] audioData = null;
            BhashiniAudioFormat audioFormat = BhashiniAudioFormat.Default;
            foreach (BhashiniComputeResponseTask result in pipelineResponse.TaskResults)
            {
                if (result.Task == BhashiniTask.TextToSpeech)
                {
                    audioData = Convert.FromBase64String(result.AudioOutputs[0].Base64Audio);
                    audioFormat = result.TaskConfiguration.AudioFormat;
                    break;
                }
            }

            if (audioData == null)
                return null;

#if UTILITIES_AUDIO_1_0_0_OR_GREATER
            if (audioFormat is BhashiniAudioFormat.Pcm)
            {
                AudioClip pcmClip = AudioClip.Create("Bhashini_TTS_Response-PCM", 0, 0, 0, false);
                Utilities.Audio.AudioClipExtensions.DecodeFromPCM(pcmClip, audioData);

                return pcmClip;
            }
#endif

            AudioType audioType = audioFormat switch
            {
                BhashiniAudioFormat.Wav => AudioType.WAV,
                BhashiniAudioFormat.Mp3 => AudioType.MPEG,

                _ => throw new BhashiniAudioIOException($"The format is not supported by {nameof(UnityWebRequestMultimedia)} and thus is not supported by {nameof(GetTextToSpeechResult)}.", audioFormat),
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
