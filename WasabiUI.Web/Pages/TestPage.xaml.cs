using System;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WasabiUI.Web.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage : ContentPage
    {
        public TestPage()
        {
            InitializeComponent();

            ButtonCommand = new Command(() =>
            {
                Debug.WriteLine("Button pressed.");
            });
        }

        public ICommand ButtonCommand { private set; get; }

        private void Button_OnClicked(object sender, EventArgs e)
        {
        }
    }
}