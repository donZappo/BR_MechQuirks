﻿using System;
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
                if (__instance.GetPilot().pilotDef.PilotTags.Contains("PQ_pilot_elite") && __instance.weightClass == WeightClass.MEDIUM)
                {
                    var pips = __instance.EvasivePipsCurrent;
                    totalArmorDamage *= 1 - pips * 0.05f;
                    directStructureDamage *= 1 - pips * 0.05f;
                }
                if (__instance.GetPilot().pilotDef.SkillGuts >= 5)
                {
                    float gutsBonus = (__instance.GetPilot().pilotDef.SkillGuts - 4) * 0.02f;
                    if (__instance.GetPilot().pilotDef.SkillGuts >= 10)
                        gutsBonus += 0.03f;
                    totalArmorDamage *= 1 - gutsBonus;
                    directStructureDamage *= 1 - gutsBonus;
                }
            }
        }
    }
}
