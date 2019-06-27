using System.ComponentModel;
using System.Diagnostics;
using Microsoft.AspNetCore.Components.RenderTree;
using WasabiUI.Forms.Platform.Blazor.Components;
using Xamarin.Forms;

namespace WasabiUI.Forms.Platform.Blazor.Renderers
{
    public class ButtonRenderer : ViewRenderer<Button, WasabiButton>
    {
        private WasabiButton NativeButton => Control;

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            Control.Build(builder);
        }

        protected override WasabiButton CreateNativeControl()
        {
            return new WasabiButton();
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    SetNativeControl(CreateNativeControl());

                    Debug.Assert(Control != null, "Control != null");

                    NativeButton.OnClickAction = (button) =>
                    {
                        var renderer = button.Renderer;
                        ((IButtonController)renderer.Element).SendClicked();
                    };

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
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == Button.TextProperty.PropertyName)
                UpdateText();

            //if (e.PropertyName == Button.TextColorProperty.PropertyName)
            //    UpdateTextColor();
            //else if (e.PropertyName == Button.FontProperty.PropertyName)
            //    UpdateFont();
        }

        void UpdateText()
        {
            //var oldText = NativeButton.Text;
            NativeButton.Text = Element.Text;

            //// If we went from or to having no text, we need to update the image position
            //if (IsNullOrEmpty(oldText) != IsNullOrEmpty(NativeButton.Text))
            //{
            //    UpdateBitmap();
            //}
        }
    }
}
