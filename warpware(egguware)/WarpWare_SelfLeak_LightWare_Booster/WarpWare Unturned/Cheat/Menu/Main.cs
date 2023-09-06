using EgguWare.Attributes;
using EgguWare.Classes;
using EgguWare.Menu.Tabs;
using EgguWare.Utilities;
using SDG.Unturned;
using EgguWare.Cheats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

using AssetUtilities = EgguWare.Utilities.AssetUtilities;
using EgguWare.Menu.Windows;

namespace EgguWare.Menu
{
    [Comp]
    public class Main : MonoBehaviour
    {
        public static MenuTab SelectedTab = MenuTab.Visuals;
        public static bool MenuOpen = false;
        public static string DropdownTitle;
        public static Rect DropdownPos;
        public static Color GUIColor;
        private List<GUIContent> buttons = new List<GUIContent>();
        public static List<GUIContent> buttons2 = new List<GUIContent>();
        public static List<GUIContent> buttons3 = new List<GUIContent>();
        public static List<GUIContent> buttons4 = new List<GUIContent>();
        public static List<GUIContent> buttons5 = new List<GUIContent>();
        public static Rect CursorPos = new Rect(0, 0, 20f, 20f);



        private int i = -40;
        private Texture _cursorTexture;
        private Rect windowRect = new Rect(200, 200, 900, 450);
        private Rect itemRect = new Rect(500, 565, 300, 300);
        private Rect guiRect = new Rect(200, 855, 300, 350);

        readonly string Name = "warpware";
        readonly string Version = "";

        void Start()
        {
            GUIColor = GUI.color;
            foreach (MenuTab val in Enum.GetValues(typeof(MenuTab)))
                buttons.Add(new GUIContent(Enum.GetName(typeof(MenuTab), val)));
            foreach (ESPObject val in Enum.GetValues(typeof(ESPObject)))
                buttons2.Add(new GUIContent(Enum.GetName(typeof(ESPObject), val)));
            foreach (MiscOptions val in Enum.GetValues(typeof(MiscOptions)))
                buttons3.Add(new GUIContent(Enum.GetName(typeof(MiscOptions), val).Replace("_", " ")));
            foreach (SettingsOptions val in Enum.GetValues(typeof(SettingsOptions)))
                buttons4.Add(new GUIContent(Enum.GetName(typeof(SettingsOptions), val)));
            foreach (AimbotOptions val in Enum.GetValues(typeof(AimbotOptions)))
                buttons5.Add(new GUIContent(Enum.GetName(typeof(AimbotOptions), val))); 
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                if (MenuOpen == false)
                    MenuOpen = true;
                else
                {
                    MenuOpen = false;
                    i = -40;
                }
            }
            if (Input.GetKeyDown(KeyCode.F2))
            {
                if (!G.Settings.MiscOptions.FreeCam)

                {
                    G.Settings.MiscOptions.FreeCam = true;
                }
                else
                {
                    G.Settings.MiscOptions.FreeCam = false;
                }
            }
        }


        void OnGUI()
        {
            if (!G.BeingSpied && MenuOpen)
            {
                GUI.skin = AssetUtilities.Skin;

                if (_cursorTexture == null)
                    _cursorTexture = Resources.Load("UI/Glazier_IMGUI/Cursor") as Texture;

                GUI.depth = -1;

                GUIStyle guiStyle = new GUIStyle("label");
                guiStyle.margin = new RectOffset(10, 10, 5, 5);
                guiStyle.fontSize = 30;

                if (i < 0)
                    i++;
                windowRect = GUILayout.Window(0, windowRect, MenuWindow, Enum.GetName(typeof(MenuTab), SelectedTab));
                if (WhitelistWindow.WhitelistMenuOpen)
                    itemRect = GUILayout.Window(4, itemRect, WhitelistWindow.Window, (Cheats.Items.editingaip ? "Pickup " : "ESP ") + "Whitelist");
                if (GUIWindow.GUISkinMenuOpen)
                    guiRect = GUILayout.Window(5, guiRect, GUIWindow.Window, "GUI Skin");

                GUILayout.BeginArea(new Rect(0, i, Screen.width, 40));
                GUILayout.BeginHorizontal();
                GUI.color = new Color32(153, 50, 204, 255);
                GUILayout.Label($"<size=30>{Name}</size> <size=22>{Version}</size>", guiStyle);
                GUI.color = GUIColor;
                // SelectedTab = (MenuTab)GUILayout.Toolbar((int)SelectedTab, buttons.ToArray(), style: "TabBtn");
                GUILayout.EndHorizontal();
                GUILayout.EndArea();

                GUI.depth = -2;
                CursorPos.x = Input.mousePosition.x;
                CursorPos.y = Screen.height - Input.mousePosition.y;
                GUI.DrawTexture(CursorPos, _cursorTexture);
                Cursor.lockState = CursorLockMode.None;

                if (PlayerUI.window != null)
                    PlayerUI.window.showCursor = true;

                GUI.skin = null;
            }
        }

        private void MenuWindow(int windowID)
        {
            GUILayout.Space(0f);
            switch (Main.SelectedTab)
            {
                case MenuTab.Visuals:
                    VisualsTab.Tab();
                    break;
                case MenuTab.Aimbot:
                    AimbotTab.Tab();
                    break;
                case MenuTab.Misc:
                    MiscTab.Tab();
                    break;
                case MenuTab.Weapons:
                    WeaponsTab.Tab();
                    break;
                case MenuTab.Players:
                    PlayersTab.Tab();
                    break;
                case MenuTab.Settings:
                    SettingsTab.Tab();
                    break;
            }
            int fontSize = GUI.skin.button.fontSize;
            GUI.skin.button.fixedHeight = 30f;
            GUI.skin.button.alignment = TextAnchor.MiddleCenter;
            GUI.skin.button.fontSize = 15;
            Main.SelectedTab = (MenuTab)GUI.Toolbar(new Rect(0f, 0f, 700, 30f), (int)Main.SelectedTab, this.buttons.ToArray(), style: "TabBtn");
            GUI.skin.button.fixedHeight = 25f;
            GUI.skin.button.fontSize = fontSize;
            GUI.DragWindow();
        }
    }
}
