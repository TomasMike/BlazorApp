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

        public readonly static GameState GameState = new GameState();
        

        //private static GameState gameState;

        //public static Gloomhaven GloomhavenInstance => GameState.GHInstance;
        //public static List<Hex> GloomhavenHexes => GameState.GHInstance.Hexes;

        


        public static List<SpawnObjectPart> StartLevel(int level)
        {
            GameState.Players = new List<Player>
            {
                new Player(){Name = "Tomo", PlayerNumber = 1}
            };


            var retVal = LevelLibrary.Levels[level];

            int idCounter = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    GameState.Hexes.Add(new HexDO(idCounter++) { Row = i, Column = j });
                }
            }

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

        public static void Move(GameComponentBase component, HexDO destinationHex)
        {
            var originHex = Helper.GetHexByComponent(component);

            originHex.Components.Remove(component);
            destinationHex.Components.Add(component);
        }
    }


    public class GameState
    {
        public GameState()
        {
        }
        public List<HexDO> Hexes = new List<HexDO>();

        public List<Player> Players = new List<Player>();

        public GameBoardState GBState;

        public Player ActivePlayer;

    }
}
