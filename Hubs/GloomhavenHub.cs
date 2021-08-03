using BlazorApp.GH;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.SignalR;
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

        public async Task SpawnObject(IGameComponent objectToSpawn, int row, int col)
        {
            switch (objectToSpawn)
            {
                case Character c:
                    await Clients.All.SendAsync("SpawnCharacter", c, row, col);
                    break;
                case TerrainComponent t:
                    await Clients.All.SendAsync("SpawnTerrainComponent", t, row, col);
                    break;
                default:
                    break;
            }
        }


        public async Task StartClicked()
        {
            await SpawnObject(new Character(), 0, 0);
            await SpawnObject(new TerrainComponent() { TerrainType = TerrainType.Obstacle}, 1, 1);
        }
    }

    public interface IGloomhavenHubClient
    {
        Task SpawnGameComponent(IGameComponent objectToSpawn, int row, int col);

        Task SendMessage(string user, string message);

        //Task HexClicked(string hexId);
    }

    public class TestSimpleClass
    {
        public string Name { get; set; }
        public int Age { get; set; }

    }
}
