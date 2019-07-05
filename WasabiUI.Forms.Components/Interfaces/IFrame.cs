using WasabiUI.Forms.Core.Renderers;
using Xamarin.Forms;

namespace WasabiUI.Forms.Components.Interfaces
{
    public interface IFrame : IWasabiContentView
    {
        Color BorderColor{get; set;} 

        bool HasShadow{get; set;} 

        int CornerRadius{get; set;} 
    }
}
