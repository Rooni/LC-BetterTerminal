using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using LCBetterTerminal.Patches;

namespace LCBetterTerminal
{

    [BepInPlugin(modGUID, modName, modVersion)]
    public class BetterTerminal : BaseUnityPlugin
    {
        private const string modGUID = "com.nekorooni.BetterTerminal";
        private const string modName = "Better Terminal";
        private const string modVersion = "0.0.1";

        private readonly Harmony harmony = new Harmony(modGUID);

        public static BetterTerminal instance;

        internal ManualLogSource log;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }

            log = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            log.LogInfo("Yo waddup");

            harmony.PatchAll(typeof(BetterTerminal));
            harmony.PatchAll(typeof(TerminalPatch));
        }
    }
}