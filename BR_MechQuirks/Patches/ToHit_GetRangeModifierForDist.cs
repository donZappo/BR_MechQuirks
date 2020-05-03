using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleTech;
using Harmony;

namespace BR_MechQuirks.Patches
{
    class GetRangeModifierForDist_Patch
    {
        [HarmonyPatch(typeof(ToHit), "GetRangeModifierForDist")]
        public static class ToHit_GetRangeModifierForDist_Patch
        {
            public static void Postfix(Weapon weapon, float dist, ref float __result)
            {
                var mechTags = weapon.parent.GetTags();
                //if (mechTags.Contains("BR_MQ_NoHonourPPCs") && dist < weapon.MinRange)
                //    __result = 0;
            }
        }
    }
}
