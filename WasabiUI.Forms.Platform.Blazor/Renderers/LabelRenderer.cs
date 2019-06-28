using System.ComponentModel;
using System.Diagnostics;
using Microsoft.AspNetCore.Components.RenderTree;
using WasabiUI.Forms.Core;
using WasabiUI.Forms.Platform.Blazor.Components;
using Xamarin.Forms;

namespace WasabiUI.Forms.Platform.Blazor.Renderers
{
    public class LabelRenderer : ViewRenderer<Label, WasabiLabel>
    {
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            Control.Build(builder);
        }

        protected override WasabiLabel CreateNativeControl()
        {
            return new WasabiLabel();
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    SetNativeControl(CreateNativeControl());

                    Debug.Assert(Control != null, "Control != null");

                    //SetControlPropertiesFromProxy();

                    //_useLegacyColorManagement = e.NewElement.UseLegacyColorManagement();

                    //_buttonTextColorDefaultNormal = Control.TitleColor(UIControlState.Normal);
                    //_buttonTextColorDefaultHighlighted = Control.TitleColor(UIControlState.Highlighted);
                    //_buttonTextColorDefaultDisabled = Control.TitleColor(UIControlState.Disabled);

                    //Control.TouchUpInside += OnButtonTouchUpInside;
                    //Control.TouchDown += OnButtonTouchDown;
                }

                //UpdateFont();
                //UpdateTextColor();
                //_buttonLayoutManager?.Update();
            }
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

            UpdateText();
        }

        void UpdateText()
        {
            Control.Text = Element.Text;
        }
    }
}
