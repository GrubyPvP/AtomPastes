using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgguWare.Options
{
    public class WeaponOptions
    {
        public bool NoSpread = false;
        public bool NoRecoil = false;
        public bool NoSway = false;
        public bool WeaponInfo = false;
        public bool TracerLines = false;
        public int TracerTime = 5;
        public bool DamageIndicators = false;
        public bool DamageIndicatorDamageScaling = false;
        public bool HitmarkerBonk = false;

        public bool RemoveHammerDelay = false;
        public bool RemoveBurstDelay = false;
        public bool InstantReload = false;
    }
}
