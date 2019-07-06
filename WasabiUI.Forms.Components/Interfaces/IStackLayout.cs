using WasabiUI.Forms.Core.Renderers;
using Xamarin.Forms;

namespace WasabiUI.Forms.Components.Interfaces
{
    public interface IStackLayout : IWasabiLayout<View>
    {
        StackOrientation Orientation { get; set; }

        double Spacing { get; set; }
    }
}
