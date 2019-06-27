using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
using Xamarin.Forms;

namespace WasabiUI.Forms.Platform.Blazor
{
    public class FormsApplication : ComponentBase
    {
        Application _application;
        internal Platform Platform { get; private set; }

        protected void LoadApplication(Application application)
        {
            if (_application != null)
                _application.PropertyChanged -= ApplicationOnPropertyChanged;

            _application = application ?? throw new ArgumentNullException(nameof(application));
            //((IApplicationController)application).SetAppIndexingProvider(new AndroidAppIndexProvider(this));
            Xamarin.Forms.Application.SetCurrentApplication(application);

            //SetSoftInputMode();

            application.PropertyChanged += ApplicationOnPropertyChanged;

            SetMainPage();
        }

        void ApplicationOnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "MainPage")
            {
            //    UpdateMainPage();
            }
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            IVisualElementRenderer renderer = Platform.GetRenderer(_application.MainPage);

            //builder.AddContent(0, );
            renderer.NativeView.Build(builder);
        }

        void SetMainPage()
        {
            if (!Forms.IsInitialized)
                throw new InvalidOperationException("Call Forms.Init (Activity, Bundle) before this");

            if (Platform != null)
            {
                Platform.SetPage(_application.MainPage);
                return;
            }

            //PopupManager.ResetBusyCount(this);

            Platform = new Platform();

//            if (_application != null)
//            {
//#pragma warning disable CS0618 // Type or member is obsolete
//                // The Platform property is no longer necessary, but we have to set it because some third-party
//                // library might still be retrieving it and using it
//                _application.Platform = Platform;
//#pragma warning restore CS0618 // Type or member is obsolete
//            }

            Platform.SetPage(_application.MainPage);
            //_layout.AddView(Platform.GetViewGroup());
        }
    }
}
