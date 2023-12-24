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
        internal static bool debounce = true;

        [HarmonyPatch("KillPlayer")]
        [HarmonyPostfix]
        public static void setDeathCountOnDeath()
        {
            GameNetworkManager gameNetworkManager = GameNetworkManager.Instance;

            int saveNum = gameNetworkManager.saveFileNum;

            if (!debounce)
            {
                debounce = true;
                if (saveNum == 0)
                {
                    if (Plugin.deathcountConfSF1.Value != 0)
                    {
                        Plugin.deathcountConfSF1.Value -= 1;
                    }
                    else
                    {
                        Plugin.deathcountConfSF1.Value = Plugin.maxdeaths;
                    }
                }
                else if (saveNum == 1)
                {
                    if (Plugin.deathcountConfSF2.Value != 0)
                    {
                        Plugin.deathcountConfSF2.Value -= 1;
                    }
                    else
                    {
                        Plugin.deathcountConfSF2.Value = Plugin.maxdeaths;
                    }
                }
                else if (saveNum == 1)
                {
                    if (Plugin.deathcountConfSF3.Value != 0)
                    {
                        Plugin.deathcountConfSF3.Value -= 1;
                    }
                    else
                    {
                        Plugin.deathcountConfSF3.Value = Plugin.maxdeaths;
                    }
                }
            }
        }
    }
}
