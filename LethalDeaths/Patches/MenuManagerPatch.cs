using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LethalDeaths.Patches
{
    [HarmonyPatch(typeof(MenuManager))]
    class MenuManagerPatch
    {
        private static string fileString;
        private static int fileNum;

        [HarmonyPatch("Awake")]
        [HarmonyPostfix]
        public static void setupDelReset()
        {
            switch (fileNum)
            {
                case 0:
                    Plugin.mls.LogInfo("LCSaveFile1");
                    fileString = "LCSaveFile1";
                    break;
                case 1:
                    Plugin.mls.LogInfo("LCSaveFile2");
                    fileString = "LCSaveFile2";
                    break;
                case 2:
                    Plugin.mls.LogInfo("LCSaveFile3");
                    fileString = "LCSaveFile3";
                    break;
                default:
                    Plugin.mls.LogInfo("LCSaveFile1");
                    fileString = "LCSaveFile1";
                    break;
            }
        }

        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        public static void resetDeathOnFileDel()
        {
            if (!ES3.FileExists(fileString))
            {
                if (fileString == "LCSaveFile1")
                {
                    Plugin.deathcountConfSF1.Value = 10;
                    Plugin.deathamountConfSF1.Value = 0f;
                    Plugin.deathspeedConfSF1.Value = 1f;
                }
                else if (fileString == "LCSaveFile2")
                {
                    Plugin.deathcountConfSF2.Value = 10;
                    Plugin.deathamountConfSF2.Value = 0f;
                    Plugin.deathspeedConfSF2.Value = 1f;
                }
                else if (fileString == "LCSaveFile3")
                {
                    Plugin.deathcountConfSF3.Value = 10;
                    Plugin.deathamountConfSF3.Value = 0f;
                    Plugin.deathspeedConfSF3.Value = 1f;
                }
            }
        }
    }
}
