using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleTech;
using Harmony;

namespace BR_MechQuirks.Patches
{
    class HeatPerShot_Patch
    {
        [HarmonyPatch(typeof(Weapon), "HeatDamagePerShot", MethodType.Getter)]
        public static class Weapon_HeatDamagePerShot_Patch
        {
            public static void Postfix(Weapon __instance, ref float __result)
            {
                var mechTags = __instance.parent.GetTags();

                if (mechTags.Contains("BR_MQ_Firestarter"))
                    __result += Core.Settings.FirestarterHeatBonus;
            }
        }
    }
}
