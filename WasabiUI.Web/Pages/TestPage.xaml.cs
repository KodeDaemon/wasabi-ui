using System;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WasabiUI.Web.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage
    {
        public TestPage()
        {
            InitializeComponent();
        }

        public int Counter { get; set; }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            CounterLabel.Text = $"{Counter++}";
        }
    }
}
