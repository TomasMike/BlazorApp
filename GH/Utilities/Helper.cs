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
        public static HexDO GetHexByCoords(int column, int row)
        {
            return GHGameManager.GameState.Hexes.FirstOrDefault(h => h.Column == column && h.Row == row);
        }
        public static bool DoesHexExist(int column, int row)
        {
            return GetHexByCoords(column,row) != null;
        }


        public static List<GameComponentBase> GetAllComponentsInPlay()
        {
            var retVal = new List<GameComponentBase>();
            foreach (var hex in GHGameManager.GameState.Hexes)
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

        public static HexDO GetHexByPlayer(Player player)
        {
            return GetAllComponentsInPlay().First(_ => _.Id == player.FigureId).GetCurrentLocationHex();
        }

        public static List<HexDO> GetPossibleMoveHexes(Player player, int moveDistance)
        {
            return GetHexByPlayer(player).GetHexesInRange(moveDistance);
        }

        public static HexDO GetHexByComponent(GameComponentBase component)
        {
            return GHGameManager.GameState.Hexes.FirstOrDefault(h => h.Components.Contains(component));
        }

        public static CharacterComponent GetCharacterComponent(Player player)
        {
            return GetHexByPlayer(player).Components.First(c => c is CharacterComponent) as CharacterComponent;
        }

        public static HexDO GetHexById(short id)
        {
            return GHGameManager.GameState.Hexes.First(h => h.Id == id);
        }

      

    }
}
