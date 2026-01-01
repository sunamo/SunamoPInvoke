# Target Frameworks

## Current Configuration

Target frameworks: `net10.0;net9.0;net8.0;net7.0`

## Why net7.0 is included

<!-- EN: Explain why this project includes net7.0 in addition to standard frameworks -->
<!-- CZ: Vysvětli proč tento projekt zahrnuje net7.0 kromě standardních frameworků -->

- Some legacy applications still use .NET 7 and require P/Invoke functionality
- WinAPI interop works identically across all .NET versions
- Minimal maintenance cost to support net7.0 alongside newer frameworks

## Requirements for removing net7.0

<!-- EN: What would need to happen to remove net7.0 support -->
<!-- CZ: Co by muselo být splněno aby bylo možné odstranit podporu net7.0 -->

- All dependent applications upgraded to .NET 8 or higher
- .NET 7 reaches end of support (already out of support as of May 2024)
- Confirmed no production usage of net7.0 builds

## Notes

<!-- EN: Additional notes about framework compatibility -->
<!-- CZ: Další poznámky o kompatibilitě frameworků -->

This package can safely support all .NET versions as it only uses basic P/Invoke which hasn't changed between versions.
