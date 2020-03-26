using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleTech;
using Harmony;

namespace BR_MechQuirks.Patches
{
    class DamageLocation_Patch
    {
        [HarmonyPatch(typeof(Mech), "DamageLocation")]
        public static class Mech_DamageLocation_Patch
        {
            public static void Postfix(Mech __instance, int originalHitLoc, ArmorLocation aLoc, Weapon weapon, ref float totalArmorDamage, ref float directStructureDamage)
            {
                var mechTags = __instance.GetTags();

                if (mechTags.Contains("BR_MQ_ArmourBaffleSystem") && (aLoc == ArmorLocation.LeftArm || aLoc == ArmorLocation.RightArm ||
                    aLoc == ArmorLocation.LeftLeg || aLoc == ArmorLocation.RightLeg))
                {
                    totalArmorDamage *= Core.Settings.ArmourBaffleFactor;
                    directStructureDamage *= Core.Settings.ArmourBaffleFactor;
                }
            }
        }
    }
}
