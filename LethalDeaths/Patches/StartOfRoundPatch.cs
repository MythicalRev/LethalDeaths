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

        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        public static void updatePlayerStartHealth()
        {
            PlayerControllerB playerControllerB = GameNetworkManager.Instance.localPlayerController;
            playerControllerB.health = Plugin.deathcount * 10;
            Plugin.mls.LogInfo("New Health = " + playerControllerB.health.ToString());
        }
    }
}
