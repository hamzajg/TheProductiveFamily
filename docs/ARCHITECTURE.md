# Architecture — TheProductiveFamily

Current-state map. Descriptive, not aspirational; see `docs/adr/` for why.

## Shape

```
TheProductiveFamily.sln
├── TheProductiveFamily/          shared lib — .NET Standard 2.0,
│   │                             Xamarin.Forms 3.0.0.446417
│   ├── App.xaml(.cs)             bootstrap
│   ├── MainPage.xaml             shell page
│   ├── Views/                    CartPage, ProductsListPage,
│   │                             ProductDetailsPage, ServicesListPage,
│   │                             RegistrationPage, SignInPage,
│   │                             CodeVerificationPage,
│   │                             HomeMasterDetailPage
│   ├── ViewModels/               BasePageVM, SignInPageVN
│   ├── Models/ Helpers/          domain + utilities
│   └── AppResources.{resx,en-ca,ar-ar}   localisation (ar = RTL)
├── TheProductiveFamily.Android/  Android head (Xamarin.Android)
└── TheProductiveFamily.iOS/      iOS head (Xamarin.iOS)
```

## Pattern

Xamarin.Forms shared UI: XAML views + code-behind + a couple of
ViewModels (`BasePageVM`, `SignInPageVN`). `AppResources` resx provides
localised strings; `Plugin.Multilingual` switches language at runtime
(en-ca LTR / ar-ar RTL).

## Flows

- **Auth:** `SignInPage`/`RegistrationPage`/`CodeVerificationPage` →
  verification → `HomeMasterDetailPage`.
- **Catalogue:** `ProductsListPage` → `ProductDetailsPage` → `CartPage`;
  `ServicesListPage` for services.
- **Master-detail:** `HomeMasterDetailPage` + `MasterDetailMasterPage`
  + `MasterDetailsPageMenuItem` implement the detail container.

## Platform heads

Thin Xamarin.Android / Xamarin.iOS projects wiring the shared lib to
each OS — platform services (lifecycle, permissions) live there.

## State

Local app state; no backend in repo — service/product data source is
external or stubbed (check Views code-behind for endpoints).
