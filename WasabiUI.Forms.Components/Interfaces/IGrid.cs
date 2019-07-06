using WasabiUI.Forms.Core.Renderers;
using Xamarin.Forms;

namespace WasabiUI.Forms.Components.Interfaces
{
    public interface IGrid : IWasabiView
    {
        int Row{get; set;} 

        int RowSpan{get; set;} 

        int Column{get; set;} 

        int ColumnSpan{get; set;} 
        double RowSpacing{get; set;} 

        double ColumnSpacing{get; set;} 

        ColumnDefinitionCollection ColumnDefinitions{get; set;} 

        RowDefinitionCollection RowDefinitions{get; set;} 

    }
}
