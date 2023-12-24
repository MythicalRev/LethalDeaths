using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LethalDeaths.Patches
{
    [HarmonyPatch(typeof(DeleteFileButton))]
    class DeleteFilePatch
    {
        [HarmonyPatch("DeleteFile")]
        [HarmonyPostfix]
        public static void resetDeathOnFileDel(ref int ___fileToDelete)
        {
            if (___fileToDelete == 0)
            {
                Plugin.deathcountConfSF1.Value = 10;
                Plugin.deathamountConfSF1.Value = 0f;
                Plugin.deathspeedConfSF1.Value = 1f;
            }
            else if (___fileToDelete == 1)
            {
                Plugin.deathcountConfSF2.Value = 10;
                Plugin.deathamountConfSF2.Value = 0f;
                Plugin.deathspeedConfSF2.Value = 1f;
            }
            else if (___fileToDelete == 2)
            {
                Plugin.deathcountConfSF3.Value = 10;
                Plugin.deathamountConfSF3.Value = 0f;
                Plugin.deathspeedConfSF3.Value = 1f;
            }
        }
    }
}
