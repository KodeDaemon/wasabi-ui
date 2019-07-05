using Xamarin.Forms;

namespace WasabiUI.Forms.Core.Renderers
{
    public interface IWasabiPadding : IWasabiView
    {
        Thickness Padding { get; set; }

        double PaddingLeft { get; set; }

        double PaddingTop { get; set; }

        double PaddingRight { get; set; }

        double PaddingBottom { get; set; }
    }
}