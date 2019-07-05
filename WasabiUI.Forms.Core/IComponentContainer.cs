using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace WasabiUI.Forms.Core
{

    public interface IComponentContainer //: IComponent
    {
        //RenderHandle RenderHandle { get; }

        List<IWasabiComponentHandle> Children { get; }

        void RemoveChild(IWasabiComponentHandle child);

        void AppendChild(IWasabiComponentHandle child);

        void Configure(RenderHandle renderHandle);

        void Render();
    }
}

