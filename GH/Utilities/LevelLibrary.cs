using BlazorApp.Hubs;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using BlazorApp.Models;
using System.Linq;
using BlazorApp.GH.Pages;
using BlazorApp.GH.Components;

namespace BlazorApp.GH.Utilities
{

    public static class LevelLibrary
    {
        public static Dictionary<int, List<SpawnObjectPart>> Levels = new()
        {
            {
                1,
                new()
                {
                    new SpawnObjectPart(new Character(CharacterType.Spellweaver) { PlayerNumber = 1 }, 0, 0),
                    new SpawnObjectPart(new TerrainComponent() { TerrainType = TerrainType.Obstacle }, 1, 1)
                }
            }
        };
    }
}
