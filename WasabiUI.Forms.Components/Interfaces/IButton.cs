using WasabiUI.Forms.Core.Renderers;
using Xamarin.Forms;

namespace WasabiUI.Forms.Components.Interfaces
{
    public interface IButton : IWasabiView
    {

        Button.ButtonContentLayout ContentLayout { get; set; }

        string Text { get; set; }

        Color TextColor { get; set; }

        Font Font { get; set; }

        string FontFamily { get; set; }

        double FontSize { get; set; }

        FontAttributes FontAttributes { get; set; }

        double BorderWidth { get; set; }

        Color BorderColor { get; set; }

        int CornerRadius { get; set; }

        ImageSource ImageSource { get; set; }

        bool IsPressed { get; set; }

    }
}
