using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using WasabiUI.Forms.Core;

namespace WasabiUI.Forms.Platform.Blazor
{
    public interface IVisualNativeElementRenderer : IVisualElementRenderer
    {
        event EventHandler<PropertyChangedEventArgs> ElementPropertyChanged;
        event EventHandler ControlChanging;
        event EventHandler ControlChanged;

        BuildableComponent Control { get; }
    }
}
