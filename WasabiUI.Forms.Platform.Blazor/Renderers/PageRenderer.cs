using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Components.RenderTree;
using WasabiUI.Forms.Components;
using WasabiUI.Forms.Core;
using Xamarin.Forms;

namespace WasabiUI.Forms.Platform.Blazor.Renderers
{
    public class PageRenderer : VisualElementRenderer<Page>, IVisualNativeElementRenderer
//VisualElementRenderer<Page>, IVisualNativeElementRenderer
    //ComponentContainer, IVisualElementRenderer
    {
        //bool _disposed;
        //VisualElementPackager _packager;

        //public VisualElement Element { get; private set; }

        //public event EventHandler<VisualElementChangedEventArgs> ElementChanged;

        //public IComponentContainer NativeView
        //{
        //    get { return _disposed ? null : this; }
        //}

        //public IWasabiComponentHandle ComponentHandle { get; set; }

        //protected override void BuildRenderTree(RenderTreeBuilder builder)
        //{
        //    _packager = new VisualElementPackager(this);
        //    _packager.Load();

        //    base.BuildRenderTree(builder);
        //}

        //public void SetElement(VisualElement element)
        //{
        //    VisualElement oldElement = Element;
        //    Element = element;

        //    RaiseElementChanged(new VisualElementChangedEventArgs(oldElement, element));
        //}

        //void RaiseElementChanged(VisualElementChangedEventArgs e)
        //{
        //    OnElementChanged(e);
        //    ElementChanged?.Invoke(this, e);
        //}

        //protected virtual void OnElementChanged(VisualElementChangedEventArgs e)
        //{
        //}

        //public SizeRequest GetDesiredSize(double widthConstraint, double heightConstraint)
        //{
        //    throw new NotImplementedException();
        //}

        //public void UpdateLayout()
        //{
        //    throw new NotImplementedException();
        //}

        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}

        //public void Render(RenderTreeBuilder builder)
        //{
        //    _packager = new VisualElementPackager(this);
        //    _packager.Load();

        //    base.Render();
        //}
        public event EventHandler<PropertyChangedEventArgs> ElementPropertyChanged;
        public event EventHandler ControlChanging;
        public event EventHandler ControlChanged;
        public void Render(RenderTreeBuilder builder)
        {
            ComponentContainer.Render();
        }
    }
}
