using HarmonyLib;
using GameNetcodeStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;

namespace LethalDeaths.Patches
{
    [HarmonyPatch(typeof(SaveFileUISlot))]
    class SaveFileUISlotPatch
    {

        [HarmonyPatch("OnEnable")]
        [HarmonyPostfix]
        public static void setSaveInfoText(ref TextMeshProUGUI ___fileStatsText, ref string ___fileString)
        {
            if (ES3.FileExists(___fileString))
            {
                int num = ES3.Load("GroupCredits", ___fileString, 30);
                int num2 = ES3.Load("Stats_DaysSpent", ___fileString, 0);

                ___fileStatsText.fontSize = 8;

                if (___fileString == "LCSaveFile1")
                {
                    ___fileStatsText.text = $"${num}\nDays: {num2}\nHP: {Plugin.deathcountConfSF1.Value * 10}";
                }
                else if (___fileString == "LCSaveFile2")
                {
                    ___fileStatsText.text = $"${num}\nDays: {num2}\nHP: {Plugin.deathcountConfSF2.Value * 10}";
                }
                else if (___fileString == "LCSaveFile3")
                {
                    ___fileStatsText.text = $"${num}\nDays: {num2}\nHP: {Plugin.deathcountConfSF3.Value * 10}";
                }
                else
                {
                    Plugin.mls.LogError("No SaveData Found");
                }
            }
            else
            {
                ___fileStatsText.text = "";
            }
        }
    }
}
