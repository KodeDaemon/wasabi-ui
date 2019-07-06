using System.Collections.Generic;
using Xamarin.Forms;

namespace WasabiUI.Forms.Core.Renderers
{
    public interface IWasabiLayout<T> : IWasabiLayout, IViewContainer<T> where T : View
    {
        
    }

    public interface IWasabiLayout : IWasabiPadding
    {
        bool IsClippedToBounds { get; set; }

        bool CascadeInputTransparent { get; set; }

    }
}
