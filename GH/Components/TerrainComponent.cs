
using BlazorApp.GH.Utilities;

namespace BlazorApp.GH.Components
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
