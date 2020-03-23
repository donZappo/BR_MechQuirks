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
                if (__instance.parent.GetTags().Contains("BR_MQ_Commando") && __instance.LocationDef.Location == ChassisLocations.RightArm)
                    __result *= Core.Settings.CommandoBonusDamage;
            }
        }
    }
}
