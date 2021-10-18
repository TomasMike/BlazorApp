using System;
using System.Collections.Generic;

namespace BlazorApp.GH.Utilities
{
    public enum TerrainType
    {
        Obstacle,
        DifficultTerrain,

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

    //https://www.redblobgames.com/grids/hexagons/
    public enum HexOrientation
    {
        OddVertical, // pointy, vertical columns are under each other, odd columns are moved half a cell down
        EvenVertical, // pointy, vertical columns are under each other, even columns are moved half a cell down
        OddHorizontal, // flat , horizontal rows are next to each other, odd rows are moved half a cell to the right
        EvenHorizontal, // flat , horizontal rows are next to each other, even rows are moved half a cell to the right
    }

    public enum GameBoardState
    {
        Default,
        Move,
    }

    public enum HexColor
    {
        Blue,
        Green,
        Teal
    }

}
