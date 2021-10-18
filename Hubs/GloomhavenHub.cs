using BlazorApp.GH.Components;
using BlazorApp.GH.Management;
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
            //await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public void SpawnObject(GameComponentBase objectToSpawn, int row, int col)
        {
            switch (objectToSpawn)
            {
                case Character c:
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
          
        }

        public async Task ToggleMoveState(int playerNumber, int moveDistance)
        {
            GHGameManager.ToggleMoveState(playerNumber, moveDistance);
        }
    }
}
