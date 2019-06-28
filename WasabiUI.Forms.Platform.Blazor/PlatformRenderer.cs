using Microsoft.AspNetCore.Components;

namespace WasabiUI.Forms.Platform.Blazor
{
    public class PlatformRenderer : ComponentBase
    {
        internal PlatformRenderer(Platform platform)
        {
            Platform = platform;
        }

        public Platform Platform { get; set; }
    }
}
