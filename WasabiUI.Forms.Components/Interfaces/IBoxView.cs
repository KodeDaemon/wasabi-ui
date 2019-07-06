using WasabiUI.Forms.Core.Renderers;
using Xamarin.Forms;

namespace WasabiUI.Forms.Components.Interfaces
{
    public interface IBoxView : IWasabiView
    {
        Color Color{get; set;} 

        int CornerRadius{get; set;} 
    }
}
