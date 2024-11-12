# Quick Start

## Setup

Add an instance of `BhashiniApiManager` to your scene, and set it up with your ULCA user ID and API key, as detailed in the [*Bhashini documentation*](https://bhashini.gitbook.io/bhashini-apis/pre-requisites-and-onboarding).

## Pipelines

As from the [*Bhashini documentation*](https://bhashini.gitbook.io/bhashini-apis):
> ULCA Pipeline is a set of tasks that any specific pipeline supports. For example, any specific pipeline (identified by unique pipeline ID) can support the following:
> 
> - only ASR (Speech To Text)
> - only NMT (Translate)
> - only TTS
> - ASR + NMT
> - NMT + TTS
> - ASR + NMT + TTS
> 
> Our R&D institutes can create pipelines using any of the available models on ULCA. 

Basically, computation (STT, TTS, Translate) is done on a "pipeline". A "pipeline" is set to support a list of tasks, in a defined order, like:

- (input: audio) STT -> Translate (output: text)
- (input: text) Translate -> TTS (output: audio)

In the given examples:

- Case 1 (STT -> Translate): From the given audio clip, the STT model computes text, which is sent automatically to the translate model, and text is returned.
- Case 2 (Translate -> TTS): From the given text, the translate model computes text, which is sent automatically to the TTS model, and audio is returned.

You can have any combination of these tasks, or just individual ones. You can even have tasks like:

- STT -> Translate -> TTS!

### Code

So, before we do any computation, we have to set up our pipelines:

```csharp
using Uralstech.UBhashini;
using Uralstech.UBhashini.Data;

// This example shows a pipeline configured for a set of tasks which will receive spoken English audio
// as input, transcribe and translate it to Hindi, and finally convert the text to spoken Hindi audio.

BhashiniPipelineConfigResponse response = await BhashiniApiManager.Instance.ConfigurePipeline(new BhashiniPipelineTask[]
{
    BhashiniPipelineTask.GetConfigurationTask(BhashiniPipelineTaskType.SpeechToText, "en"), // Here, "en" is the source language.
    BhashiniPipelineTask.GetConfigurationTask(BhashiniPipelineTaskType.TextTranslation, "en", "hi"), // Here, "en" is still the source language, but "hi" is the target language.
    BhashiniPipelineTask.GetConfigurationTask(BhashiniPipelineTaskType.TextToSpeech, "hi"), // Here, the source language is "hi".
});
```

The Bhashini API follows the [*ISO-639*](https://www.loc.gov/standards/iso639-2/php/code_list.php) standard for language codes.

The API wrapper class, `BhashiniApiManager`, usually returns `null` in if a request fails. Check the debug window or logs for errors in such cases.

Now, we store the computation inference data in variables:

```csharp
BhashiniPipelineInferenceData _inferenceData = response.PipelineEndpoint;

BhashiniPipelineData _sttData = response.PipelineResponseConfig[0].Data[0];
BhashiniPipelineData _translateData = response.PipelineResponseConfig[1].Data[0];
BhashiniPipelineData _ttsData = response.PipelineResponseConfig[2].Data[0];
```

Here, as we specified the expected source and target languages for each task in the pipeline, it is very likely that the `Data` array in the `PipelineResponseConfig` elements will only contain one `BhashiniPipelineData` object.
This may not always be the case, so, it is recommended to check the array of configurations for the desired model(s).
The order of `PipelineResponseConfig` is based on the order of the tasks array in the input for `ConfigurePipeline`.

## Computation

Now that we have the inference data and pipelines configured, we can go straight into computation.

### Code

```csharp
_audioClip = ...
_audioSource = ...

BhashiniPipelineTask[] tasks = new BhashiniPipelineTask[]
{
    _sttData.GetSpeechToTextTask(),
    _translateData.GetTextTranslateTask(),
    _ttsData.GetTextToSpeechTask(BhashiniVoiceType.Male),
};

BhashiniComputeResponse response = await BhashiniApiManager.Instance.ComputeOnPipeline(_inferenceData, tasks, audioSource: _audioClip);

AudioClip result = await response.GetTextToSpeechResult();
_audioSource.PlayOneShot(result);
```

`ComputeOnPipeline` accepts three optional parameter:
- `textSource` - This is for text-input-based tasks, like Translate or TTS.
- `audioSource` - This is for audio-input-based tasks, like STT. This parameter also requires the `Utilities.Encoder.Wav` and `Utilities.Audio` packages.
- `rawBase64AudioSource` - This is also for audio-input-based tasks, but takes the raw Base64-encoded audio data. You will have to encode your audio manually.

You must only provide one of the parameters at a time, based on the first task given to the pipeline.

Also, `GetSpeechToTextTask` takes an optional `sampleRate` argument. By default, it is 44100, but make sure it matches with your audio data.

`BhashiniComputeResponse` contains three utility functions to help extract the actual text or audio response:
- `GetSpeechToTextResult`
- `GetTextTranslateResult` and
- `GetTextToSpeechResult`

You should call them based on the last task in the pipeline's task list. If your pipeline's last task is STT, use `GetSpeechToTextResult`.
If the last task is translate, use `GetTextTranslateResult`.

`ComputeOnPipeline` and `GetTextToSpeechResult` will throw `BhashiniAudioIOException` errors if they encounter an unsupported format.

---

And that's it! You've learnt how to use the Bhashini API in Unity!
