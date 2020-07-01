using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleTech;
using Harmony;
using UnityEngine;

namespace BR_MechQuirks.Patches
{
    class DamageLocation_Patch
    {
        [HarmonyPatch(typeof(Mech), "DamageLocation")]
        public static class Mech_DamageLocation_Patch
        {
            public static void Prefix(Mech __instance, int originalHitLoc, ArmorLocation aLoc, Weapon weapon, ref float totalArmorDamage, ref float directStructureDamage)
            {
                var mechTags = __instance.GetTags();

                if (mechTags.Contains("BR_MQ_ArmourBaffleSystem") && ((ArmorLocation)originalHitLoc == ArmorLocation.LeftArm || (ArmorLocation)originalHitLoc == ArmorLocation.RightArm ||
                    (ArmorLocation)originalHitLoc == ArmorLocation.LeftLeg || (ArmorLocation)originalHitLoc == ArmorLocation.RightLeg))
                {
                    totalArmorDamage *= Core.Settings.ArmourBaffleFactor;
                    directStructureDamage *= Core.Settings.ArmourBaffleFactor;
                }
                if (mechTags.Contains("BR_MQ_CrabClaws") && ((ArmorLocation)originalHitLoc == ArmorLocation.LeftArm || (ArmorLocation)originalHitLoc == ArmorLocation.RightArm))
                {
                    totalArmorDamage *= Core.Settings.CrabClawDamageFactor;
                    directStructureDamage *= Core.Settings.CrabClawDamageFactor;
                }
                if (__instance.GetPilot().pilotDef.PilotTags.Contains("PQ_pilot_elite") && __instance.weightClass == WeightClass.LIGHT)
                {
                    totalArmorDamage *= 0.8f;
                    directStructureDamage *= 0.8f;
                }
            }
        }
    }
}
