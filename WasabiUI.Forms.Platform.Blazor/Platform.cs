using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using WasabiUI.Forms.Core;
using WasabiUI.Forms.Platform.Blazor.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace WasabiUI.Forms.Platform.Blazor
{
    public class Platform : BindableObject, INavigation, IDisposable
    {
        private readonly PlatformRenderer _renderer;

        internal Page Page { get; set; }

        internal static readonly BindableProperty RendererProperty = BindableProperty.CreateAttached("Renderer", typeof(IVisualElementRenderer), typeof(Platform), default(IVisualElementRenderer),
            propertyChanged: (bindable, oldvalue, newvalue) =>
            {
                var ve = bindable as VisualElement;
                if (ve != null && newvalue == null)
                    ve.IsPlatformEnabled = false;
            });

        internal PlatformRenderer PlatformRenderer => _renderer;

        internal Platform()
        {
            _renderer = new PlatformRenderer(this);
        }

        public IReadOnlyList<Page> ModalStack => throw new NotImplementedException();

        public IReadOnlyList<Page> NavigationStack => throw new NotImplementedException();

        public static IVisualElementRenderer GetRenderer(BindableObject bindable)
        {
            return (IVisualElementRenderer)bindable.GetValue(RendererProperty);
        }

        public static void SetRenderer(BindableObject bindable, IVisualElementRenderer value)
        {
            bindable.SetValue(Platform.RendererProperty, value);
        }

        internal void SetPage(Page newRoot, RenderHandle renderHandle = default)
        {
            if (newRoot == null)
                return;
            if (Page != null)
                throw new NotImplementedException();
            Page = newRoot;
            AddChild(Page, false, renderHandle);
        }

        void AddChild(VisualElement view, bool layout = false, RenderHandle renderHandle = default)
        {
            if (GetRenderer(view) != null)
                return;

            IVisualElementRenderer renderView = CreateRenderer(view, renderHandle);
            SetRenderer(view, renderView);

            //if (layout)
            //    view.Layout(new Rectangle(0, 0, _context.FromPixels(_renderer.Width), _context.FromPixels(_renderer.Height)));

            //_renderer.AddView(renderView.View);
        }

        /// <summary>
        /// Gets the renderer associated with the <c>view</c>. If it doesn't exist, creates a new one.
        /// </summary>
        /// <returns>Renderer associated with the <c>view</c>.</returns>
        /// <param name="element">VisualElement for which the renderer is going to be returned.</param>
        public static IVisualElementRenderer GetOrCreateRenderer(VisualElement element)
        {
            return GetRenderer(element) ?? CreateRenderer(element);
        }

        internal static IVisualElementRenderer CreateRenderer(VisualElement element, RenderHandle renderHandle = default)
        {
            IVisualElementRenderer renderer = Registrar.Registered.GetHandlerForObject<IVisualElementRenderer>(element) ?? new DefaultRenderer();
            var componentContainer = ((ComponentContainer)renderer.ComponentContainer);

            componentContainer._renderHandle = renderHandle;
            //renderer.ComponentContainer.Configure(renderHandle);

            renderer.SetElement(element);
            return renderer;
        }

        public void InsertPageBefore(Page page, Page before)
        {
            throw new NotImplementedException();
        }

        public Task<Page> PopAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Page> PopAsync(bool animated)
        {
            throw new NotImplementedException();
        }

        public Task<Page> PopModalAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Page> PopModalAsync(bool animated)
        {
            throw new NotImplementedException();
        }

        public Task PopToRootAsync()
        {
            throw new NotImplementedException();
        }

        public Task PopToRootAsync(bool animated)
        {
            throw new NotImplementedException();
        }

        public Task PushAsync(Page page)
        {
            throw new NotImplementedException();
        }

        public Task PushAsync(Page page, bool animated)
        {
            throw new NotImplementedException();
        }

        public Task PushModalAsync(Page page)
        {
            throw new NotImplementedException();
        }

        public Task PushModalAsync(Page page, bool animated)
        {
            throw new NotImplementedException();
        }

        public void RemovePage(Page page)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
