using WasabiUI.Forms.Core.Renderers;
using Xamarin.Forms;

namespace WasabiUI.Forms.Components.Interfaces
{
    
    public interface IEntry : IWasabiInputView
    {
        ReturnType ReturnType { get; set; }

        string Placeholder { get; set; }

        Color PlaceholderColor { get; set; }

        bool IsPassword { get; set; }

        string Text { get; set; }

        Color TextColor { get; set; }

        TextAlignment HorizontalTextAlignment { get; set; }

        string FontFamily { get; set; }

        double FontSize { get; set; }

        FontAttributes FontAttributes { get; set; }

        bool IsTextPredictionEnabled { get; set; }

        int CursorPosition { get; set; }

        int SelectionLength { get; set; }

    }
}
