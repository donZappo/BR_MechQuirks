using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleTech;
using Harmony;

namespace BR_MechQuirks.Patches
{
    class DamagePerShot_Patch
    {
        [HarmonyPatch(typeof(Weapon), "DamagePerShot", MethodType.Getter)]
        public static class Weapon_DamagePerShot_Patch
        {
            public static void Postfix(Weapon __instance, ref float __result)
            {
                var mechTags = __instance.parent.GetTags();
                if (mechTags.Contains("BR_MQ_Commando") && __instance.LocationDef.Location == ChassisLocations.RightArm)
                    __result *= Core.Settings.CommandoBonusDamage;
                if (mechTags.Contains("BR_MQ_PPCInputLag") && (__instance.WeaponSubType == WeaponSubType.PPC || __instance.WeaponSubType == WeaponSubType.PPCER))
                    __result += Core.Settings.PPCInputLagDamageBonus;
                if (mechTags.Contains("BR_MQ_PPCInputLag") && __instance.WeaponSubType == WeaponSubType.PPCSnub)
                    __result += Core.Settings.PPCInputLagDamageBonus / __instance.ProjectilesPerShot;
                if (mechTags.Contains("BR_MQ_Blackjack") && __instance.WeaponSubType == WeaponSubType.AC2)
                    __result += Core.Settings.BlackjackAC2DamageBonus;
                if (mechTags.Contains("BR_MQ_InfamouslyHot"))
                    __result += Core.Settings.InfamouslyHotDamageBonus / __instance.ProjectilesPerShot;
            }
        }
    }
}
