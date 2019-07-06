using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components.RenderTree;
using Xamarin.Forms;

namespace WasabiUI.Forms.Core.Renderers
{
    public interface IWasabiView : IWasabiVisualElement
    {
        LayoutOptions VerticalOptions { get; set; }

        LayoutOptions HorizontalOptions { get; set; }

        [StyleProperty("margin")]
        Thickness Margin { get; set; }

        double MarginLeft { get; set; }

        double MarginTop { get; set; }

        double MarginRight { get; set; }

        double MarginBottom { get; set; }

    }


    [AttributeUsage(AttributeTargets.Property)]
    public sealed class StylePropertyAttribute : Attribute
    {
        public string CssPropertyName { get; }
        //public string BindablePropertyName { get; }
        //public Type TargetType { get; }
        //public Type PropertyOwnerType { get; set; }
        //public BindableProperty BindableProperty { get; set; }
        //public bool Inherited { get; set; } = false;


        public StylePropertyAttribute(string cssPropertyName)
        {
            CssPropertyName = cssPropertyName;
            //BindablePropertyName = bindablePropertyName;
            //TargetType = targetType;
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public sealed class StylePropertyFormatterAttribute : Attribute
    {
        public string CssPropertyName { get; }
        //public string BindablePropertyName { get; }
        //public Type TargetType { get; }
        //public Type PropertyOwnerType { get; set; }
        //public BindableProperty BindableProperty { get; set; }
        //public bool Inherited { get; set; } = false;


        public StylePropertyFormatterAttribute(string cssPropertyName)
        {
            CssPropertyName = cssPropertyName;
            //BindablePropertyName = bindablePropertyName;
            //TargetType = targetType;
        }
    }

    public interface IStylePropertyFormatter
    {
        IEnumerable<Tuple<string, object>> Generate();
    }
}
