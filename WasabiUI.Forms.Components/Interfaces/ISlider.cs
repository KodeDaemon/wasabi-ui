using System.Windows.Input;
using WasabiUI.Forms.Core.Renderers;
using Xamarin.Forms;

namespace WasabiUI.Forms.Components.Interfaces
{
    public interface ISlider : IWasabiView
    {
        double Minimum{get; set;} 

        double Maximum{get; set;} 

        double Value{get; set;} 

        Color MinimumTrackColor{get; set;}

        Color MaximumTrackColor{get; set;}

        Color ThumbColor{get; set;}

        ImageSource ThumbImageSource{get; set;}

        ICommand DragStartedCommand{get; set;}

        ICommand DragCompletedCommand{get; set;}

    }
}
