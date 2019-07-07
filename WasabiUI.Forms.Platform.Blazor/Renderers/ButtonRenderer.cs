using System.ComponentModel;
using System.Diagnostics;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
using WasabiUI.Forms.Components;
using WasabiUI.Forms.Core;
using Xamarin.Forms;

namespace WasabiUI.Forms.Platform.Blazor.Renderers
{
    public class ButtonRenderer : ViewRenderer<Button, WasabiButton>
    {
        //protected override void BuildRenderTree(RenderTreeBuilder builder)
        //{
        //    builder.OpenComponent<WasabiButton>(0);
        //    builder.AddAttribute(2, "text", Element.Text);
        //    builder.AddAttribute(3, "onclick", EventCallback.Factory.Create(this, OnClick));
        //    builder.CloseComponent();

        //}

        public override void Render(RenderTreeBuilder builder)
        {
            builder.OpenComponent<WasabiButton>(0);
            builder.AddAttribute(1, "Text", Element.Text);
            builder.AddAttribute(3, "onclick", EventCallback.Factory.Create(this, OnClick));
            builder.CloseComponent();
        }

        private void OnClick(UIMouseEventArgs e)
        {
            ((IButtonController)Element).SendClicked();
        }

        protected override IWasabiComponentHandle<WasabiButton> CreateComponentHandle()
        {
            //var nativeControl = new WasabiButton();
            //nativeControl.Configure(new RenderHandle());
            return new WasabiComponentHandle<WasabiButton>();
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                
                if (ComponentHandle == null)
                {
                    SetNativeControl(CreateComponentHandle());

                    ///Debug.Assert(Control != null, "Control != null");

                    //Control.OnClickAction = (button) =>
                    //{
                    //    var renderer = button.Renderer;
                    //    ((IButtonController)renderer.Element).SendClicked();
                    //};

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

            //if (e.PropertyName == Button.TextProperty.PropertyName)
                UpdateText();

            //if (e.PropertyName == Button.TextColorProperty.PropertyName)
            //    UpdateTextColor();
            //else if (e.PropertyName == Button.FontProperty.PropertyName)
            //    UpdateFont();
        }

        void UpdateText()
        {
            //var oldText = NativeButton.Text;
            //Control.Text = Element.Text;

            //// If we went from or to having no text, we need to update the image position
            //if (IsNullOrEmpty(oldText) != IsNullOrEmpty(NativeButton.Text))
            //{
            //    UpdateBitmap();
            //}
        }
    }
}
