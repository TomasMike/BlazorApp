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


        public static List<IGameComponent> GetAllComponentsInPlay()
        {
            var retVal = new List<IGameComponent>();
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
                throw new Exception("hrac s danym cislom nie je ");

            return retVal;
        }
    }
}
