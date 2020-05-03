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
    class ToHit_Bonus
    {
        [HarmonyPatch(typeof(ToHit), "GetAllModifiers")]
        public static class ToHit_GetAllModifiers_Patch
        {
            public static void Postfix(ToHit __instance, ref float __result, AbstractActor attacker, Weapon weapon, ICombatant target)
            {
                if (attacker.UnitType != UnitType.Mech || target == null || attacker == null)
                    return;

                var mechTags = attacker.GetTags();
                if (mechTags.Contains("BR_MQ_Vulcan") && target.UnitType == UnitType.Vehicle)
                    __result += (float)Core.Settings.VulcanVehicleBonus;

                //if (mechTags.Contains("BR_MQ_Mongoose") && weapon.Type == WeaponType.Laser)
                //    __result += (float)Core.Settings.MongooseLaserAccuracy;
                //if (mechTags.Contains("BR_MQ_SRMAccuracy") && weapon.Type == WeaponType.SRM)
                //    __result += (float)Core.Settings.SRMAccuracyBoost;
                //if (mechTags.Contains("BR_MQ_EnergySpecialization") && weapon.weaponDef.Category == WeaponCategory.Energy)
                //    __result += (float)Core.Settings.EnergySpecializationBonus;
                //if (mechTags.Contains("BR_MQ_EnergySpecialization") && weapon.weaponDef.Category != WeaponCategory.Energy)
                //    __result += (float)Core.Settings.EnergySpecializationPenalty;
                //if (mechTags.Contains("BR_MQ_Clint") && weapon.Type == WeaponType.Autocannon)
                //    __result += (float)Core.Settings.ClintAutocannonBonus;
                //if (Methods.TeamHasTag(attacker, "BR_MQ_MassiveSearchLight"))
                //    __result += (float)Core.Settings.MassiveSearchLightTeamBonus;
                //if (mechTags.Contains("BR_MQ_AwesomePPC") && weapon.weaponDef.Type == WeaponType.PPC)
                //    __result += (float)Core.Settings.AwesomePPCBonus;
                //if (mechTags.Contains("BR_MQ_AwesomePPC") && weapon.weaponDef.Category != WeaponCategory.Energy)
                //    __result += (float)Core.Settings.AwesomeNonPPCPenalty;
                //if (mechTags.Contains("BR_MQ_AllOrNothing") && (weapon.weaponDef.WeaponSubType == WeaponSubType.AC20 ||
                //    weapon.weaponDef.WeaponSubType == WeaponSubType.UAC20 || weapon.weaponDef.WeaponSubType == WeaponSubType.LB20X))
                //    __result += (float)Core.Settings.AllOrNothingAccuracy;
                //if (mechTags.Contains("BR_MQ_BallisticComputer") && weapon.weaponDef.Category == WeaponCategory.Ballistic)
                //    __result += (float)Core.Settings.BallisticComputerBonus;

                //***To-Be-Hit Section Follows*** 
                //var targetName = target.Description.Name;

                //if (targetName == "UrbanMech")
                //    __result += (float)Core.Settings.UrbieToBeHitPenalty;
                //if (targetName == "UrbanMech")
                //    __result += (float)Core.Settings.IntimidatingToBeHitPenalty;
                //if (targetName == "Atlas")
                //    __result += (float)Core.Settings.IntimidatingToBeHitPenalty;
            }
        }
    }
}
