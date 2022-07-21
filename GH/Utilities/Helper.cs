using BlazorApp.Hubs;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using BlazorApp.Models;
using System.Linq;
using BlazorApp.GH.Pages;
using BlazorApp.GH.Management;
using System;
using BlazorApp.GH.Utilities;
using BlazorApp.GH.Components;

namespace BlazorApp.GH
{

    public static class Helper
    {
        /// <summary>
        /// returns hex, null if it doesnt exist
        /// </summary>
        /// <param name="column"></param>
        /// <param name="row"></param>
        public static Hex GetHexByCoord(int column, int row)
        {
            return GHGameManager.GameState.GHInstance.GetHexByCoords(column, row);
        }
        public static bool DoesHexExist(int column, int row)
        {
            return GetHexByCoord(column,row) != null;
        }


        public static List<GameComponentBase> GetAllComponentsInPlay()
        {
            var retVal = new List<GameComponentBase>();
            foreach (var hex in GHGameManager.GloomhavenHexes)
            {
                retVal.AddRange(hex.Components);
            }

            return retVal;
        }

        public static Player GetPlayerByPlayerNumber(int playerNumber)
        {
            var retVal = GHGameManager.GameState.Players.FirstOrDefault(_ => _.PlayerNumber == playerNumber);

            if (retVal == null)
                throw new Exception($"Player with number:[{playerNumber}] isnt in the game.");

            return retVal;
        }

        public static Hex GetHexByPlayer(Player player)
        {
            return GetAllComponentsInPlay().First(_ => _.Id == player.FigureId).GetCurrentLocationHex();
        }

        public static List<Hex> GetPossibleMoveHexes(Player player, int moveDistance)
        {
            return GetHexByPlayer(player).GetHexesInRange(moveDistance);
        }

        public static Hex GetHexByComponent(GameComponentBase component)
        {
            return GHGameManager.GloomhavenHexes.FirstOrDefault(h => h.Components.Contains(component));
        }

        public static CharacterComponent GetCharacterComponent(Player player)
        {
            return GetHexByPlayer(player).Components.First(c => c is CharacterComponent) as CharacterComponent;
        }

        public static Hex GetHexById(short id)
        {
            return GHGameManager.GloomhavenHexes.First(h => h.Id == id);
        }
    }
}
