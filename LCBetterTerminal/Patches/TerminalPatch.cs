using HarmonyLib;

namespace LCBetterTerminal.Patches
{
    [HarmonyPatch(typeof(Terminal))]
    internal class TerminalPatch
    {
        [HarmonyPatch("BeginUsingTerminal")]
        [HarmonyPrefix]
        public static void OpenTerminal(Terminal __instance)
        {
            BetterTerminal.instance.log.LogInfo("Begin terminal patch");
            __instance.terminalUIScreen.gameObject.SetActive(true);
        }

        [HarmonyPatch("QuitTerminal")]
        [HarmonyPrefix]
        public static void CloseTerminal(Terminal __instance)
        {
            BetterTerminal.instance.log.LogInfo("Close terminal patch");
            __instance.terminalUIScreen.gameObject.SetActive(false);
        }
    }
}
