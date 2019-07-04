using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.RenderTree;
using WasabiUI.Forms.Components;
using Xamarin.Forms;

namespace WasabiUI.Forms.Platform.Blazor.Renderers
{
    public class SliderRenderer : ViewRenderer<Slider, WasabiSlider>
    {
        public override void Render(RenderTreeBuilder builder)
        {
            builder.OpenComponent<WasabiSlider>(1);
            builder.CloseComponent();
        }
    }
}
