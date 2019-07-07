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

    public abstract class ViewRenderer<TView> : ViewRenderer<TView, IComponent> where TView : View
    {
    }

    public abstract class ViewRenderer<TView, TComponent> : VisualElementRenderer<TView>, IVisualNativeElementRenderer
        where TView : View
        where TComponent: IComponent
    {
        
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
                e.NewElement.FocusChangeRequested += ViewOnFocusChangeRequested;
            }

            UpdateIsEnabled();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            _elementPropertyChanged?.Invoke(this, e);
        }

        protected override void SetAutomationId(string id)
        {

        }

        protected override void SetBackgroundColor(Xamarin.Forms.Color color)
        {

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

        }

        protected override void SendVisualElementInitialized(VisualElement element, Element nativeView)
        {
            //base.SendVisualElementInitialized(element, Control);
        }

        void UpdateIsEnabled()
        {
            
        }

        void ViewOnFocusChangeRequested(object sender, VisualElement.FocusRequestArgs focusRequestArgs)
        {
        }

        public virtual void Render(RenderTreeBuilder builder)
        {
            throw new NotImplementedException();
        }

        //public abstract void Render(RenderTreeBuilder builder);
    }
}
