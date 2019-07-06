using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.AspNetCore.Components.RenderTree;
using WasabiUI.Forms.Components;
using Xamarin.Forms;
using Thickness = Xamarin.Forms.Thickness;

namespace WasabiUI.Forms.Platform.Blazor.Renderers
{
    public class SliderRendererBase : ViewRenderer<Slider>
    {
        public override void Render(RenderTreeBuilder builder)
        {
            
        }

 
    }

    public class SliderRenderer : SliderRendererBase
    {
        public override void Render(RenderTreeBuilder builder)
        {
            builder.OpenComponent<WasabiSlider>(1);
            builder.CloseComponent();
        }
    }
}
