using Xamarin.Forms;

namespace WasabiUI.Forms.Core.Renderers
{
    public interface IWasabiView : IWasabiVisualElement
    {
        LayoutOptions VerticalOptions { get; set; }

        LayoutOptions HorizontalOptions { get; set; }

        Thickness Margin { get; set; }

        double MarginLeft { get; set; }

        double MarginTop { get; set; }

        double MarginRight { get; set; }

        double MarginBottom { get; set; }

    }

}
