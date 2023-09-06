using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EgguWare.Menu.Tabs
{
    public class WeaponsTab
    {
        public static void Tab()
        {
            GUILayout.Space(0);
            GUILayout.BeginArea(new Rect(10, 35, 260, 400), style: "box", text: "Weapon Stuff");
            G.Settings.WeaponOptions.NoSpread = GUILayout.Toggle(G.Settings.WeaponOptions.NoSpread, "Remove Spread");
            G.Settings.WeaponOptions.NoRecoil = GUILayout.Toggle(G.Settings.WeaponOptions.NoRecoil, "Remove Recoil");
            G.Settings.WeaponOptions.NoSway = GUILayout.Toggle(G.Settings.WeaponOptions.NoSway, "Remove Sway");
            GUILayout.EndArea();

            GUILayout.BeginArea(new Rect(280, 35, 260, 400), style: "box", text: "Other");
            G.Settings.WeaponOptions.WeaponInfo = GUILayout.Toggle(G.Settings.WeaponOptions.WeaponInfo, "Show Weapon Info");
            GUILayout.EndArea();
        }
    }
}
