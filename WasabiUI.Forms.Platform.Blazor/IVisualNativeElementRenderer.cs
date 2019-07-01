using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.RenderTree;
using WasabiUI.Forms.Core;
using IComponent = Microsoft.AspNetCore.Components.IComponent;

namespace WasabiUI.Forms.Platform.Blazor
{
    public interface IVisualNativeElementRenderer : IVisualElementRenderer
    {
        event EventHandler<PropertyChangedEventArgs> ElementPropertyChanged;
        event EventHandler ControlChanging;
        event EventHandler ControlChanged;

        //IComponent Control { get; }

        void Render(RenderTreeBuilder builder);
    }
}
