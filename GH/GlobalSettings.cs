using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using BlazorApp.Models;
using BlazorApp.GH.Pages;

namespace BlazorApp.GH
{
    public static class GlobalSettings
    {
        public static HexOrientation HexOrientationConfiguration;

        public static string q = "";
        public static string q1 => "";

        public static int Size = 30;

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

    public static class HelperStuff
    {
        public static Hex GetHexByCoords(this Gloomhaven gh, int top, int left)
        {
            return gh.Hexes.FirstOrDefault(h => h.TopCoord == top && h.LeftCoord == left);
        }
    }
}
