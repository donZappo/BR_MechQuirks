using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleTech;
using Harmony;

namespace BR_MechQuirks.Patches
{
    class RefireModifier_Patch
    {
        [HarmonyPatch(typeof(ToHit), "GetRefireModifier")]
        public static class ToHit_GetRefireModifier_Patch
        {
            public static void Postfix(Weapon weapon, ref float __result)
            {
                var mechTags = weapon.parent.GetTags();

                if (__result != 0)
                {
                    if (mechTags.Contains("BR_MQ_RecoilCompensator"))
                        __result += Core.Settings.RecoilCompensator;
                    __result = Math.Max(0, __result);
                }
            }
        }
    }
}
