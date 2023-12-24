using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LethalDeaths.Patches
{
    [HarmonyPatch(typeof(StartOfRound))]
    class StartOfRoundPatch
    {

        [HarmonyPatch("StartGame")]
        [HarmonyPostfix]
        public static void updatePlayerStartHealth()
        {
            GameNetworkManager gameNetworkManager = GameNetworkManager.Instance;

            int saveNum = gameNetworkManager.saveFileNum;
            if (PlayerControllerBPatch.debounce)
            {
                PlayerControllerBPatch.debounce = false;
                if (saveNum == 0)
                {
                    PlayerControllerB playerControllerB = GameNetworkManager.Instance.localPlayerController;
                    playerControllerB.health = Plugin.deathcountConfSF1.Value * 10;
                    Plugin.mls.LogInfo("New Health = " + playerControllerB.health.ToString());
                }
                else if (saveNum == 1)
                {
                    PlayerControllerB playerControllerB = GameNetworkManager.Instance.localPlayerController;
                    playerControllerB.health = Plugin.deathcountConfSF2.Value * 10;
                    Plugin.mls.LogInfo("New Health = " + playerControllerB.health.ToString());
                }
                else if (saveNum == 2)
                {
                    PlayerControllerB playerControllerB = GameNetworkManager.Instance.localPlayerController;
                    playerControllerB.health = Plugin.deathcountConfSF3.Value * 10;
                    Plugin.mls.LogInfo("New Health = " + playerControllerB.health.ToString());
                }
            }
        }

        [HarmonyPatch("ResetShip")]
        [HarmonyPostfix]
        public static void resetDeathCount()
        {
            GameNetworkManager gameNetworkManager = GameNetworkManager.Instance;

            int saveNum = gameNetworkManager.saveFileNum;

            PlayerControllerBPatch.debounce = true;

            if (saveNum == 0)
            {
                Plugin.deathcountConfSF1.Value = 10;
            }
            else if (saveNum == 1)
            {
                Plugin.deathcountConfSF2.Value = 10;
            }
            else if (saveNum == 2)
            {
                Plugin.deathcountConfSF3.Value = 10;
            }
        }

    }
}
