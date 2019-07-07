using System.ComponentModel;
using Microsoft.AspNetCore.Components.RenderTree;
using WasabiUI.Forms.Components;
using WasabiUI.Forms.Core;
using Xamarin.Forms;

namespace WasabiUI.Forms.Platform.Blazor.Renderers
{
    public class LabelRenderer : ViewRenderer<Label, WasabiLabel>
    {
        public override void Render(RenderTreeBuilder builder)
        {
            builder.OpenElement(1, "label");
   
            builder.AddAttribute(1, "Text", Element.Text);
            builder.CloseElement();
            
            //builder.OpenComponent<WasabiLabel>(0);
            //builder.AddAttribute(1, "Text", Element.Text);
            //builder.CloseComponent();
        }

        protected override IWasabiComponentHandle<WasabiLabel> CreateComponentHandle()
        {
            return new WasabiComponentHandle<WasabiLabel>();
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                if (ComponentHandle == null)
                {
                    SetNativeControl(CreateComponentHandle());
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

            if(shouldRedraw)
                FormsApplication.Current.Redraw();
        }
    }
}
