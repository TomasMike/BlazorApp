
using BlazorApp.GH.Utilities;

namespace BlazorApp.GH.Components
{

    public class TerrainComponent : GameComponentBase
    {
        public TerrainType TerrainType;

        public override string DisplayText()
        {
            return TerrainType.ToString();
        }
    }
}
