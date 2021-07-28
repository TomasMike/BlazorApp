using BlazorApp.Hubs;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace BlazorApp.GH
{

    public static class GHGameManager
    {
        public static IHubContext<GloomhavenHub> ihub;

        public static void Start()
        {
            
        }
    }
}
