using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Components.RenderTree;
using WasabiUI.Forms.Core;
using Xamarin.Forms;
using IComponent = Microsoft.AspNetCore.Components.IComponent;

namespace WasabiUI.Forms.Platform.Blazor.Renderers
{
    public abstract class ViewRenderer : ViewRenderer<View, IComponent>
    {
    }

    public abstract class ViewRenderer<TView, TComponent> : VisualElementRenderer<TView>, IVisualNativeElementRenderer
        where TView : View
        where TComponent: IComponent
    {
        public TComponent Control { get; private set; }
        
        //IComponent IVisualNativeElementRenderer.Control => Control;

        event EventHandler<PropertyChangedEventArgs> _elementPropertyChanged;
        event EventHandler _controlChanging;
        event EventHandler _controlChanged;

        event EventHandler<PropertyChangedEventArgs> IVisualNativeElementRenderer.ElementPropertyChanged
        {
            add { _elementPropertyChanged += value; }
            remove { _elementPropertyChanged -= value; }
        }

        event EventHandler IVisualNativeElementRenderer.ControlChanging
        {
            add { _controlChanging += value; }
            remove { _controlChanging -= value; }
        }
        event EventHandler IVisualNativeElementRenderer.ControlChanged
        {
            add { _controlChanged += value; }
            remove { _controlChanged -= value; }
        }

        protected virtual IWasabiComponentHandle<TComponent> CreateComponentHandle()
        {
            return default;
        }

        /// <summary>
        /// Determines whether the native control is disposed of when this renderer is disposed
        /// Can be overridden in deriving classes 
        /// </summary>
        protected virtual bool ManageNativeControlLifetime => true;

        //protected override bool HtmlNeedsFullEndElement => TagName == "div";

        public ViewRenderer()
        {
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            //if (disposing && Control != null && ManageNativeControlLifetime)
            //{
            //    Control = null;
            //}
        }

        protected override void OnElementChanged(ElementChangedEventArgs<TView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
                e.OldElement.FocusChangeRequested -= ViewOnFocusChangeRequested;

            if (e.NewElement != null)
            {
                if (Control != null && e.OldElement != null && e.OldElement.BackgroundColor != e.NewElement.BackgroundColor || e.NewElement.BackgroundColor != Xamarin.Forms.Color.Default)
                    SetBackgroundColor(e.NewElement.BackgroundColor);

                e.NewElement.FocusChangeRequested += ViewOnFocusChangeRequested;
            }

            UpdateIsEnabled();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (Control != null)
            {
                if (e.PropertyName == VisualElement.IsEnabledProperty.PropertyName)
                    UpdateIsEnabled();
                else if (e.PropertyName == VisualElement.BackgroundColorProperty.PropertyName)
                    SetBackgroundColor(Element.BackgroundColor);
            }

            base.OnElementPropertyChanged(sender, e);
            _elementPropertyChanged?.Invoke(this, e);
        }

        //protected override void OnRegisterEffect(PlatformEffect effect)
        //{
        //    base.OnRegisterEffect(effect);
        //    //effect.Control = Control;
        //}

        protected override void SetAutomationId(string id)
        {
            if (Control == null)
                base.SetAutomationId(id);
            else
            {
            }
        }

        protected override void SetBackgroundColor(Xamarin.Forms.Color color)
        {
            if (Control == null)
                return;

            //Control.Style.BackgroundColor = color.ToOouiColor(OouiTheme.BackgroundColor);
        }

        protected void SetNativeControl(IWasabiComponentHandle wasabiComponentHandle)
        {
            ComponentHandle = wasabiComponentHandle;
            ComponentHandle.Renderer = this;
            //Control = (TNativeView)element;
            //Control.Renderer = this;

            if (Element.BackgroundColor != Xamarin.Forms.Color.Default)
                SetBackgroundColor(Element.BackgroundColor);

            UpdateIsEnabled();

            this.ComponentContainer.AppendChild(wasabiComponentHandle);
        }

        public override void SetControlSize(Size size)
        {
            if (Control != null)
            {
                //Control.Style.Width = size.Width;
                //Control.Style.Height = size.Height;
            }
        }

        protected override void SendVisualElementInitialized(VisualElement element, Element nativeView)
        {
            //base.SendVisualElementInitialized(element, Control);
        }

        void UpdateIsEnabled()
        {
            //if (Element == null || Control == null)
            //    return;

            //var uiControl = Control as Ooui.FormControl;
            //if (uiControl == null)
            //    return;
            //uiControl.IsDisabled = !Element.IsEnabled;
        }

        void ViewOnFocusChangeRequested(object sender, VisualElement.FocusRequestArgs focusRequestArgs)
        {
        }

        //public abstract void Render(RenderTreeBuilder builder);
    }
}
