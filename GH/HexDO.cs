using BlazorApp.Hubs;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using BlazorApp.Models;
using System.Linq;
using BlazorApp.GH.Pages;
using BlazorApp.GH.Components;

namespace BlazorApp.GH
{

    public class HexDO
    {
        public HexDO(int id)
        {
            Id = id;
        }
        public int Column;
        public int Row;
        public List<GameComponentBase> Components = new List<GameComponentBase>();
        public int Id;
        public string Color;
    }
}
