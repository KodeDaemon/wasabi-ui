using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Components;
using WasabiUI.Forms.Core;

namespace WasabiUI.Forms.Components
{
    public class WasabiSliderBase : WasabiComponentBase
    {
        public WasabiSliderBase()
        {
            
        }

        protected override void OnAfterRender()
        {
            base.OnAfterRender();
            Orientation = PlatformServices.DeviceState.DeviceOrientation;
        }

        public Orientation Orientation { get; private set; }

        public string Background { get; set; } = "transparent";

        public double Spacing { get; set; } = 0;
    }
}
