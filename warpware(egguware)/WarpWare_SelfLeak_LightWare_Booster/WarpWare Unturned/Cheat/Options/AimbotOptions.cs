﻿using EgguWare.Classes;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EgguWare.Options
{
    public class AimbotOptions
    {
        public bool SilentAim = false;
        public bool SilentAimInfo = true;
        public int AimpointMultiplier = 1;
        public int HitboxSize = 15;
        public TargetLimb1 TargetL = TargetLimb1.SKULL;
        public KeyCode AimlockKey = KeyCode.F;
        public List<ESPObject> SilentAimObjects = new List<ESPObject>();
        public bool OnlyVisible = false;
        public bool Aimlock = false;
        public bool Mouse1Aimbot = false;
        public bool AimlockLimitFOV = false;
        public int AimlockFOV = 200;
        public bool AimlockDrawFOV = false;
        public bool SilentAimLimitFOV = false;
        public int SilentAimFOV = 200;
        public bool SilentAimDrawFOV = false;
        public bool ExpandHitboxes = false;
        public int HitChance = 100;
    }
}
