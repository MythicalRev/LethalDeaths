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
                    if (Plugin.sprintAmoundDecToggle.Value)
                    {
                        Plugin.deathspeedConfSF1.Value -= .1f;
                    }

                    if (Plugin.weightIncreaseToggle.Value)
                    {
                        Plugin.deathamountConfSF1.Value += .1f;
                    }
                    
                    if (Plugin.healthDecreaseToggle.Value)
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
                }
                else if (saveNum == 1)
                {
                    if (Plugin.sprintAmoundDecToggle.Value)
                    {
                        Plugin.deathspeedConfSF2.Value -= .1f;
                    }

                    if (Plugin.weightIncreaseToggle.Value)
                    {
                        Plugin.deathamountConfSF2.Value += .1f;
                    }

                    if (Plugin.healthDecreaseToggle.Value)
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
                }
                else if (saveNum == 2)
                {
                    if (Plugin.sprintAmoundDecToggle.Value)
                    {
                        Plugin.deathspeedConfSF3.Value -= .1f;
                    }

                    if (Plugin.weightIncreaseToggle.Value)
                    {
                        Plugin.deathamountConfSF3.Value += .1f;
                    }

                    if (Plugin.healthDecreaseToggle.Value)
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

        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        public static void maxSprintSet(ref float ___sprintMeter)
        {
            GameNetworkManager gameNetworkManager = GameNetworkManager.Instance;

            int saveNum = gameNetworkManager.saveFileNum;

            if (saveNum == 0)
            {
                if (___sprintMeter > Plugin.deathspeedConfSF1.Value)
                {
                    ___sprintMeter = Plugin.deathspeedConfSF1.Value;
                }
            }
            else if (saveNum == 1)
            {
                if (___sprintMeter > Plugin.deathspeedConfSF2.Value)
                {
                    ___sprintMeter = Plugin.deathspeedConfSF2.Value;
                }
            }
            else if (saveNum == 2)
            {
                if (___sprintMeter > Plugin.deathspeedConfSF3.Value)
                {
                    ___sprintMeter = Plugin.deathspeedConfSF3.Value;
                }
            }
        }
    }
}
