using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.Extensions.DependencyInjection;
using WasabiUI.Forms.Components;
using WasabiUI.Forms.Core;
using WasabiUI.Forms.Core.Renderers;
using Xamarin.Forms;

namespace WasabiUI.Forms.Platform.Blazor.Renderers
{
    

    public class StackLayoutRenderer : VisualElementRenderer<StackLayout>
    {
        public override void Render(RenderTreeBuilder builder)
        {
            builder.OpenElement(3, "div");

            BuildStyle<WasabiStackLayout>(builder);

            RenderComponents(ComponentContainer.Children, builder);

            builder.CloseElement();
        }

        protected override void BuildStyle<T>(RenderTreeBuilder builder)
        {
            base.BuildStyle<T>(builder);
        }

        protected override string DictionaryToProperties(Dictionary<string, string> dictionary)
        {
            return base.DictionaryToProperties(dictionary);
        }

        protected override string ConvertStylePropertyValue(object value)
        {
            return base.ConvertStylePropertyValue(value);
        }

        protected override void RenderComponents(IEnumerable<IWasabiComponentHandle> components, RenderTreeBuilder builder)
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
