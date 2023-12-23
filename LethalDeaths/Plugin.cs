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
        private const string modVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        internal static Plugin Instance;

        public static ManualLogSource mls;

        internal static int deathcount = 10;
        internal static int maxdeaths = 1;

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
            mls.LogInfo("LethalDeaths Patched");
        }
    }
}