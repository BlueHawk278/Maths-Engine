# MathsEngine (Legacy Project)

⚠️ **This project is deprecated and kept for reference only.**

## Migration

Please use the new project structure instead:

- **For CLI usage**: Use `MathsEngine.CLI` - provides the same console interface
- **For library/programmatic usage**: Use `MathsEngine.Core` - contains all calculation logic
- **For WinForms development**: Use `MathsEngine.WinForms` (stub, ready for development)

## Why was this deprecated?

The codebase has been refactored to support multiple user interfaces (CLI and WinForms) while sharing the same core calculation logic. The new structure provides:

1. **Better separation of concerns**: UI code separated from business logic
2. **Code reusability**: Core calculation classes can be used by any interface
3. **Easier testing**: Core logic can be tested independently of UI
4. **Multiple interfaces**: Same calculations available in CLI, WinForms, or any future interface

## Project Structure

The solution now includes:
- `MathsEngine.Core` - Core calculation logic (UI-independent)
- `MathsEngine.CLI` - Console interface application
- `MathsEngine.WinForms` - Windows Forms interface (stub)
- `MathsEngine.Tests` - Unit tests for core logic
- `MathsEngine` - This legacy project (deprecated)

See the main README.md for full documentation.
