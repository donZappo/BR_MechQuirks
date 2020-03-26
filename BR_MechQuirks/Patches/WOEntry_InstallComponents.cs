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
        [HarmonyPatch(typeof(WorkOrderEntry_InstallComponent), "WorkOrderEntry_InstallComponent")]
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
            }
        }
    }
}
