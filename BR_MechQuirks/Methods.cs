using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleTech;
using Harmony;

namespace BR_MechQuirks
{
    class Methods
    {
        public static bool TeamHasTag(AbstractActor actor, string tag)
        {
            var team = actor.team;
            bool tagPresent = false;
            foreach (var unit in team.units)
            {
                if (unit.UnitType == UnitType.Mech && unit.GetTags().Contains(tag))
                    tagPresent = true;
            }
            return tagPresent;
        }
    }
}
