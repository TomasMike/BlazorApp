using System.Collections.Generic;

namespace BlazorApp.GH
{
    public static class GlobalSettings
    {
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

    public interface IGameComponent
    {
        string DisplayText();
    }

    public class Character : IGameComponent
    {
        public CharacterType CharacterType;

        public string DisplayText()
        {
            return CharacterType.ToString();
        }
    }

    public enum CharacterType
    {
        Tinkerer,
        Mindthief,
        Cragheart,
        Rogue,
        Spellweaver,
        Brute
    }

    public class Player
    {
        public string Name;
    }
}
