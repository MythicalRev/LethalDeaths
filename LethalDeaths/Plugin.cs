using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LethalDeaths
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class Plugin : BaseUnityPlugin
    {
        private const string modGUID = "MythicalRev.LethalDeaths";
        private const string modName = "LethalDeaths";
        private const string modVersion = "1.0.2";

        private readonly Harmony harmony = new Harmony(modGUID);

        internal static Plugin Instance;

        public static ManualLogSource mls;

        //internal static int deathcount = 10;
        internal static int maxdeaths = 1;

        // Configs

        public static ConfigEntry<int> deathcountConfSF1;
        public static ConfigEntry<int> deathcountConfSF2;
        public static ConfigEntry<int> deathcountConfSF3;

        public static ConfigEntry<bool> modEnabledSF1;
        public static ConfigEntry<bool> modEnabledSF2;
        public static ConfigEntry<bool> modEnabledSF3;
        //public static ConfigEntry<bool> weightIncreaseToggle;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("LethalDeaths Enabled");

            harmony.PatchAll(typeof(Plugin));
            harmony.PatchAll(typeof(Patches.PlayerControllerBPatch));
            harmony.PatchAll(typeof(Patches.StartOfRoundPatch));
            harmony.PatchAll(typeof(Patches.SaveFileUISlotPatch));
            mls.LogInfo("LethalDeaths Patched");
            setupConfigs();
        }

        private void setupConfigs()
        {
            //weightIncreaseToggle = Config.Bind("Config", "Weight Increase Enabled", true, "Does Your Weight Increase on Death");

            deathcountConfSF1 = Config.Bind("Save Data", "Death Value File 1", 10, "Number Of Deaths Left, MIN 10 - MAX 1");
            deathcountConfSF2 = Config.Bind("Save Data", "Death Value File 2", 10, "Number Of Deaths Left, MIN 10 - MAX 1");
            deathcountConfSF3 = Config.Bind("Save Data", "Death Value File 3", 10, "Number Of Deaths Left, MIN 10 - MAX 1");
        }
    }
}