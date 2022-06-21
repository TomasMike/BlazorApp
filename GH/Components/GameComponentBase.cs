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

        public abstract string DisplayText();
        
    }


}
