using Xamarin.Forms;

namespace WasabiUI.Forms.Core.Renderers
{
    public interface IWasabiTemplatedView : IWasabiLayout
    {
        ControlTemplate ControlTemplate{get; set;} 
    }
}