# TheProductiveFamily

A cross-platform mobile app for organising family life, built with
Xamarin.Forms for Android and iOS.

## What it does

`TheProductiveFamily` is a Xamarin.Forms application with a shared UI and
platform-specific hosts. The shared project ships English (Canada) and Arabic
resources, so the UI can run right-to-left for Arabic users.

## Tech stack

- C# / Xamarin.Forms 3.0
- .NET Standard 2.0 shared library
- Android (`TheProductiveFamily.Android`) and iOS (`TheProductiveFamily.iOS`) hosts
- `Plugin.Multilingual` for runtime language switching

## Project layout

```
TheProductiveFamily/            # shared Xamarin.Forms app, views, view models, resources
TheProductiveFamily.Android/    # Android host
TheProductiveFamily.iOS/        # iOS host
TheProductiveFamily.sln
```

## Building

Building requires Visual Studio (Windows or macOS) with the Xamarin workload,
or `msbuild` with Xamarin installed. The shared library targets
`netstandard2.0`.

```bash
msbuild TheProductiveFamily.sln /p:Configuration=Debug
```

The Android host targets Android API 27 (Xamarin.Android `v8.1`); the iOS host
needs Xcode.

## Localisation

`AppResources.resx` is the neutral resource file, with `AppResources.en-ca.resx`
and `AppResources.ar-ar.resx` for English (Canada) and Arabic. Add new strings
to all three.

## Status

Xamarin.Forms 3.0 is out of support (Xamarin.Forms was superseded by .NET MAUI).
Running this today needs an older Visual Studio/Xamarin toolchain; a future
modernization would be a .NET MAUI migration.
