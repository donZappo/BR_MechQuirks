using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleTech;
using Harmony;

namespace BR_MechQuirks.Patches
{
    class SpotterDistance_Patch
    {
        [HarmonyPatch(typeof(LineOfSight), "GetAllSpotterAbsolutes")]
        public static class LineOfSight_GetAllSpotterAbsolutes_Patch
        {
            public static void Postfix(AbstractActor source, ref float __result)
            {
                var mechTags = source.GetTags();

                //if (mechTags.Contains("BR_MQ_Valkyrie"))
                //    __result += Core.Settings.ValkyrieSpotterBonus;
            }
        }
    }
}
