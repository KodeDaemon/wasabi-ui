using Xamarin.Forms;

namespace WasabiUI.Forms.Core.Renderers
{
    public interface IWasabiContentView : IWasabiView
    {
        View Content{get; set;} 

    }
}