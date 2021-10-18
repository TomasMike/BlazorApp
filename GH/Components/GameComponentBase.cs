using System;
using System.Collections.Generic;

namespace BlazorApp.GH.Components
{

    public abstract class GameComponentBase 
    {
        public readonly Guid Id = Guid.NewGuid();

        public abstract string DisplayText();
        
    }


}
