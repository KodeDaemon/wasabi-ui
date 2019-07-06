using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace WasabiUI.Forms.Core
{
    public interface IWasabiComponentHandle
    {
        Type Type { get; set; }
        IVisualNativeElementRenderer Renderer { get; set; }
    }

    public interface IWasabiComponentHandle<T> : IWasabiComponentHandle where T : IComponent
    {
    }
}
