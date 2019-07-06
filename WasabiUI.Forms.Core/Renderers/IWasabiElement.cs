using Xamarin.Forms;

namespace WasabiUI.Forms.Core.Renderers
{
    public interface IWasabiElement
    {
        Menu Menu { get; set; }

        string AutomationId { get; set; }

        string ClassId { get; set; }

    }
}
