using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
using WasabiUI.Forms.Components;
using WasabiUI.Forms.Core;
using Xamarin.Forms;

namespace WasabiUI.Forms.Platform.Blazor.Renderers
{
    public class PageRendererBase : VisualElementRenderer<Page>
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public override void Render(RenderTreeBuilder builder)
        {
            
        }
    }

    public class PageRenderer : PageRendererBase
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

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            //_packager = new VisualElementPackager(this);
            //_packager.Load();

            base.BuildRenderTree(builder);
        }

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
        public override void Render(RenderTreeBuilder builder)
        {
            base.Render(builder);

            builder.OpenElement(1, "div");
            builder.AddContent(2, "I am content");

            RenderComponents(ComponentContainer.Children, builder);

            builder.CloseElement();
        }
    }
}
