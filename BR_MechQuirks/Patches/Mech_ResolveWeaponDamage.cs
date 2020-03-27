﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleTech;
using Harmony;

namespace BR_MechQuirks.Patches
{
    class Resolve_WeaponDamage_Patch
    {
        [HarmonyPatch(typeof(AbstractActor), "GetAdjustedDamage")]
        public static class AbstractActor_GetAdjustedDamage_Patch
        {
            public static void Prefix(AbstractActor __instance, ref float incomingDamage, WeaponCategoryValue weaponCategoryValue)
            {
                var mechTags = __instance.GetTags();

                if (mechTags.Contains("BR_MQ_AntiBallisticSleekDesign") && weaponCategoryValue.IsBallistic)
                    incomingDamage *= Core.Settings.AntiBallisticSleekDesignFactor;
            }
        }
    }
}