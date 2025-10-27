using BepInEx;
using UnityEngine;

namespace ConsoleToggle
{
    [BepInPlugin("com.komi.consoletoggle", "Console Toggle", "1.0.0")]
    public class ConsoleTogglePlugin : BaseUnityPlugin
    {
        void Awake()
        {
            Logger.LogInfo("Console Toggle loaded!");
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.BackQuote))
            {
                var console = GameObject.FindObjectOfType<HBS.DebugConsole.DebugConsole>();

                if (console != null)
                {
                    console.CycleMode();
                    HBS.DebugConsole.RunConsoleScript.Eval("toast \"Console: " + console.mode + "\"");
                }
            }
        }
    }
}