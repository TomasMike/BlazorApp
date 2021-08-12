using System;
using System.Collections.Generic;

namespace BlazorApp.GH
{

    public class TerrainComponent : ComponentBase, IGameComponent
    {
        public TerrainType TerrainType;

        public string DisplayText()
        {
            return TerrainType.ToString();
        }
    }
}
