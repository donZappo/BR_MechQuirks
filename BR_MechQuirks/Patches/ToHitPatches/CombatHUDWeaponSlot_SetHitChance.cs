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
    class Accuracy_Bonus_UI
    {
        [HarmonyPatch(typeof(CombatHUDWeaponSlot), "SetHitChance", new Type[] { typeof(ICombatant) })]
        public static class CombatHUDWeaponSlot_SetHitChance_Patch
        {
            public static void Postfix(CombatHUDWeaponSlot __instance, ICombatant target)
            {
                var _this = Traverse.Create(__instance);
                AbstractActor actor = __instance.DisplayedWeapon.parent;
                if (actor.UnitType != UnitType.Mech)
                    return;

                var mechTags = actor.GetTags();
                if (mechTags.Contains("BR_MQ_Mongoose") && __instance.DisplayedWeapon.Type == WeaponType.Laser)
                    _this.Method("AddToolTipDetail", "MECH QUIRK", Core.Settings.MongooseLaserAccuracy).GetValue();
                if (mechTags.Contains("BR_MQ_SRMAccuracy") && __instance.DisplayedWeapon.Type == WeaponType.SRM)
                    _this.Method("AddToolTipDetail", "MECH QUIRK", Core.Settings.SRMAccuracyBoost).GetValue();
                if (mechTags.Contains("BR_MQ_EnergySpecialization") && __instance.DisplayedWeapon.weaponDef.Category == WeaponCategory.Energy)
                    _this.Method("AddToolTipDetail", "MECH QUIRK", Core.Settings.EnergySpecializationBonus).GetValue();
                if (mechTags.Contains("BR_MQ_EnergySpecialization") && __instance.DisplayedWeapon.weaponDef.Category != WeaponCategory.Energy)
                    _this.Method("AddToolTipDetail", "MECH QUIRK", Core.Settings.EnergySpecializationPenalty).GetValue();
                if (mechTags.Contains("BR_MQ_Clint") && __instance.DisplayedWeapon.Type == WeaponType.Autocannon)
                    _this.Method("AddToolTipDetail", "MECH QUIRK", Core.Settings.ClintAutocannonBonus).GetValue();
                if (mechTags.Contains("BR_MQ_Vulcan") && target.UnitType == UnitType.Vehicle)
                    _this.Method("AddToolTipDetail", "MECH QUIRK", Core.Settings.VulcanVehicleBonus).GetValue();
                if (Methods.TeamHasTag(actor, "BR_MQ_MassiveSearchLight"))
                    _this.Method("AddToolTipDetail", "TEAM QUIRK", Core.Settings.MassiveSearchLightTeamBonus).GetValue();
                if (mechTags.Contains("BR_MQ_AwesomePPC") && __instance.DisplayedWeapon.weaponDef.Type == WeaponType.PPC)
                    _this.Method("AddToolTipDetail", "MECH QUIRK", Core.Settings.AwesomePPCBonus).GetValue();
                if (mechTags.Contains("BR_MQ_AwesomePPC") && __instance.DisplayedWeapon.weaponDef.Type != WeaponType.PPC)
                    _this.Method("AddToolTipDetail", "MECH QUIRK", Core.Settings.AwesomeNonPPCPenalty).GetValue();
                if (mechTags.Contains("BR_MQ_AllOrNothing") && (__instance.DisplayedWeapon.WeaponSubType == WeaponSubType.AC20 ||
                    __instance.DisplayedWeapon.WeaponSubType == WeaponSubType.UAC20 || __instance.DisplayedWeapon.WeaponSubType == WeaponSubType.LB20X))
                    _this.Method("AddToolTipDetail", "MECH QUIRK", Core.Settings.AllOrNothingAccuracy).GetValue();
                if (mechTags.Contains("BR_MQ_BallisticComputer") && __instance.DisplayedWeapon.weaponDef.Category == WeaponCategory.Ballistic)
                    _this.Method("AddToolTipDetail", "MECH QUIRK", Core.Settings.BallisticComputerBonus).GetValue();

                //***To-Be-Hit Section Follows*** 
                var targetName = target.Description.Name;

                if (targetName == "UrbanMech")
                    _this.Method("AddToolTipDetail", "TARGET QUIRK", Core.Settings.UrbieToBeHitPenalty).GetValue();
                if (targetName == "Huron Warrior")
                    _this.Method("AddToolTipDetail", "TARGET QUIRK", Core.Settings.IntimidatingToBeHitPenalty).GetValue();
            }
        }
    }
}
