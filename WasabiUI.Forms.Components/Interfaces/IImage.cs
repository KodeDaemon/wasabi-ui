using WasabiUI.Forms.Core.Renderers;
using Xamarin.Forms;

namespace WasabiUI.Forms.Components.Interfaces
{
    public interface IImage : IWasabiView
    {
        ImageSource Source{get; set;} 

        Aspect Aspect{get; set;} 

        bool IsOpaque{get; set;} 

        bool IsLoading{get; set;} 
    }
}
