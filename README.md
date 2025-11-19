# Dev Console

### A simple mod for Necropolis that adds a configurable hotkey to toggle the developer console.

---
### 💡 Notice 1
- It is recommended to use [Mod Config Menu](https://thunderstore.io/c/necropolis/p/KoMiKoZa/ModConfigMenu/) to edit and hot-reload configuration changes in-game without restarting. Not required, but convenient.

---
### 💡 Notice 2
- For a full list of console commands, please see [Necropolis Research - Console Data](https://github.com/zettiverse/necropolis-research/blob/master/console.md) .

---

## Features

### Configurable Hotkey - Toggle the console with any key (default: ` / Backtick).
**If it doesn't appear upon backtick/backquote press, then simply rebind the key or try this:**
- Danish keyboards you just need to use the æ key
- French keyboard it's ù (near M)
- German keyboards its ö, (right to l)
- Swiss keyboard it's ¨ (left to Enter)
- Spanish Keyboard it's ñ
- Norwegian keyboard it's Ø
- Portuguese keyboard it's ç (next to the "L" key)
- Swedish keyboard it's Ö, (next to L)
- Finnish keyboard it's Ö
- Estonian keyboard it's Ü
- Hungarian keyboard it is ö (right to 9)
- Italian keyboard it's ò (right to L)
- According to darkfender666 Italian can be also @
- **Display Mode Selection**: Choose your preferred console display mode (Icon, Mini, LogWindow, or Filtered)
- **Hot-Reloadable Config**: Change settings in-game with mod config managers - no restart needed

## Installation

### Manual

1. Install [Necropolis BepInEx 5.4.2304 or later](https://thunderstore.io/c/necropolis/p/BepInEx/BepInExPack_Necropolis/)
2. Download and extract this mod into `Necropolis/BepInEx/plugins/`
3. Run the game

## Configuration

The configuration file is located at `BepInEx/config/komikoza.necropolis.devconsole.cfg`

### Available Settings

**General**
- `ModEnabled` - Enable or disable this mod (default: `true`)

**Debug**
- `DebugMode` - Enable debug logging (default: `false`)

**Controls**
- `ToggleKey` - Key to toggle the console (default: `BackQuote`)
  - See [Unity KeyCode reference](https://docs.unity3d.com/ScriptReference/KeyCode.html) for all available keys

**Console**
- `PreferredMode` - Console display mode when visible (default: `Mini`)
  - `0` = Icon (minimal UI icon)
  - `1` = Mini (compact input box)
  - `2` = LogWindow (full log window)
  - `3` = Filtered (filtered log view)

## Usage

1. Press ` (or your configured key) to show the console
2. Press again to hide it
3. The console will always open in your configured `PreferredMode`
4. Change `PreferredMode` in-game and it applies immediately on next toggle

## Compatibility

- **BepInEx**: 5.4.21+
- **Steam version of Necropolis: Brutal Edition**
- Works with mod configuration managers for in-game settings

## Changelog

### 1.0.1
- Initial Thunderstore release (previous version was shared in Necropolis Discord)|
- Removed console mode shuffling functionality
- Configurable console toggle hotkey
- Selectable display modes
- Hot-reloadable configuration

## Credits

**Author**: KoMiKoZa  
**Discord**: komikoza

## Support

- **Website**: [Mod Documentation](https://komikoza.github.io/necropolis/mods/dev-console.html)
- **Source Code**: [GitHub](https://github.com/KoMiKoZa/Necropolis-DevConsole)
- **Issues**: Report bugs on [Discord](https://discord.gg/2233yFQ) or [GitHub Issues](https://github.com/KoMiKoZa/Necropolis-DevConsole/issues)
