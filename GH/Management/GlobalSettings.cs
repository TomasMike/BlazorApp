using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using BlazorApp.Models;
using BlazorApp.GH.Pages;
using BlazorApp.GH.Utilities;
using System.Drawing;

namespace BlazorApp.GH
{
    public static class GlobalSettings
    {

        public static string q = "";
        public static string q1 => "";

        public static int Size = 70;

        public static string DefaultHexBackColor = "darkgreen";

        public static string DefaultComponentTextColor = "black";
        public static string DefaultComponentBackColor = "none";

        public static string ActionOriginHexColor = "orange";
        public static string ClickableOptionHexColor = "blue";

        public static ComponentColors CharacterComponentColors = new ComponentColors { BackColor = "pink", TextColor = "yellow" };
        public static ComponentColors TerrainComponentColors = new ComponentColors { BackColor = "brown", TextColor = "yellow" };
        public static ComponentColors DefaultComponentColors = new ComponentColors { BackColor = "white", TextColor = "black" };

        
         
        public static Dictionary<int, HexSizeConfig> HexSizeConfigurations = new Dictionary<int, HexSizeConfig>
        {
            {
                1,
                new HexSizeConfig()
                {
                    Size = 100,
                    Height = 30,
                    Width = 52,
                    InnerPartHeight = 52,
                    InnerPartWidth = 30
                }
            },
            {
                3,
                new HexSizeConfig()
                {
                }
            },
        };


    }


    public struct ComponentColors
    {
        public string TextColor;
        public string BackColor;
    }
}
