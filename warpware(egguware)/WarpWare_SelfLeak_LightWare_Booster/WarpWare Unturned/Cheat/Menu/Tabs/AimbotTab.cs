﻿using EgguWare.Classes;
using EgguWare.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EgguWare.Menu.Tabs
{
    public class AimbotTab
    {
        public static AimbotOptions SelectedObject = AimbotOptions.Silent;
        private static Vector2 scrollPosition;
        public static void Tab()
        {
            GUILayout.Space(0);
            GUILayout.BeginArea(new Rect(10, 35, 260, 400), style: "box", text: "Silent Aimbot");
            scrollPosition = GUILayout.BeginScrollView(scrollPosition);
            G.Settings.AimbotOptions.SilentAim = GUILayout.Toggle(G.Settings.AimbotOptions.SilentAim, "Silent Aim");
            if (G.Settings.AimbotOptions.SilentAim)
            {
                // here is where i was gonna add silent aim objects
                /*GUILayout.Space(4);
                foreach (ESPObject obj in Enum.GetValues(typeof(ESPObject)))
                {
                    bool included = G.Settings.AimbotOptions.SilentAimObjects.Contains(obj);
                    bool checkbox = GUILayout.Toggle(included, "Target " + Enum.GetName(typeof(ESPObject), obj));

                    if (included && !checkbox)
                        G.Settings.AimbotOptions.SilentAimObjects.Remove(obj);
                    else if (!included && checkbox)
                        G.Settings.AimbotOptions.SilentAimObjects.Add(obj);
                }
                GUILayout.Space(4);*/

                //G.Settings.AimbotOptions.SilentAimInfo = GUILayout.Toggle(G.Settings.AimbotOptions.SilentAimInfo, "Show Vulnerable Targets");
                G.Settings.AimbotOptions.ExpandHitboxes = GUILayout.Toggle(G.Settings.AimbotOptions.ExpandHitboxes, "Expand Hitboxes");
                if (G.Settings.AimbotOptions.ExpandHitboxes)
                {
                    GUILayout.Label("Aimpoint Multiplier: " + G.Settings.AimbotOptions.AimpointMultiplier);
                    G.Settings.AimbotOptions.AimpointMultiplier = (int)GUILayout.HorizontalSlider(G.Settings.AimbotOptions.AimpointMultiplier, 1, 3);
                    GUILayout.Space(2);

                    GUILayout.Label("Expand Hitboxes: " + G.Settings.AimbotOptions.HitboxSize + "m");
                    G.Settings.AimbotOptions.HitboxSize = (int)GUILayout.HorizontalSlider(G.Settings.AimbotOptions.HitboxSize, 1, 15);
                    GUILayout.Space(2);
                }

                GUILayout.Label("Hitchance: " + G.Settings.AimbotOptions.HitChance + "%");
                G.Settings.AimbotOptions.HitChance = (int)GUILayout.HorizontalSlider(G.Settings.AimbotOptions.HitChance, 1, 100);
                GUILayout.Space(2);

                if (GUILayout.Button("Silent Aim Limb: " + Enum.GetName(typeof(TargetLimb1), G.Settings.AimbotOptions.TargetL)))
                    G.Settings.AimbotOptions.TargetL = G.Settings.AimbotOptions.TargetL.Next();

                G.Settings.AimbotOptions.SilentAimLimitFOV = GUILayout.Toggle(G.Settings.AimbotOptions.SilentAimLimitFOV, "FOV Limit");
                if (G.Settings.AimbotOptions.SilentAimLimitFOV)
                {
                    GUILayout.Label("FOV Circle: " + G.Settings.AimbotOptions.SilentAimFOV);
                    G.Settings.AimbotOptions.SilentAimFOV = (int)GUILayout.HorizontalSlider(G.Settings.AimbotOptions.SilentAimFOV, 1, 1200);
                    G.Settings.AimbotOptions.SilentAimDrawFOV = GUILayout.Toggle(G.Settings.AimbotOptions.SilentAimDrawFOV, "Draw FOV Circle");
                }
            }
            GUILayout.EndScrollView();
            GUILayout.EndArea();
            GUILayout.BeginArea(new Rect(280, 35, 260, 400), style: "box", text: "Manual Aimbot");
            G.Settings.AimbotOptions.Aimlock = GUILayout.Toggle(G.Settings.AimbotOptions.Aimlock, "Aimbot");
            if (G.Settings.AimbotOptions.Aimlock)
            {
                if (GUILayout.Button("Aimbot Key: " + G.Settings.AimbotOptions.AimlockKey.ToString()))
                    G.Settings.AimbotOptions.AimlockKey = KeyCode.None;

                G.Settings.AimbotOptions.OnlyVisible = GUILayout.Toggle(G.Settings.AimbotOptions.OnlyVisible, "Only Aim At Visible Targets");
                G.Settings.AimbotOptions.AimlockLimitFOV = GUILayout.Toggle(G.Settings.AimbotOptions.AimlockLimitFOV, "FOV Limit");
                if (G.Settings.AimbotOptions.AimlockLimitFOV)
                {
                    GUILayout.Label("FOV Circle: " + G.Settings.AimbotOptions.AimlockFOV);
                    G.Settings.AimbotOptions.AimlockFOV = (int)GUILayout.HorizontalSlider(G.Settings.AimbotOptions.AimlockFOV, 1, 1200);
                    G.Settings.AimbotOptions.AimlockDrawFOV = GUILayout.Toggle(G.Settings.AimbotOptions.AimlockDrawFOV, "Draw FOV Circle");
                }

            }
            GUILayout.EndArea();
            if (G.Settings.AimbotOptions.AimlockKey == KeyCode.None)
            {
                Event e = Event.current;
                G.Settings.AimbotOptions.AimlockKey = e.keyCode;
            }
        }
    }
}
