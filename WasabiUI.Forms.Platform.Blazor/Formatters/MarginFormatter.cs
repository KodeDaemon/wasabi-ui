using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components.RenderTree;
using WasabiUI.Forms.Core.Renderers;
using Xamarin.Forms;

namespace WasabiUI.Forms.Platform.Blazor.Formatters
{
    [StylePropertyFormatter("margin")]
    public class MarginFormatter : IStylePropertyFormatter
    {
        private Thickness _thickness;

        public MarginFormatter(Thickness thickness)
        {
            _thickness = thickness;
        }

        public void Generate(RenderTreeBuilder builder)
        {
            
        }

        public IEnumerable<Tuple<string, object>> Generate()
        {
            return new List<Tuple<string, object>>
            {
                new Tuple<string, object>("margin-left", $"{_thickness.Left}px" ),
                new Tuple<string, object>("margin-top", $"{_thickness.Top}px"),
                new Tuple<string, object>("margin-right", $"{_thickness.Right}px"),
                new Tuple<string, object>("margin-bottom", $"{_thickness.Bottom}px")
            };
        }
    }
}
