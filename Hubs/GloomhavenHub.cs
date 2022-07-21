using BlazorApp.GH;
using BlazorApp.GH.Components;
using BlazorApp.GH.Management;
using BlazorApp.GH.Utilities;
using BlazorApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Hubs
{
    public class GloomhavenHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            // await Clients.All.SendMessage(user, message);
        }

        public async Task HexClicked(string hexId)
        {
            var x = hexId;
            await Clients.All.SendAsync("ReceiveMessage", "someone", $"clicked on hex [{hexId}]");
        }

        public void SpawnObject(GameComponentBase objectToSpawn, int row, int col)
        {
            switch (objectToSpawn)
            {
                case CharacterComponent c:
                    Clients.All.SendAsync("SpawnCharacter", JsonConvert.SerializeObject(c), row, col);
                    break;
                case TerrainComponent t:
                    Clients.All.SendAsync("SpawnTerrainComponent", JsonConvert.SerializeObject(t), row, col);
                    break;
                default:
                    break;
            }
        }


        public async Task StartClicked(int levelToLoad)
        {
            var objectsToInit = GHGameManager.StartLevel(levelToLoad);

            foreach (var item in objectsToInit)
            {
                SpawnObject(item.Component, item.TopCord, item.LeftCord);
            }

            GHGameManager.GameState.ActivePlayer = GHGameManager.GameState.Players.First();


        }

        public async Task Move(int playerNumber, short hexId)
        {
            GHGameManager.Move(Helper.GetCharacterComponent(Helper.GetPlayerByPlayerNumber(playerNumber)), Helper.GetHexById(hexId));
            await Clients.All.SendAsync("UpdpateYourselves");
        }

        //public async Task ToggleMoveState(int playerNumber, int moveDistance,GameBoardState newState)
        //{
        //    if (newState == GameBoardState.Move)
        //    {
        //        var r = GHGameManager.GetPossibleMoveHexes(playerNumber, moveDistance);
        //        Clients.Caller.SendAsync("EnableMoveState", r);

        //    }
        //    else
        //    {
        //        foreach (var hex in GHGameManager.GloomhavenHexes)
        //        { 
        //            Clients.All.SendAsync("ChangeColor", hex.Column, hex.Row, (int)GlobalSettings.DefaultHexColor);
        //        }
        //    }

        //}


    }
}
