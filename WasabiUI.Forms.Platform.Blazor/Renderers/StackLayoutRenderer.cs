using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.Extensions.DependencyInjection;
using WasabiUI.Forms.Components;
using WasabiUI.Forms.Core;
using WasabiUI.Forms.Core.Renderers;
using Xamarin.Forms;

namespace WasabiUI.Forms.Platform.Blazor.Renderers
{
    public class StackLayoutRenderer : VisualElementRenderer<StackLayout>, IVisualNativeElementRenderer
    {
        public event EventHandler<PropertyChangedEventArgs> ElementPropertyChanged;
        public event EventHandler ControlChanging;
        public event EventHandler ControlChanged;
        
        public void Render(RenderTreeBuilder builder)
        {
            builder.OpenElement(3, "div");

            BuildStyle(builder);

            RenderComponents(ComponentContainer.Children, builder);

            builder.CloseElement();
        }

        public void BuildStyle(RenderTreeBuilder builder)
        {
            var formatters = PlatformServices.ServiceProvider.GetService<IStylePropertyFormatterFactory>();

            var mapper = PlatformServices.ServiceProvider.GetService<IMapper>();

            var control = mapper.Map<WasabiStackLayout>(Element);

            var r = new Dictionary<string, string>();

            foreach (var propertyInfo in control.GetType().GetProperties())
            {
                var attrib = propertyInfo.GetAttributes<StylePropertyAttribute>(control.GetType()).FirstOrDefault();

                if (attrib != null)
                {
                    var prop = propertyInfo.GetValue(control);

                    var q = formatters.GetFormatter(attrib.CssPropertyName);
                    var formatter = (IStylePropertyFormatter)Activator.CreateInstance(q, prop);
                    var results = formatter.Generate();

                    foreach (var result in results)
                    {
                        r[result.Item1] = ConvertMe(result.Item2);
                    }
                }
            }

            builder.AddAttribute(11, "style", DictionaryToProperties(r));
        }

        private string DictionaryToProperties(Dictionary<string, string> dictionary)
        {
            var sb = new StringBuilder();
            foreach (var pair in dictionary)
            {
                sb.Append($"{pair.Key}: {pair.Value};");
            }

            return sb.ToString();
        }

        private string ConvertMe(object value)
        {
            return value.ToString();
        }

        protected void RenderComponents(IEnumerable<IWasabiComponentHandle> components, RenderTreeBuilder builder)
        {
            foreach (var component in components.Where(c => c.Renderer.GetType() != typeof(StackLayoutRenderer)))
            {
                builder.OpenElement(3, "div");
                component.Renderer.Render(builder);
                builder.CloseElement();
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<StackLayout> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                if (ComponentHandle == null)
                {
                    // TODO: WTF??? SetNativeControl(CreateComponentHandle());
                }
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var shouldRedraw = false;

            base.OnElementPropertyChanged(sender, e);
            //if (e.PropertyName == BoxView.ColorProperty.PropertyName)
            //    SetBackgroundColor(Element.BackgroundColor);
            //else if (e.PropertyName == BoxView.CornerRadiusProperty.PropertyName)
            //    SetCornerRadius();
            //else if (e.PropertyName == VisualElement.IsVisibleProperty.PropertyName && Element.IsVisible)
            //    SetNeedsDisplay();

            if (e.PropertyName == StackLayout.MarginProperty.PropertyName)
            {
                shouldRedraw = true;
            }
            else if (e.PropertyName == Label.TextProperty.PropertyName)
            {
                shouldRedraw = true;
            }

            if (shouldRedraw)
                FormsApplication.Current.Redraw();
        }
    }
}
