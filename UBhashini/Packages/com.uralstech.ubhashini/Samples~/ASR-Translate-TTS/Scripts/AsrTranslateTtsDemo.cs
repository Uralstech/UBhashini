using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;
using Uralstech.UBhashini.Data;

namespace Uralstech.UBhashini.Demo
{
    public class AsrTranslateTtsDemo : MonoBehaviour
    {
        private const string StartRecordingText = "Start Recording";
        private const string StopRecordingText = "Stop Recording";

        [SerializeField] private AudioSource _audioSource;

        [SerializeField] private Text _recordingButtonText;

        [SerializeField] private InputField _sourceLanguage;
        [SerializeField] private InputField _targetLanguage;

        private AudioClip _audioClip;
        private string _microphoneDevice;

        private BhashiniPipelineData _sttData;
        private BhashiniPipelineData _translateData;
        private BhashiniPipelineData _ttsData;
        private BhashiniPipelineInferenceData _inferenceData;

        private BhashiniVoiceType _voiceType;

        private void Awake()
        {
            _recordingButtonText.text = StartRecordingText;

            SetupPipelines();
        }

        public void ToggleRecording()
        {
            if (string.IsNullOrEmpty(_microphoneDevice) || !Microphone.IsRecording(_microphoneDevice))
            {
                _recordingButtonText.text = StopRecordingText;

                _microphoneDevice = Microphone.devices[0];
                _audioClip = Microphone.Start(_microphoneDevice, true, 30, 44100);

                Debug.Log("Recording started.");
            }
            else
            {
                _recordingButtonText.text = StartRecordingText;
                Microphone.End(_microphoneDevice);

                DoAsrTranslateTts();

                Debug.Log("Recording stopped.");
            }
        }

        public async void SetupPipelines()
        {
            Debug.Log("Setting up pipelines.");

            BhashiniPipelineConfigResponse response = await BhashiniApiManager.Instance.ConfigurePipeline(new BhashiniPipelineTask[]
            {
                BhashiniPipelineTask.GetConfigurationTask(BhashiniPipelineTaskType.SpeechToText, _sourceLanguage.text),
                BhashiniPipelineTask.GetConfigurationTask(BhashiniPipelineTaskType.TextTranslation, _sourceLanguage.text, _targetLanguage.text),
                BhashiniPipelineTask.GetConfigurationTask(BhashiniPipelineTaskType.TextToSpeech, _targetLanguage.text),
            });

            if (response is null)
            {
                Debug.LogError("Could not configure pipline!");
                return;
            }

            _inferenceData = response.PipelineEndpoint;

            _sttData = response.PipelineResponseConfig[0].Data[0];
            _translateData = response.PipelineResponseConfig[1].Data[0];
            _ttsData = response.PipelineResponseConfig[2].Data[0];

            Debug.Log("Pipeline configured!");
        }

        public void SetVoiceType(int voiceType)
        {
            _voiceType = (BhashiniVoiceType)voiceType;
        }

        private async void DoAsrTranslateTts()
        {
            Debug.Log("Doing computation...");

            BhashiniPipelineTask[] tasks = new BhashiniPipelineTask[]
            {
                _sttData.GetSpeechToTextTask(),
                _translateData.GetTextTranslateTask(),
                _ttsData.GetTextToSpeechTask(_voiceType),
            };

            BhashiniComputeResponse response = await BhashiniApiManager.Instance.ComputeOnPipeline(_inferenceData, tasks, audioSource: _audioClip);

            if (response is null)
            {
                Debug.LogError("Pipeline computation failed!");
                return;
            }

            AudioClip result = await response.GetTextToSpeechResult();
            if (result == null)
            {
                Debug.LogError("Pipeline computation failed, could not get audio!");
                return;
            }

            Debug.Log("Computation done.");
            _audioSource.PlayOneShot(result);
        }
    }
}
