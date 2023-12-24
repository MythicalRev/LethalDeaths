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
        private const string modVersion = "1.0.3";

        private readonly Harmony harmony = new Harmony(modGUID);

        internal static Plugin Instance;

        public static ManualLogSource mls;

        internal static int maxdeaths = 1;

        // Configs

        public static ConfigEntry<int> deathcountConfSF1;
        public static ConfigEntry<int> deathcountConfSF2;
        public static ConfigEntry<int> deathcountConfSF3;

        public static ConfigEntry<float> deathamountConfSF1;
        public static ConfigEntry<float> deathamountConfSF2;
        public static ConfigEntry<float> deathamountConfSF3;

        public static ConfigEntry<float> deathspeedConfSF1;
        public static ConfigEntry<float> deathspeedConfSF2;
        public static ConfigEntry<float> deathspeedConfSF3;

        public static ConfigEntry<bool> weightIncreaseToggle;
        public static ConfigEntry<bool> healthDecreaseToggle;
        public static ConfigEntry<bool> sprintAmoundDecToggle;

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
            harmony.PatchAll(typeof(Patches.DeleteFilePatch));
            mls.LogInfo("LethalDeaths Patched");
            setupConfigs();
        }

        private void setupConfigs()
        {
            weightIncreaseToggle = Config.Bind("Config", "Weight Increase Enabled", true, "Does Your Weight Increase on Death");
            healthDecreaseToggle = Config.Bind("Config", "Health Decrease Enabled", true, "Does Your Health Decrease on Death");
            sprintAmoundDecToggle = Config.Bind("Config", "Sprint Decrease Enabled", true, "Does Your Sprint Decrease on Death");

            deathcountConfSF1 = Config.Bind("Save Data", "Death Value File 1", 10, "Number Of Deaths Left, MIN 10 - MAX 1");
            deathcountConfSF2 = Config.Bind("Save Data", "Death Value File 2", 10, "Number Of Deaths Left, MIN 10 - MAX 1");
            deathcountConfSF3 = Config.Bind("Save Data", "Death Value File 3", 10, "Number Of Deaths Left, MIN 10 - MAX 1");

            deathamountConfSF1 = Config.Bind("Save Data", "Death Amount File 1", 0f, "Death Count Number, Min 0 - Max 100");
            deathamountConfSF2 = Config.Bind("Save Data", "Death Amount File 2", 0f, "Death Count Number, Min 0 - Max 100");
            deathamountConfSF3 = Config.Bind("Save Data", "Death Amount File 3", 0f, "Death Count Number, Min 0 - Max 100");

            deathspeedConfSF1 = Config.Bind("Save Data", "Death Amount File Sprint 1", 1f, "Death Count Number Sprint, Min 1 - Max 0");
            deathspeedConfSF2 = Config.Bind("Save Data", "Death Amount File Sprint 2", 1f, "Death Count Number Sprint, Min 1 - Max 0");
            deathspeedConfSF3 = Config.Bind("Save Data", "Death Amount File Sprint 3", 1f, "Death Count Number Sprint, Min 1 - Max 1000");
        }
    }
}