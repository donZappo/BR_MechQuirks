using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleTech;
using Harmony;

namespace BR_MechQuirks.Patches
{
    class MechComponent_Refit
    {
        [HarmonyPatch(typeof(WorkOrderEntry_InstallComponent))]
        [HarmonyPatch(MethodType.Constructor, new Type[] { typeof(string), typeof(string), typeof(string), typeof(MechComponentRef), typeof(int),
            typeof(string), typeof(ChassisLocations), typeof(ChassisLocations), typeof(int), typeof(int), typeof(string) })]
        public static class WorkOrderEntry_InstallComponent_WorkOrderEntry_InstallComponent_Patch
        {
            public static void Prefix(WorkOrderEntry_InstallComponent __instance, ref int techCost, ref int cbillCost)
            {
                var mechID = __instance.MechID;
                var mechTags = UnityGameInstance.BattleTechGame.Simulation.GetMechByID(mechID).MechTags;
                
                if (mechTags.Contains("BR_MQ_Vindicator"))
                {
                    techCost = (int)(techCost * Core.Settings.GenericDesignRefitFactor);
                    cbillCost = (int)(cbillCost * Core.Settings.GenericDesignRefitFactor);
                }
                if (mechTags.Contains("BR_MQ_Bushwacker") && __instance.ComponentType == ComponentType.HeatSink)
                {
                    techCost = (int)(techCost * Core.Settings.BushwackerHSComponentFactor);
                    cbillCost = (int)(cbillCost * Core.Settings.BushwackerHSComponentFactor);
                }
                if (mechTags.Contains("BR_MQ_Omni"))
                    techCost = (int)(techCost * Core.Settings.OmniRefitFactor);
                if (mechTags.Contains("BR_MQ_NonStandardParts"))
                {
                    techCost = (int)(techCost * Core.Settings.NonStandardPartsFactor);
                    cbillCost = (int)(cbillCost * Core.Settings.NonStandardPartsFactor);
                }
                if (mechTags.Contains("BR_MQ_Rare"))
                {
                    techCost = (int)(techCost * Core.Settings.RareRepairFactor);
                    cbillCost = (int)(cbillCost * Core.Settings.RareRepairFactor);
                }

            }
        }
    }
}
