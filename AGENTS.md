# AGENTS.md — TheProductiveFamily

Guidance for AI agents (and humans) working in this repository.

## Project

A cross-platform family-organisation app built with **Xamarin.Forms**
for Android and iOS. Shared UI + logic in a .NET Standard 2.0 library,
platform hosts for Android/iOS, English (Canada) + Arabic resources
(right-to-left). Stack: C#, Xamarin.Forms 3.0, .NET Standard 2.0,
`Plugin.Multilingual` for runtime language switching.

## Commands

**No CI.** Build requires Visual Studio / Visual Studio for Mac with
the Xamarin workload — not verifiable in this environment.

| Task | Command |
|---|---|
| Build (Windows/VS) | open `TheProductiveFamily.sln`, build Android/iOS head |
| Build (CLI, if workloads installed) | `msbuild TheProductiveFamily.sln` or `dotnet build` (Xamarin heads may still need VS/MAUI-era tooling) |

Treat all build claims as **unverified** — Xamarin.Forms 3.0 is legacy;
modern .NET SDKs may not build it. The .sln has three projects:
shared `TheProductiveFamily` + `.Android` + `.iOS` heads.

## Architecture

```
TheProductiveFamily.sln
TheProductiveFamily/            shared .NET Standard 2.0 lib
  TheProductiveFamily.csproj    Xamarin.Forms 3.0.0.446417
  App.xaml / App.xaml.cs        app bootstrap, DI/locator
  MainPage.xaml                 shell
  Views/                        CartPage, ProductsListPage,
                                ProductDetailsPage, ServicesListPage,
                                RegistrationPage, SignInPage,
                                CodeVerificationPage,
                                HomeMasterDetailPage (+ .xaml.cs)
  ViewModels/                   BasePageVM.cs, SignInPageVN.cs
                                (note: "VN" typo — keep as-is)
  Models/ Helpers/              domain + utilities
  AppResources.resx / .en-ca / .ar-ar   localisation (ar = RTL)
TheProductiveFamily.Android/    Android head
TheProductiveFamily.iOS/        iOS head
```

Xamarin.Forms MVVM-ish: XAML views + ViewModels + `AppResources` resx
localisation. Only two ViewModels exist — most pages are code-behind;
match the surrounding pattern, don't introduce a VM framework.

## Conventions

- Shared code in `TheProductiveFamily/` (netstandard2.0) — platform
  heads stay thin.
- Localisation via `AppResources.*.resx` — new strings need en-ca +
  ar-ar entries; Arabic is RTL.
- `Plugin.Multilingual` handles runtime language switch — use it, don't
  roll your own.
- XAML + code-behind is the existing style — a full MVVM rewrite is out
  of scope.

## Landmines

- **Default branch is `master`, not `main`.**
- **Xamarin.Forms 3.0 / .NET Standard 2.0 is legacy** — modern .NET
  (net8+) can't build it; needs VS with Xamarin workload or Mono-era
  tooling. Don't "upgrade" casually.
- ViewModel file is `SignInPageVN.cs` (typo for VM) — referenced by
  name; renaming breaks XAML `x:Class`.
- Only 24 .cs files — small app; pages lean on code-behind.
- Android/iOS heads need their respective SDKs — can't build on CI
  (none exists).
- `bin/`/`obj/` may exist locally — generated.

## Agent rules

- Branch from `master`; name branches `feat/*`, `fix/*`, `chore/*`, `docs/*`.
- Docs-only changes still go through a PR; never commit to `master` directly.
- Verify before claiming: state honestly that Xamarin builds need VS +
  workloads — don't claim `dotnet build` works without running it.
- Shared-logic changes go in `TheProductiveFamily/`; keep platform
  heads untouched unless required.
- New user-facing strings → both resx files.
- Keep changes minimal and consistent with surrounding code. No drive-by
  refactors.
- Update AGENTS.md / docs/ARCHITECTURE.md when structure or commands
  change.
