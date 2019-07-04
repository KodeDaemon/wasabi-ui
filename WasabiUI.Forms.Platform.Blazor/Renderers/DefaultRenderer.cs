using System;
using System.Linq;
using Microsoft.AspNetCore.Components.RenderTree;
using WasabiUI.Forms.Components;
using WasabiUI.Forms.Core;
using Xamarin.Forms;

namespace WasabiUI.Forms.Platform.Blazor.Renderers
{
    public class DefaultRenderer : VisualElementRenderer<View>
    {
        //protected override IWasabiComponentHandle<WasabiLabel> CreateComponentHandle()
        //{
        //    return new WasabiComponentHandle<WasabiLabel>();
        //}

        //protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        //{
        //    base.OnElementChanged(e);

        //    if (e.NewElement != null)
        //    {
        //        if (Control == null)
        //        {
        //            SetNativeControl(CreateComponentHandle());
        //        }
        //    }
        //}
        public override void Render(RenderTreeBuilder builder)
        {
            var hasChildren = ComponentContainer.Children.Any();

            if (hasChildren)
            {
                builder.OpenElement(1, "div");
                RenderComponents(ComponentContainer.Children, builder);
                builder.CloseElement();
            }
            else
            {
                builder.AddMarkupContent(2, $"<div class=\"error\">A renderer was not found for the {this.Element.GetType().FullName} component.</div>\r\n");
            }

        }
    }
}
