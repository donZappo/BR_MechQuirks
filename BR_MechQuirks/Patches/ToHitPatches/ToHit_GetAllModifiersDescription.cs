﻿using System;
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
            private static void Postfix(ToHit __instance, ref string __result, AbstractActor attacker, Weapon weapon, ICombatant target)
            {
                if (attacker.UnitType != UnitType.Mech)
                    return;

                var mechTags = attacker.GetTags();
                if (mechTags.Contains("BR_MQ_Mongoose") && weapon.Type == WeaponType.Laser)
                    __result = string.Format("{0}MECH QUIRK {1:+#;-#}; ", __result, Core.Settings.MongooseLaserAccuracy);
            }
        }
    }
}
