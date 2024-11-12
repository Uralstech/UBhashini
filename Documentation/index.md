---
_layout: landing
---

# UBhashini

A C# wrapper for the ULCA Bhashini API.

[![openupm](https://img.shields.io/npm/v/com.uralstech.ubhashini?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.uralstech.ubhashini/)
[![openupm](https://img.shields.io/badge/dynamic/json?color=brightgreen&label=downloads&query=%24.downloads&suffix=%2Fmonth&url=https%3A%2F%2Fpackage.openupm.com%2Fdownloads%2Fpoint%2Flast-month%2Fcom.uralstech.ubhashini)](https://openupm.com/packages/com.uralstech.ubhashini/)

## Installation

This *should* work on any reasonably modern Unity version. Built and tested in Unity 6000.0.26f1 (Unity 6).

# [OpenUPM](#tab/openupm)

1. Open project settings
2. Select `Package Manager`
3. Add the OpenUPM package registry:
    - Name: `OpenUPM`
    - URL: `https://package.openupm.com`
    - Scope(s)
        - `com.uralstech`
        - `com.utilities`\*
4. Open the Unity Package Manager window (`Window` -> `Package Manager`)
5. Change the registry from `Unity` to `My Registries`
6. Add the `UBhashini`, `Utilities.Audio`\* and `Utilities.Encoder.Wav`\* packages

# [Unity Package Manager](#tab/upm)

1. Open the Unity Package Manager window (`Window` -> `Package Manager`)
2. Select the `+` icon and `Add package from git URL...`
3. Paste the UPM branch URL and press enter:
    - `https://github.com/Uralstech/UBhashini.git#upm`
4. Check the instructions for [`Utils.Singleton`](https://uralstech.github.io/Utils.Singleton) to install it.

*Adding additional dependencies:*<br/>
See the installation steps for the [Utilities.Audio](https://github.com/rageAgainstThePixel/com.utilities.audio)\* and [Utilities.Encoder.Wav](https://github.com/rageAgainstThePixel/com.utilities.encoder.wav)\* packages.

# [GitHub Clone](#tab/github)

1. Clone or download the repository from the desired branch (master, preview/unstable)
2. Drag the package folder `UBhashini/UBhashini/Packages/com.uralstech.ubhashini` into your Unity project's `Packages` folder
3. In the `Packages` folder of your project, add the following line to the list in `manifest.json`:
    `"com.uralstech.ubhashini": "1.x.x",`
4. Check the instructions for [`Utils.Singleton`](https://uralstech.github.io/Utils.Singleton) to install it.

*Adding additional dependencies:*<br/>
See the installation steps for the [Utilities.Audio](https://github.com/rageAgainstThePixel/com.utilities.audio)\* and [Utilities.Encoder.Wav](https://github.com/rageAgainstThePixel/com.utilities.encoder.wav)\* packages.

---

\*Optional, but required if you don't want to bother with encoding your AudioClips into Base64 strings manually and for using the samples.

## Preview Versions

Do not use preview versions (i.e. versions that end with "-preview") for production use as they are unstable and untested.

## Documentation

See <https://uralstech.github.io/UBhashini/DocSource/QuickStart.html> or `APIReferenceManual.pdf` and `Documentation.pdf` in the package documentation for the reference manual and tutorial.
