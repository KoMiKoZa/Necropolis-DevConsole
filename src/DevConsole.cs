using System;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using HBS;
using HBS.DebugConsole;
using UnityEngine;

namespace KoMiKoZa.Necropolis.DevConsole
{
    [BepInPlugin(GUID, NAME, VERSION)]
    public class DevConsolePlugin : BaseUnityPlugin
    {
        private const string GUID = "komikoza.necropolis.devconsole";
        private const string NAME = "Dev Console";
        private const string VERSION = "1.0.1";

        internal static new ManualLogSource Logger;
        internal static ConfigEntry<bool> ModEnabled;
        internal static ConfigEntry<bool> DebugMode;
        internal static ConfigEntry<KeyCode> ToggleKey;
        internal static ConfigEntry<ConsoleMode> PreferredMode;

        private static DebugConsole cachedConsole;

        void Awake()
        {
            Logger = base.Logger;

            ModEnabled = Config.Bind("General", "ModEnabled", true,
                "Enable or disable this mod");

            DebugMode = Config.Bind("Debug", "DebugMode", false,
                "Enable debug logging");

            ToggleKey = Config.Bind("Controls", "ToggleKey", KeyCode.BackQuote,
                "Key to toggle the console (default is ` / tilde key)");

            PreferredMode = Config.Bind("Console", "PreferredMode", ConsoleMode.Mini,
                "Console display mode when visible (Icon = 0, Mini = 1, LogWindow = 2, Filtered = 3)");

            if (!ModEnabled.Value)
            {
                Logger.LogInfo(string.Format("[{0}] Disabled", NAME));
                return;
            }

            try
            {
                var harmony = new Harmony(GUID);
                harmony.PatchAll();
                Logger.LogInfo("================================================");
                Logger.LogInfo(string.Format("[{0}] v{1} loaded!", NAME, VERSION));
                Logger.LogInfo(string.Format("Console toggle key: {0}", ToggleKey.Value));
                Logger.LogInfo("================================================");
            }
            catch (Exception ex)
            {
                Logger.LogError(string.Format("[{0}] Failed to load: {1}", NAME, ex));
            }
        }

        void Update()
        {
            try
            {
                if (!ModEnabled.Value) return;

                if (Input.GetKeyDown(ToggleKey.Value))
                {
                    if (cachedConsole == null)
                    {
                        cachedConsole = LazySingletonBehavior<DebugConsole>.Instance;
                    }

                    if (cachedConsole == null)
                    {
                        if (DebugMode.Value)
                        {
                            Logger.LogWarning("[DEV CONSOLE] Console instance not found");
                        }
                        return;
                    }

                    ToggleConsole();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("[DEV CONSOLE] Update error: " + ex);
            }
        }

        private static void ToggleConsole()
        {
            try
            {
                DebugConsole.WindowMode currentMode = cachedConsole.mode;

                if (currentMode == DebugConsole.WindowMode.Hidden)
                {
                    // Console is hidden, show it in preferred mode (hot-reloadable from config)
                    DebugConsole.WindowMode modeToSet = ConvertToWindowMode(PreferredMode.Value);
                    cachedConsole.SetMode(modeToSet);

                    if (DebugMode.Value)
                    {
                        Logger.LogInfo(string.Format("[DEV CONSOLE] Showing console in mode: {0}", modeToSet));
                    }
                }
                else
                {
                    // Console is visible, hide it
                    cachedConsole.SetMode(DebugConsole.WindowMode.Hidden);

                    if (DebugMode.Value)
                    {
                        Logger.LogInfo(string.Format("[DEV CONSOLE] Hiding console (was in mode: {0})", currentMode));
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("[DEV CONSOLE] Toggle error: " + ex);
            }
        }

        private static DebugConsole.WindowMode ConvertToWindowMode(ConsoleMode mode)
        {
            switch (mode)
            {
                case ConsoleMode.Icon:
                    return DebugConsole.WindowMode.Icon;
                case ConsoleMode.Mini:
                    return DebugConsole.WindowMode.Mini;
                case ConsoleMode.LogWindow:
                    return DebugConsole.WindowMode.LogWindow;
                case ConsoleMode.Filtered:
                    return DebugConsole.WindowMode.Filtered;
                default:
                    return DebugConsole.WindowMode.Mini;
            }
        }
    }

    public enum ConsoleMode
    {
        Icon = 0,
        Mini = 1,
        LogWindow = 2,
        Filtered = 3
    }
}
