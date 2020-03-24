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
                if (attacker.UnitType != UnitType.Mech)
                    return;

                var mechTags = attacker.GetTags();
                if (mechTags.Contains("BR_MQ_Mongoose") && weapon.Type == WeaponType.Laser)
                    __result = __result + (float)Core.Settings.MongooseLaserAccuracy;
            }
        }
    }
}
