using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleTech;
using Harmony;

namespace BR_MechQuirks.Patches
{
    class Instability_Reduction_Patch
    {
        [HarmonyPatch(typeof(Mech), "AddInstability")]
        public static class Mech_AddInstability_Patch
        {
            public static void Prefix(Mech __instance, ref float amt)
            {
                var mechTags = __instance.GetTags();

                //if (mechTags.Contains("BR_MQ_Dragon"))
                //    amt *= Core.Settings.DragonInstabilityFactor;
            }
        }
    }
}
