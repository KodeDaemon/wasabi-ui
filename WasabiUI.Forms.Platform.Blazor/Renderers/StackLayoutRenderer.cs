using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.AspNetCore.Components.RenderTree;
using WasabiUI.Forms.Components;
using WasabiUI.Forms.Core;
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

            builder.OpenComponent<WasabiStackLayout>(1);

            builder.AddAttribute(3, "Margin", Element.Margin);
            //builder.AddAttribute(5, "Children", Element.Children);

            RenderComponents(ComponentContainer.Children, builder);

            builder.CloseElement();
        }

        protected void RenderComponents(IEnumerable<IWasabiComponentHandle> components, RenderTreeBuilder builder)
        {
            foreach (var component in components.Where(c => c.Renderer.GetType() != typeof(StackLayoutRenderer)))
            {
                builder.OpenElement(3, "div");
                component.Renderer.Render(builder);
                builder.CloseElement();
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<StackLayout> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                if (ComponentHandle == null)
                {
                    // TODO: WTF??? SetNativeControl(CreateComponentHandle());
                }
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var shouldRedraw = false;

            base.OnElementPropertyChanged(sender, e);
            //if (e.PropertyName == BoxView.ColorProperty.PropertyName)
            //    SetBackgroundColor(Element.BackgroundColor);
            //else if (e.PropertyName == BoxView.CornerRadiusProperty.PropertyName)
            //    SetCornerRadius();
            //else if (e.PropertyName == VisualElement.IsVisibleProperty.PropertyName && Element.IsVisible)
            //    SetNeedsDisplay();

            if (e.PropertyName == StackLayout.MarginProperty.PropertyName)
            {
                shouldRedraw = true;
            }
            else if (e.PropertyName == Label.TextProperty.PropertyName)
            {
                shouldRedraw = true;
            }

            if (shouldRedraw)
                FormsApplication.Current.Redraw();
        }
    }
}
