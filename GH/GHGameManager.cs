using BlazorApp.Hubs;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace BlazorApp.GH
{

    public static class GHGameManager
    {
        public static IHubContext<Hub<IGloomhavenHubClient>> ihub;

        public static void Start()
        {
            ihub.Clients.All.SendAsync("SpawnObject", new Character(), 0, 0);
        }
    }
}
