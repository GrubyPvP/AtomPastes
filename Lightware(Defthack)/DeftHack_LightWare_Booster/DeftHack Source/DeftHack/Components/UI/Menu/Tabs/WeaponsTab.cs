using SDG.Unturned;


using UnityEngine;

 
public static class WeaponsTab
{
    
    public static void Tab()
    {
        Prefab.MenuArea(new Rect(0f, 0f, 466f, 436f), "ДЛЯ ОРУЖИЯ", delegate
        {
            GUILayout.BeginHorizontal(new GUILayoutOption[0]);
            GUILayout.BeginVertical(new GUILayoutOption[]
            {
                    GUILayout.Width(230f)
            });
            Prefab.Toggle("No Recoil", ref WeaponOptions.NoRecoil, 17);
            Prefab.Toggle("No Spread", ref WeaponOptions.NoSpread, 17);
            Prefab.Toggle("No Sway", ref WeaponOptions.NoSway, 17);
            Prefab.Toggle("No Bullet Drop", ref WeaponOptions.NoDrop, 17);
            Prefab.Toggle("Triggerbot", ref TriggerbotOptions.Enabled, 17);
            Prefab.Toggle("Killsound", ref WeaponOptions.OofOnDeath, 17);
            Prefab.Toggle("Auto-Reload", ref WeaponOptions.AutoReload, 17);
            Prefab.Toggle("Show Weapon Info", ref WeaponOptions.ShowWeaponInfo, 17);

            if (Prefab.Toggle("Head Only", ref RaycastOptions.AlwaysHitHead, 17))
            {
                RaycastOptions.UseCustomLimb = false;
                RaycastOptions.UseRandomLimb = false;
            } 
            if (Prefab.Toggle("Random Limb Selection", ref RaycastOptions.UseRandomLimb, 17))
            {
                RaycastOptions.UseCustomLimb = false;
                RaycastOptions.AlwaysHitHead = false;
            }
            if (!RaycastOptions.UseRandomLimb)
            {
                if (Prefab.Toggle("Use Custom Limb", ref RaycastOptions.UseCustomLimb, 17))
                {
                    RaycastOptions.UseRandomLimb = false;
                    RaycastOptions.AlwaysHitHead = false;
                }
            }
            GUILayout.Space(2f);
            GUIContent[] array = new GUIContent[]
            {
                    new GUIContent("Left Foot"),
                    new GUIContent("Left Leg"),
                    new GUIContent("Right Foot"),
                    new GUIContent("Right Leg"),
                    new GUIContent("Left Hand"),
                    new GUIContent("Left Arm"),
                    new GUIContent("Right Hand"),
                    new GUIContent("Right Arm"),
                    new GUIContent("Left Back"),
                    new GUIContent("Right Back"),
                    new GUIContent("Left Front"),
                    new GUIContent("Right Front"),
                    new GUIContent("Spine"),
                    new GUIContent("Skull")
            }; 
            GUILayout.Space(2f);
            bool flag2 = RaycastOptions.UseCustomLimb && !RaycastOptions.UseRandomLimb;
            if (flag2)
            {
                bool flag3 = Prefab.List(230f, "_TargetLimb", new GUIContent("Конечность: " + array[(int)RaycastOptions.TargetLimb].text), array, new GUILayoutOption[0]);
                if (flag3)
                {
                    RaycastOptions.TargetLimb = (ELimb)DropDown.Get("_TargetLimb").ListIndex;
                }
            }
            GUILayout.Space(2f);
          
            GUILayout.EndVertical();
            GUILayout.BeginVertical(new GUILayoutOption[]
            {
                    GUILayout.Width(230f)
            }); 
            Prefab.Toggle("Weapon Zoom", ref WeaponOptions.Zoom, 17);
            if (WeaponOptions.Zoom)
            {
                GUILayout.Space(2f);
                GUILayout.Label("Weapon Zoom: " + WeaponOptions.ZoomValue, Prefab._TextStyle, new GUILayoutOption[0]);
                WeaponOptions.ZoomValue = (int)Prefab.Slider(2f, 30f, WeaponOptions.ZoomValue, 200);
            }
             
            GUILayout.Space(2f);
             
            GUILayout.EndVertical();
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        });
    }
}

