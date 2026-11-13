# ADR 0001 — Initial architecture

Date: 2026-11-13 (baseline recorded retroactively)
Status: accepted (describes what is built)

## Context

A family-organisation app needed on Android + iOS with Arabic/English
support — built on Xamarin.Forms during its mainstream era.

## Decisions

1. **Xamarin.Forms shared UI.** One XAML/codebase for Android + iOS,
   thin platform heads. Rationale: 2020-era standard for cross-platform
   mobile; avoids duplicating UI.
2. **.NET Standard 2.0 shared lib.** `TheProductiveFamily` targets
   netstandard2.0 — consumable by both heads. Rationale: Xamarin.Forms
   3.0's required target.
3. **resx localisation + Plugin.Multilingual.** `AppResources` in
   en-ca + ar-ar; runtime language switch. Rationale: Arabic RTL is a
   first-class requirement.
4. **Lightweight MVVM.** XAML views + a couple of ViewModels
   (`BasePageVM`, `SignInPageVN`); most pages use code-behind.
   Rationale: proportional to app size — full MVVM would be ceremony.
5. **Xamarin.Forms 3.0, frozen.** Version pinned at
   3.0.0.446417. Rationale: era-appropriate; upgrades deferred.

## Consequences / open questions

- **Legacy stack** — Xamarin.Forms 3.0 needs VS/Xamarin workload or
  Mono-era tooling; modern .NET can't build it. Migration (to .NET MAUI
  or native) is a future ADR.
- No CI — builds are manual/IDE-only; verification is limited.
- `SignInPageVN.cs` filename typo is load-bearing (XAML `x:Class`) —
  don't "fix" without updating references.
- Backend/data source is not in repo — contract is implicit.
