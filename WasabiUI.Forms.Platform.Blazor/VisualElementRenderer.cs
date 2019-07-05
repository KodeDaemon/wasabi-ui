using System;
using System.Collections.Generic;
using System.ComponentModel;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
using WasabiUI.Forms.Components;
using WasabiUI.Forms.Core;
using Xamarin.Forms;

namespace WasabiUI.Forms.Platform.Blazor
{

    internal static class TypeInference
    {
        public static void CreateCascadingValue<T>(
            RenderTreeBuilder builder,
            int seq,
            int __seq0,
            T __arg0,
            int __seq1,
            RenderFragment __arg1)
        {
            builder.OpenComponent<CascadingValue<T>>(seq);
            builder.AddAttribute(__seq0, "Value", (object)__arg0);
            builder.AddAttribute(__seq1, "ChildContent", (MulticastDelegate)__arg1);
            builder.CloseComponent();
        }

        
    }

    [Flags]
    public enum VisualElementRendererFlags
    {
        Disposed = 1 << 0,
        AutoTrack = 1 << 1,
        AutoPackage = 1 << 2
    }

    

    public abstract class VisualElementRenderer<TElement> : ComponentBase, IVisualElementRenderer where TElement : VisualElement
    {
        bool disposedValue = false; // To detect redundant calls

        readonly PropertyChangedEventHandler _propertyChangedHandler;

        public TElement Element { get; private set; }

        VisualElement IVisualElementRenderer.Element => Element;

        public IComponentContainer ComponentContainer { get; }

        //public IComponentContainer NativeView => this;

        //event EventHandler<VisualElementChangedEventArgs> IVisualElementRenderer.ElementChanged
        //{
        //    add { _elementChangedHandlers.Add(value); }
        //    remove { _elementChangedHandlers.Remove(value); }
        //}

        readonly List<EventHandler<VisualElementChangedEventArgs>> _elementChangedHandlers =
            new List<EventHandler<VisualElementChangedEventArgs>>();

        VisualElementRendererFlags _flags = VisualElementRendererFlags.AutoPackage | VisualElementRendererFlags.AutoTrack;

        EventTracker _events;
        VisualElementPackager _packager;
        VisualElementTracker _tracker;

        event EventHandler<VisualElementChangedEventArgs> IVisualElementRenderer.ElementChanged
        {
            add { _elementChangedHandlers.Add(value); }
            remove { _elementChangedHandlers.Remove(value); }
        }

        public abstract void Render(RenderTreeBuilder builder);

        protected bool AutoPackage
        {
            get { return (_flags & VisualElementRendererFlags.AutoPackage) != 0; }
            set
            {
                if (value)
                    _flags |= VisualElementRendererFlags.AutoPackage;
                else
                    _flags &= ~VisualElementRendererFlags.AutoPackage;
            }
        }

        protected bool AutoTrack
        {
            get { return (_flags & VisualElementRendererFlags.AutoTrack) != 0; }
            set
            {
                if (value)
                    _flags |= VisualElementRendererFlags.AutoTrack;
                else
                    _flags &= ~VisualElementRendererFlags.AutoTrack;
            }
        }

        public IWasabiComponentHandle ComponentHandle { get; set; }

        //protected override bool HtmlNeedsFullEndElement => TagName == "div";

        protected VisualElementRenderer() //: base(tagName)
        {
            //Style.Overflow = "hidden";
            _propertyChangedHandler = OnElementPropertyChanged;
            ComponentContainer = new ComponentContainer();
        }

        

        protected string Id => IdGeneratorHelper.Generate("wasabi_id_");

        protected virtual void OnElementChanged(ElementChangedEventArgs<TElement> e)
        {
            var args = new VisualElementChangedEventArgs(e.OldElement, e.NewElement);
            for (int i = 0; i < _elementChangedHandlers.Count; i++)
            {
                _elementChangedHandlers[i](this, args);
            }

            var changed = ElementChanged;
            if (changed != null)
                changed(this, e);
        }

        public event EventHandler<ElementChangedEventArgs<TElement>> ElementChanged;

        void IVisualElementRenderer.SetElement(VisualElement element)
        {
            SetElement((TElement)element);
        }

        public void SetElement(TElement element)
        {
            var oldElement = Element;
            Element = element;

            if (oldElement != null)
                oldElement.PropertyChanged -= _propertyChangedHandler;

            if (element != null)
            {
                if (element.BackgroundColor != Xamarin.Forms.Color.Default || (oldElement != null && element.BackgroundColor != oldElement.BackgroundColor))
                    SetBackgroundColor(element.BackgroundColor);

                if (_tracker == null)
                {
                    _tracker = new VisualElementTracker(this);
                    _tracker.NativeControlUpdated += (sender, e) => UpdateNativeWidget();
                }

                if (AutoPackage && _packager == null)
                {
                    _packager = new VisualElementPackager(this);
                    _packager.Load();
                }

                if (AutoTrack && _events == null)
                {
                    _events = new EventTracker(this);
                    //_events.LoadEvents(this);
                }

                element.PropertyChanged += _propertyChangedHandler;
                //ClassName = Element?.StyleId;
            }

            OnElementChanged(new ElementChangedEventArgs<TElement>(oldElement, element));

            //if (element != null)
            //    SendVisualElementInitialized(element, this);

            if (Element != null && !string.IsNullOrEmpty(Element.AutomationId))
                SetAutomationId(Element.AutomationId);
        }

        public void SetElementSize(Size size)
        {
            Xamarin.Forms.Layout.LayoutChildIntoBoundingRegion(Element, new Rectangle(Element.X, Element.Y, size.Width, size.Height));
        }

        public virtual void SetControlSize(Size size)
        {
        }

        protected virtual void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == VisualElement.BackgroundColorProperty.PropertyName)
            {
                SetBackgroundColor(Element.BackgroundColor);
            }
            else if (e.PropertyName == Layout.IsClippedToBoundsProperty.PropertyName)
            {
                //UpdateClipToBounds ();
            }
            else if (e.PropertyName == "StyleId")
            {
                //ClassName = Element?.StyleId;
            }
        }

        //protected virtual void OnRegisterEffect(PlatformEffect effect)
        //{
        //    //effect.Container = this;
        //}

        protected virtual void SetAutomationId(string id)
        {
        }

        protected virtual void SetBackgroundColor(Xamarin.Forms.Color color)
        {
            //Style.BackgroundColor = color.ToOouiColor(Colors.Clear);
        }

        protected virtual void UpdateNativeWidget()
        {
        }

        protected virtual void SendVisualElementInitialized(VisualElement element, Element nativeView)
        {
            //element.SendViewInitialized(nativeView);
        }

        public virtual SizeRequest GetDesiredSize(double widthConstraint, double heightConstraint)
        {
            return new SizeRequest();//NativeView.GetSizeRequest(widthConstraint, heightConstraint);
        }

        public void UpdateLayout()
        {
            
        }

        protected virtual void RenderComponents(IEnumerable<IWasabiComponentHandle> components, RenderTreeBuilder builder)
        {
            foreach (var component in components)
            {
                component.Renderer.Render(builder);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
