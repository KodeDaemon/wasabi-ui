using System;
using Microsoft.AspNetCore.Components.RenderTree;
using WasabiUI.Forms.Core;
using Xamarin.Forms;

namespace WasabiUI.Forms.Platform.Blazor.Renderers
{
    public class PageRenderer : ComponentContainer, IVisualElementRenderer
    {
        bool _disposed;
        VisualElementPackager _packager;

        public VisualElement Element { get; private set; }

        public event EventHandler<VisualElementChangedEventArgs> ElementChanged;

        public IComponentContainer NativeView
        {
            get { return _disposed ? null : this; }
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            _packager = new VisualElementPackager(this);
            _packager.Load();

            base.BuildRenderTree(builder);
        }

        public void SetElement(VisualElement element)
        {
            VisualElement oldElement = Element;
            Element = element;

            RaiseElementChanged(new VisualElementChangedEventArgs(oldElement, element));
        }

        void RaiseElementChanged(VisualElementChangedEventArgs e)
        {
            OnElementChanged(e);
            ElementChanged?.Invoke(this, e);
        }

        protected virtual void OnElementChanged(VisualElementChangedEventArgs e)
        {
        }

        public SizeRequest GetDesiredSize(double widthConstraint, double heightConstraint)
        {
            throw new NotImplementedException();
        }

        public void UpdateLayout()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
