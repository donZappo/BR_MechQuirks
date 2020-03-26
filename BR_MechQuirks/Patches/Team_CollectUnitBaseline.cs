using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleTech;
using Harmony;

namespace BR_MechQuirks.Patches
{
    class Resolve_Patch
    {
        [HarmonyPatch(typeof(Team), "CollectUnitBaseline")]
        public static class Team_CollectUnitBaseline
        {
            private static void Postfix(Team __instance, ref int __result)
            {
                int BombardCount = 0;
                foreach (AbstractActor actor in __instance.units)
                {
                    var mechTags = actor.GetTags();

                    if (mechTags.Contains("BR_MQ_Bombard"))
                        BombardCount++;
                }
                __result += BombardCount * Core.Settings.BombardResolvePenalty;
            }
        }
    }
}
