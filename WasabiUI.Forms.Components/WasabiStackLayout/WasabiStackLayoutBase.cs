using System;
using System.Collections.Generic;
using System.Text;
using WasabiUI.Forms.Core;

namespace WasabiUI.Forms.Components
{
    public class WasabiStackLayoutBase : BuildableBaseComponent
    {
        public WasabiStackLayoutBase()
        {
            
        }

        protected override void OnInit()
        {

            var isHorizontal = Orientation == Orientation.Landscape;

            var sb = new StringBuilder();
            sb.Append(Style);
            sb.Append($"grid-auto-flow: {(isHorizontal ? "column" : "row")}; ");
            sb.Append($"grid-auto-{(isHorizontal ? "columns" : "rows")}: max-content; ");
            sb.Append($"grid-template-{(isHorizontal ? "columns" : "rows")}: none; ");

            if (Spacing != 0)
                sb.Append($"grid-gap: {Spacing}px; ");

            Style = sb.ToString();
            base.OnInit();
        }

        public Orientation Orientation => DeviceState.DeviceOrientation;

        public string Background { get; set; } = "transparent";

        public double Spacing { get; set; } = 0;
    }
}
