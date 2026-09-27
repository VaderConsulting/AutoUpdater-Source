# AutoUpdater-Source

Desktop B4X Object Browser that loads and displays B4A, B4i, B4J and B4R API information (based on B4A Object Browser v3.2.5.14). The tree also vendors AutoUpdater.NET so the browser can check for updates. Vader Consulting assembly metadata (2012-2020). ClickOnce `.pfx` keys are gitignored and were not published.

**Source last updated:** 2026-04-17  
**Language:** C#  
**Target:** .NET Framework 4.8 (browser); net8.0-windows / net10.0-windows7.0 (AutoUpdater.NET)  
**Output:** WinExe + library

## Solution structure

| Project | Language | Type | Purpose |
|---------|----------|------|---------|
| `B4x Browser` | C# | WinExe | B4A/B4i/B4J/B4R API object browser (based on B4A Object Browser v3.2.5.14) |
| `AutoUpdater.NET` | C# | Library | Embedded AutoUpdater.NET client (Tavlikos / community AutoUpdater.NET) |
| `AutoUpdaterTest` | C# | WinExe | AutoUpdater.NET sample app (`net8.0-windows`) |
| `AutoUpdater.Tests` | C# | test | AutoUpdater.NET tests (`net10.0-windows7.0`) |

## How to open

Open `B4x Browser.csproj` in Visual Studio for the object browser. AutoUpdater.NET projects are under `AutoUpdater.NET/`.

## Requirements

- Visual Studio 2013 or later, .NET 10.0, .NET 8.0, .NET Framework 4.8

## Attribution and provenance

my working copy from Development folder `AutoUpdater Source`.
- **Assembly company:** Vader Consulting
- **Based on:** B4A Object Browser v3.2.5.14
- **Vendored:** AutoUpdater.NET (original authors; see that project's metadata under `AutoUpdater.NET/`)
- Historical Dev archive (`AutoUpdater Source`). `.pfx` signing keys were excluded from git.

## License

MIT © 2026 VaderConsulting for Dave's B4x Browser code. See `LICENSE`. AutoUpdater.NET remains under its original licence; see `THIRD_PARTY_NOTICES.md`.
