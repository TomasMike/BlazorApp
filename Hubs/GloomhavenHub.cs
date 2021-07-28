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
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task HexClicked(string hexId)
        {
            var x = hexId;
            //await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task SpawnObject(IGameComponent objectToSpawn, int row, int col)
        {
            await Clients.All.SendAsync("SpawnGameComponent", objectToSpawn, row, col);
        }
    }
}
