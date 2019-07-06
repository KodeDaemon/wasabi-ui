using WasabiUI.Forms.Core.Renderers;
using Xamarin.Forms;

namespace WasabiUI.Forms.Components.Interfaces
{
    public interface ILabel : IWasabiView
    {
        TextAlignment HorizontalTextAlignment { get; set; }

        TextAlignment VerticalTextAlignment { get; set; }

        Color TextColor { get; set; }

        Font Font { get; set; }

        string Text { get; set; }

        string FontFamily { get; set; }

        double FontSize { get; set; }

        FontAttributes FontAttributes { get; set; }

        TextDecorations TextDecorations { get; set; }

        LineBreakMode LineBreakMode { get; set; }

        double LineHeight { get; set; }

        int MaxLines { get; set; }
    }
}
