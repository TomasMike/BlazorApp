using BlazorApp.Hubs;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using BlazorApp.Models;
using System.Linq;
using BlazorApp.GH.Pages;
using BlazorApp.GH.Components;

namespace BlazorApp.GH
{



    public class SpawnObjectPart
    {
        public SpawnObjectPart(IGameComponent component, int top, int left)
        {
            Component = component;
            TopCord = top;
            LeftCord = left;
        }

        public IGameComponent Component;
        public int TopCord;
        public int LeftCord;
    }
}
