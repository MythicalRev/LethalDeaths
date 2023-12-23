using HarmonyLib;
using GameNetcodeStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LethalDeaths.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    class PlayerControllerBPatch
    {
        [HarmonyPatch("KillPlayer")]
        [HarmonyPostfix]
        public static void setDeathCountOnDeath()
        {
            Plugin.mls.LogInfo("Plr Died");
            if (Plugin.deathcount != 0)
            {
                Plugin.deathcount -= 1;
                Plugin.mls.LogInfo(Plugin.deathcount.ToString());
            } 
            else
            {
                Plugin.deathcount = Plugin.maxdeaths;
                Plugin.mls.LogInfo(Plugin.deathcount.ToString());
            }
        }
    }
}
