using WasabiUI.Web.Pages;
using Xamarin.Forms;

namespace WasabiUI.Web
{
    public class FormsApp : Application
    {
        public FormsApp()
        {
            //InitializeComponent();

            MainPage = new TestPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
