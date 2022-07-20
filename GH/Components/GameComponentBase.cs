using System;
using System.Collections.Generic;

namespace BlazorApp.GH.Components
{

    public abstract class GameComponentBase
    {
        public Guid Id { get; set; }

        public GameComponentBase()
        {
            Id = Guid.NewGuid();
        }

        public GameComponentBase(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// item1 = text, item2 = back
        /// </summary>
        /// <returns></returns>
        public ComponentColors GetComponentColors()
        {
            switch (this)
            {
                case CharacterComponent:
                    return GlobalSettings.CharacterComponentColors;
                case TerrainComponent:
                    return GlobalSettings.TerrainComponentColors;
                default:
                    return GlobalSettings.DefaultComponentColors;
                    break;
            }
        }

        public abstract string DisplayText();
        
    }


}
