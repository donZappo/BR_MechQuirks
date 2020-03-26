using System.Collections.Generic;
using BattleTech;

namespace BR_MechQuirks
{
    public class ModSettings
    {
        public bool Debug = false;
        public string modDirectory;

        public float CommandoBonusDamage = 1.5f;
        public float MongooseLaserAccuracy = -5;
        public float SRMAccuracyBoost = -4;
        public float UrbieToBeHitPenalty = 3;
        public float ValkyrieSpotterBonus = 150;
        public float HollanderRefireBonus = 2;
        public float FirestarterHeatBonus = 3;
        public float PantherPPCDamageBonus = 10;
        public float PantherPPCHeatPenalty = 5;
        public float WolfhoundEnergyBonus = -2;
        public float WolfhoundNonEnergyPenalty = 2;
    }
}
