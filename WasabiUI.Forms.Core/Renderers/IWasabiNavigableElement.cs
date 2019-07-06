using Xamarin.Forms;

namespace WasabiUI.Forms.Core.Renderers
{
    public interface IWasabiNavigableElement : IWasabiElement
    {
        INavigation Navigation { get; set; }

        Style Style { get; set; }
    }
}