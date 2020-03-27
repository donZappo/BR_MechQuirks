using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleTech;
using Harmony;

namespace BR_MechQuirks.Patches
{
    class HeatGenerated_Patch
    {
        [HarmonyPatch(typeof(Weapon), "HeatGenerated", MethodType.Getter)]
        public static class Weapon_HeatGenerated_Patch
        {
            public static void Postfix(Weapon __instance, ref float __result)
            {
                var mechTags = __instance.parent.GetTags();

                if (mechTags.Contains("BR_MQ_PPCInputLag") && __instance.Type == WeaponType.PPC)
                    __result += Core.Settings.PPCInputLagHeatPenalty * __instance.combat.Constants.Heat.GlobalHeatIncreaseMultiplier * 
                        ((__instance.parent == null) ? 1f : __instance.parent.StatCollection.GetValue<float>("WeaponHeatMultiplier"));
                if (mechTags.Contains("BR_MQ_InfamouslyHot"))
                    __result += Core.Settings.InfamouslyHotHeatPenalty;
            }
        }
    }
}
