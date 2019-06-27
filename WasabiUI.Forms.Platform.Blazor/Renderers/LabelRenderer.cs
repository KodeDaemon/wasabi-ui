using System.ComponentModel;
using Microsoft.AspNetCore.Components.RenderTree;
using WasabiUI.Forms.Platform.Blazor.Components;
using Xamarin.Forms;

namespace WasabiUI.Forms.Platform.Blazor.Renderers
{
    public class LabelRenderer : ViewRenderer<Label, WasabiLabel>
    {
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            (new WasabiLabel()).Build(builder);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //base.OnElementPropertyChanged(sender, e);
            //if (e.PropertyName == BoxView.ColorProperty.PropertyName)
            //    SetBackgroundColor(Element.BackgroundColor);
            //else if (e.PropertyName == BoxView.CornerRadiusProperty.PropertyName)
            //    SetCornerRadius();
            //else if (e.PropertyName == VisualElement.IsVisibleProperty.PropertyName && Element.IsVisible)
            //    SetNeedsDisplay();
        }
    }
}
