## UBhashini

A C# wrapper for the ULCA Bhashini API.

### Installation

This *should* work on any reasonably modern Unity version. Built and tested in Unity 2022.3.29f1.

#### From OpenUPM Through Unity Package Manager

1. Open project settings
2. Select `Package Manager`
3. Add the OpenUPM package registry:
    - Name: `OpenUPM`
    - URL: `https://package.openupm.com`
    - Scope(s)
        - `com.uralstech`
        - *`com.utilities`
4. Open the Unity Package Manager window (`Window` -> `Package Manager`)
5. Change the registry from `Unity` to `My Registries`
6. Add the `UBhashini`, *`Utilities.Encoder.Wav` and *`Utilities.Audio` packages

#### From GitHub Through Unity Package Manager

1. Open the Unity Package Manager window (`Window` -> `Package Manager`)
2. Select the `+` icon and `Add package from git URL...`
3. Paste the UPM branch URL and press enter:
    - `https://github.com/Uralstech/UBhashini.git#upm`

*\*Adding additional dependencies:*<br/>
Follow the steps detailed in the OpenUPM installation method and only install the *`Utilities.Encoder.Wav` and *`Utilities.Audio` packages.

*Optional, but required if you don't want to bother with encoding your AudioClips into Base64 strings manually, or, if you want to use the samples.

### Documentation

See <https://github.com/Uralstech/UBhashini/blob/master/UBhashini/Packages/com.uralstech.ubhashini/Documentation~/README.md>.

---

Made with the help of the [*great documentation by Himanshu Gupta!*](https://bhashini.gitbook.io/bhashini-apis)