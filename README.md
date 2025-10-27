# Console Toggle Mod

A BepInEx plugin that enables console toggling in-game using the backtick/tilde key.

## Features
- Toggle console with ` (backtick/tilde) key
- Cycles through all console modes: Hidden → Icon → Mini → LogWindow → Filtered
- In-game toast notifications showing current mode

## Requirements
- BepInEx 5.x (Mono, x86)
- .NET Framework 3.5

## Installation

### Manual Installation
1. Install [BepInEx 5.x](https://github.com/BepInEx/BepInEx/releases) for Necropolis
2. Download the latest release from the [Releases](../../releases) page
3. Extract `ConsoleToggle.dll` to `BepInEx/plugins/` folder
4. Launch the game

## Usage
Press ` (backtick/tilde key) to cycle through console modes. A toast notification will display the current mode.

## Building from Source

### Prerequisites
- Visual Studio 2012 or later
- .NET Framework 3.5

### Steps
1. Clone the repository
2. Add references to:
   - `BepInEx/core/BepInEx.dll`
   - `Necropolis_Data/Managed/UnityEngine.dll`
   - `Necropolis_Data/Managed/Assembly-CSharp.dll`
3. Build the project
4. Output DLL will be in `bin/Debug/` or `bin/Release/`

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Credits
Created by KoMiKoZa with AI assistance (Claude)
