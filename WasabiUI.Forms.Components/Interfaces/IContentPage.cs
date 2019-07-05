using WasabiUI.Forms.Core.Renderers;
using Xamarin.Forms;

namespace WasabiUI.Forms.Components.Interfaces
{
    public interface IContentPage : IWasabiTemplatedView
    {
        View Content{get; set;} 
    }
}
