using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.RenderTree;
using Xamarin.Forms;

namespace WasabiUI.Forms.Platform.Blazor.Renderers
{
    public class StackLayoutRenderer : VisualElementRenderer<StackLayout>, IVisualNativeElementRenderer
    {
        public event EventHandler<PropertyChangedEventArgs> ElementPropertyChanged;
        public event EventHandler ControlChanging;
        public event EventHandler ControlChanged;
        public void Render(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            foreach (var component in ComponentContainer.Children )
            {
                builder.OpenElement(1, "div");
                ((IVisualNativeElementRenderer)component.Renderer).Render(builder);
                builder.CloseElement();
            }
            builder.CloseElement();
        }
    }
}
