using BlazorApp.Hubs;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Linq;
using BlazorApp.GH.Pages;
using BlazorApp.GH.Utilities;
using BlazorApp.GH.Components;
using BlazorApp.Models;
using System;

namespace BlazorApp.GH.Management
{
    public static class GHGameManager
    {
        public static IHubContext<GloomhavenHub> ihub;

        // TODO stale na flat je to zatial
        public static HexOrientation HexOrientationConfiguration;

        public static GameState GameState;
        public static Gloomhaven GloomhavenInstance => GameState.GHInstance;
        public static List<Hex> GloomhavenHexes => GameState.GHInstance.Hexes;
 
        public static List<SpawnObjectPart> StartLevel(int level)
        {
            GameState.Players = new List<Player>
            {
                new Player(){Name = "Tomo", PlayerNumber = 1}
            };


            var retVal = LevelLibrary.Levels[level];

            foreach (var item in retVal)
            {
                if (item.Component is CharacterComponent)
                {
                    var c = item.Component as CharacterComponent;
                    var p = GameState.Players.FirstOrDefault(_ => _.PlayerNumber == c.PlayerNumber);
                    p.FigureId = c.Id;
                }
            }
            return retVal;
        }

        public static void Move(GameComponentBase component, Hex destinationHex)
        {
            var originHex = Helper.GetHexByComponent(component);

            originHex.Components.Remove(component);
            destinationHex.Components.Add(component);
        }
    }

    public class GameState
    {
        public GameState(Gloomhaven gh)
        {
            GHInstance = gh;
            Players = new List<Player>();
        }
        public Gloomhaven GHInstance;

        public List<Player> Players;

        public GameBoardState GBState;

        public Player ActivePlayer;

    }
}
