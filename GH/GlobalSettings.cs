using System.Collections.Generic;

namespace BlazorApp.GH
{
    public static class GlobalSettings
    {
        public static int HexHeight;

        public static int HexWidth;

        public static HexOrientation HexOrientationConfiguration;

        public static string q = "";
        public static string q1 => "";

        public static Dictionary<int, HexSizeConfig> HexSizeConfigurations = new Dictionary<int, HexSizeConfig>
        {
            {
                1,
                new HexSizeConfig()
                {
                    Height = 50,
                    Width = 43,
                    InnerPartHeight = 29,
                    InnerPartWidth = 50,
                }
            },
            {
                3,
                new HexSizeConfig()
                {
                    Height = 150,
                    Width = 129,
                    InnerPartHeight = 87,
                    InnerPartWidth = 150,
                }
            },
        };
    }

    public enum HexOrientation
    {
        Flat,
        Pointy
    }

    public struct HexSizeConfig
    {
        public int Height;
        public int Width;
        public int InnerPartHeight;
        public int InnerPartWidth;
    }
}
