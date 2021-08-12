using System;
using System.Collections.Generic;

namespace BlazorApp.GH
{

    public class Character : ComponentBase, IGameComponent
    {
        public CharacterType CharacterType;

        public string DisplayText()
        {
            return CharacterType.ToString();
        }
    }


}
