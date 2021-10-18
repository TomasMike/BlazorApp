using BlazorApp.GH.Utilities;
using System;
using System.Collections.Generic;

namespace BlazorApp.GH.Components
{

    public class Character : GameComponentBase
    {
        public CharacterType CharacterType;
        public int PlayerNumber;

        public Character(CharacterType t)
        {
            CharacterType = t;
        }

        public override string DisplayText()
        {
            return CharacterType.ToString();
        }
    }


}
