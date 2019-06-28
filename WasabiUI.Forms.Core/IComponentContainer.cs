using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using WasabiUI.Forms.Platform.Blazor;

namespace WasabiUI.Forms.Core
{

    public interface IComponentContainer : IComponent
    {
        
        List<BuildableComponent> Children { get; set; }

        void RemoveChild(IBuildableComponent child);

        void AppendChild(IBuildableComponent child);


    }
}

