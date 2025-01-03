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

using UnityEngine;
using UnityEngine.UI;
using Uralstech.UBhashini;
using Uralstech.UBhashini.Data;
using Uralstech.UBhashini.Data.Compute;
using Uralstech.UBhashini.Data.Pipeline;

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

    private BhashiniPipelineResponse _pipelines;

    private BhashiniVoiceType _voiceType;
    private int _sampleRate;

    protected void Awake()
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

        _pipelines = await BhashiniManager.Instance.ConfigurePipeline(
            new BhashiniPipelineRequestTask(BhashiniTask.SpeechToText, _sourceLanguage.text),
            new BhashiniPipelineRequestTask(BhashiniTask.Translation, _sourceLanguage.text, _targetLanguage.text),
            new BhashiniPipelineRequestTask(BhashiniTask.TextToSpeech, _targetLanguage.text)
        );

        if (_pipelines is null)
        {
            Debug.LogError("Could not configure pipline!");
            return;
        }

        Debug.Log("Pipeline configured!");
    }

    public void SetVoiceType(int voiceType)
    {
        _voiceType = (BhashiniVoiceType)voiceType;
    }

    private async void DoAsrTranslateTts()
    {
        Debug.Log("Doing computation...");

        BhashiniInputData input = new(_audioClip);

        BhashiniComputeResponse response = await BhashiniManager.Instance.ComputeOnPipeline(_pipelines.InferenceEndpoint, input,
            _pipelines.SpeechToTextConfiguration.First.ToSpeechToTextTask(sampleRate: _sampleRate),
            _pipelines.TranslateConfiguration.First.ToTranslateTask(),
            _pipelines.TextToSpeechConfiguration.First.ToTextToSpeechTask(_voiceType)
        );

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
