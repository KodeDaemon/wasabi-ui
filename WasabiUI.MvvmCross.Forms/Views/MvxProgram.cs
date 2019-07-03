using MvvmCross;
using MvvmCross.Forms.Presenters;
using WasabiUI.MvvmCross.Core;
using Xamarin.Forms;

namespace WasabiUI.MvvmCross.Forms.Views
{
    public class MvxProgram : global::WasabiUI.Forms.Platform.Blazor.FormsApplication
    {
        private Application _formsApplication;
        protected Application FormsApplication
        {
            get
            {
                if (_formsApplication == null)
                {
                    var formsPresenter = Mvx.IoCProvider.Resolve<IMvxFormsViewPresenter>();
                    _formsApplication = formsPresenter.FormsApplication;
                }

                return _formsApplication;
            }
        }

        private static global::WasabiUI.Forms.Platform.Blazor.FormsApplication _application;
        protected static global::WasabiUI.Forms.Platform.Blazor.FormsApplication Application
        {
            get
            {
                if (_application == null)
                {
                    _application = new MvxProgram();
                }

                return _application;
            }
        }

        protected override void OnInit()
        {
            //base.OnCreate();

            var setup = MvxWasabiUISetupSingleton.EnsureSingletonAvailable(Application);
            setup.EnsureInitialized();

            LoadApplication(FormsApplication);
        }

        static void Main(string[] args)
        {
            //global::WasabiUI.Forms.Platform.Blazor.Forms.Init(Application);
            //Application.Run(args);
        }
    }
}
