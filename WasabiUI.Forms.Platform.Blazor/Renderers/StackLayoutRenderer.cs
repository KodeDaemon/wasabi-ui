using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
using WasabiUI.Forms.Components;
using WasabiUI.Forms.Core;
using WasabiUI.Forms.Platform.Blazor.Components;
using Xamarin.Forms;

namespace WasabiUI.Forms.Platform.Blazor.Renderers
{
    public class StackLayoutRendererBase : VisualElementRenderer<StackLayout>
    {
        public override void Render(RenderTreeBuilder builder)
        {
            //throw new System.NotImplementedException();
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
    }

    public class StackLayoutRenderer : StackLayoutRendererBase
    {
        public override void Render(RenderTreeBuilder builder)
        {
            base.Render(builder);

            builder.OpenElement(3, "div");

            RenderComponents(ComponentContainer.Children, builder);

            builder.CloseElement();
        }

        //protected override IWasabiComponentHandle<WasabiStackLayout> CreateComponentHandle()
        //{
        //    return new WasabiComponentHandle<WasabiStackLayout>();
        //}

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

            //base.OnElementPropertyChanged(sender, e);
            //if (e.PropertyName == BoxView.ColorProperty.PropertyName)
            //    SetBackgroundColor(Element.BackgroundColor);
            //else if (e.PropertyName == BoxView.CornerRadiusProperty.PropertyName)
            //    SetCornerRadius();
            //else if (e.PropertyName == VisualElement.IsVisibleProperty.PropertyName && Element.IsVisible)
            //    SetNeedsDisplay();

            if (e.PropertyName == Label.TextColorProperty.PropertyName)
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
