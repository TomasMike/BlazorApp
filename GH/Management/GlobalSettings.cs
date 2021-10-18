using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using BlazorApp.Models;
using BlazorApp.GH.Pages;
using BlazorApp.GH.Utilities;

namespace BlazorApp.GH
{
    public static class GlobalSettings
    {

        public static string q = "";
        public static string q1 => "";

        public static int Size = 70;
        public static HexColor DefaultHexColor = HexColor.Teal;
        public static HexColor ClickableOptionHexColor = HexColor.Blue;
        public static HexColor OriginHexColor = HexColor.Green;

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
}
