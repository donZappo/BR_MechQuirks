using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleTech;
using Harmony;
using BattleTech.UI;

namespace BR_MechQuirks.Patches
{
    class ToHit_Bonus_UI
    {
        [HarmonyPatch(typeof(ToHit), "GetAllModifiersDescription")]
        public static class ToHit_GetAllModifiersDescription_Patch
        {
            public static void Prefix()
            {
                Logger.Log("It is Prefixing the thing");
            }
            public static void Postfix(ToHit __instance, ref string __result, AbstractActor attacker, Weapon weapon, ICombatant target)
            {
                if (attacker.UnitType != UnitType.Mech)
                    return;

                var mechTags = attacker.GetTags();
                if (mechTags.Contains("BR_MQ_Mongoose") && weapon.Type == WeaponType.Laser)
                    __result = string.Format("{0}MECH QUIRK {1:+#;-#}; ", __result, Core.Settings.MongooseLaserAccuracy);
                if (mechTags.Contains("BR_MQ_SRMAccuracy") && weapon.Type == WeaponType.SRM)
                    __result = string.Format("{0}MECH QUIRK {1:+#;-#}; ", __result, Core.Settings.SRMAccuracyBoost);
                if (mechTags.Contains("BR_MQ_EnergySpecialization") && weapon.weaponDef.Category == WeaponCategory.Energy)
                    __result = string.Format("{0}MECH QUIRK {1:+#;-#}; ", __result, Core.Settings.EnergySpecializationBonus);
                if (mechTags.Contains("BR_MQ_EnergySpecialization") && weapon.weaponDef.Category != WeaponCategory.Energy)
                    __result = string.Format("{0}MECH QUIRK {1:+#;-#}; ", __result, Core.Settings.EnergySpecializationPenalty);
                if (mechTags.Contains("BR_MQ_Clint") && weapon.Type == WeaponType.Autocannon)
                    __result = string.Format("{0}MECH QUIRK {1:+#;-#}; ", __result, Core.Settings.ClintAutocannonBonus);
                if (mechTags.Contains("BR_MQ_Vulcan") && target.UnitType == UnitType.Vehicle)
                    __result = string.Format("{0}MECH QUIRK {1:+#;-#}; ", __result, Core.Settings.VulcanVehicleBonus);
                if (Methods.TeamHasTag(attacker, "BR_MQ_MassiveSearchLight"))
                    __result = string.Format("{0}TEAM QUIRK {1:+#;-#}; ", __result, Core.Settings.MassiveSearchLightTeamBonus);
                if (mechTags.Contains("BR_MQ_AwesomePPC") && weapon.weaponDef.Type == WeaponType.PPC)
                    __result = string.Format("{0}MECH QUIRK {1:+#;-#}; ", __result, Core.Settings.AwesomePPCBonus);
                if (mechTags.Contains("BR_MQ_AwesomePPC") && weapon.weaponDef.Category != WeaponCategory.Energy)
                    __result = string.Format("{0}MECH QUIRK {1:+#;-#}; ", __result, Core.Settings.AwesomeNonPPCPenalty);

                //***To-Be-Hit Section Follows*** 
                var targetName = target.Description.Name;

                if (targetName == "UrbanMech")
                    __result = string.Format("{0}TARGET QUIRK {1:+#;-#}; ", __result, Core.Settings.UrbieToBeHitPenalty);
                if (targetName == "Huron Warrior")
                    __result = string.Format("{0}TARGET QUIRK {1:+#;-#}; ", __result, Core.Settings.IntimidatingToBeHitPenalty);
            }
        }
    }
}
