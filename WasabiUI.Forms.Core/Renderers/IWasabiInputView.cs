using Xamarin.Forms;

namespace WasabiUI.Forms.Core.Renderers
{
    public interface IWasabiInputView : IWasabiView
    {
        Keyboard Keyboard { get; set; }

        bool IsSpellCheckEnabled { get; set; }

        int MaxLength { get; set; }

        bool IsReadOnly { get; set; }

    }
}