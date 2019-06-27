using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace WasabiUI.Forms.Platform.Blazor
{
    public class BlazorDeviceInfo : DeviceInfo
    {
        public override Size PixelScreenSize => new Size(800, 600);

        public override Size ScaledScreenSize => new Size(800, 600);

        public override double ScalingFactor => 1.0d;
    }
}
