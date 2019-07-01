using System.ComponentModel;
using Microsoft.AspNetCore.Components.RenderTree;
using WasabiUI.Forms.Components;
using WasabiUI.Forms.Core;
using WasabiUI.Forms.Platform.Blazor.Components;
using Xamarin.Forms;

namespace WasabiUI.Forms.Platform.Blazor.Renderers
{
    public class EntryRenderer : ViewRenderer<Entry, WasabiTextField>
    {
        public override void Render(RenderTreeBuilder builder)
        {
            builder.OpenComponent<WasabiTextField>(0);
            builder.AddAttribute(1, "Text", Element.Text);
            builder.CloseComponent();
        }

        protected override IWasabiComponentHandle<WasabiTextField> CreateComponentHandle()
        {
            return new WasabiComponentHandle<WasabiTextField>();
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
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

            if (shouldRedraw)
                FormsApplication.Current.Redraw();
        }
    }
}
