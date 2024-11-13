using UnityEngine;
using UnityEngine.UI;
using Uralstech.UBhashini;
using Uralstech.UBhashini.Data;
using Uralstech.UBhashini.Data.Pipeline;
using Uralstech.UBhashini.Data.Compute;

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

    private BhashiniPipelineTaskConfiguration _sttData;
    private BhashiniPipelineTaskConfiguration _translateData;
    private BhashiniPipelineTaskConfiguration _ttsData;
    private BhashiniPipelineInferenceEndpoint _inferenceData;

    private BhashiniVoiceType _voiceType;
    private int _sampleRate;

    private void Awake()
    {
        _recordingButtonText.text = StartRecordingText;
        
        AudioConfiguration configuration = AudioSettings.GetConfiguration();
        _sampleRate = configuration.sampleRate;

        SetupPipelines();
    }

    public void ToggleRecording()
    {
        if (string.IsNullOrEmpty(_microphoneDevice) || !Microphone.IsRecording(_microphoneDevice))
        {
            _recordingButtonText.text = StopRecordingText;

            _microphoneDevice = Microphone.devices[0];
            _audioClip = Microphone.Start(_microphoneDevice, true, 30, _sampleRate);

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

        BhashiniPipelineResponse response = await BhashiniManager.Instance.ConfigurePipeline(new BhashiniPipelineRequestTask[]
        {
            new BhashiniPipelineRequestTask(BhashiniPipelineTaskType.SpeechToText, _sourceLanguage.text),
            new BhashiniPipelineRequestTask(BhashiniPipelineTaskType.Translation, _sourceLanguage.text, _targetLanguage.text),
            new BhashiniPipelineRequestTask(BhashiniPipelineTaskType.TextToSpeech, _targetLanguage.text),
        });

        if (response is null)
        {
            Debug.LogError("Could not configure pipline!");
            return;
        }

        _inferenceData = response.InferenceEndpoint;

        _sttData = response.PipelineConfigurations[0].Configurations[0];
        _translateData = response.PipelineConfigurations[1].Configurations[0];
        _ttsData = response.PipelineConfigurations[2].Configurations[0];

        Debug.Log("Pipeline configured!");
    }

    public void SetVoiceType(int voiceType)
    {
        _voiceType = (BhashiniVoiceType)voiceType;
    }

    private async void DoAsrTranslateTts()
    {
        Debug.Log("Doing computation...");

        BhashiniComputeTask[] tasks = new BhashiniComputeTask[]
        {
            _sttData.ToSpeechToTextTask(sampleRate: _sampleRate),
            _translateData.ToTranslateTask(),
            _ttsData.ToTextToSpeechTask(_voiceType),
        };

        BhashiniComputeResponse response = await BhashiniManager.Instance.ComputeOnPipeline(_inferenceData, tasks, audioSource: _audioClip);

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
