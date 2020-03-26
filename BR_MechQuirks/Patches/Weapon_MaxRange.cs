using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleTech;
using Harmony;

namespace BR_MechQuirks.Patches
{
    class MaxRange_Patch
    {
        [HarmonyPatch(typeof(Weapon), "MaxRange", MethodType.Getter)]
        public static class Weapon_MaxRange_Patch
        {
            public static void Postfix(Weapon __instance, ref float __result)
            {
                var mechTags = __instance.parent.GetTags();

                if (mechTags.Contains("BR_MQ_NARCRange") && __instance.WeaponSubType == WeaponSubType.Narc)
                    __result += Core.Settings.NARCMaxRangeIncrease;
            }
        }
    }
}
