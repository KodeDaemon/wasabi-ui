using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Layouts;
using WasabiUI.Forms.Platform.Blazor;
using WasabiUI.Web.Shared;

namespace WasabiUI.Web.Pages
{
    [Layout(typeof(MainLayout))]
    [Route("/")]
    public class MainPage : FormsApplication
    {
        protected override void OnInit()
        {
            Forms.Platform.Blazor.Forms.Init();
            LoadApplication(new FormsApp());
        }
    }
}
