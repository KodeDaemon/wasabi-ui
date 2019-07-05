using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross;
using MvvmCross.Core;
using MvvmCross.ViewModels;
using WasabiUI.Forms.Platform.Blazor;
using WasabiUI.MvvmCross.Core;
using Xamarin.Forms;

namespace WasabiUI.MvvmCross.Forms.Core
{
    public abstract class MvxFormsWasabiUIApplication : FormsApplication, IMvxWasabiUIApplication
    {
        public MvxFormsWasabiUIApplication() : base()
        {
            RegisterSetup();
        }

        protected override void OnInit()
        {
            var instance = MvxWasabiUISetupSingleton.EnsureSingletonAvailable(this);
            instance.EnsureInitialized();

            RunAppStart();

            FireLifetimeChanged(MvxLifetimeEvent.Launching);
        }
        //public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        //{
        //    if (Window == null)
        //        Window = new UIWindow(UIScreen.MainScreen.Bounds);

        //    var instance = MvxIosSetupSingleton.EnsureSingletonAvailable(this, Window);
        //    instance.EnsureInitialized();

        //    RunAppStart(launchOptions);

        //    FireLifetimeChanged(MvxLifetimeEvent.Launching);
        //    return base.FinishedLaunching(uiApplication, launchOptions);
        //}

        protected virtual void RunAppStart(object hint = null)
        {
            if (Mvx.IoCProvider.TryResolve(out IMvxAppStart startup) && !startup.IsStarted)
                startup.Start(GetAppStartHint(hint));

            LoadFormsApplication();
        }

        protected virtual object GetAppStartHint(object hint = null)
        {
            return hint;
        }

        protected virtual void LoadFormsApplication()
        {
            var instance = MvxWasabiUISetupSingleton.EnsureSingletonAvailable(this);
            LoadApplication(instance.PlatformSetup<MvxFormsWasabiUISetup>().FormsApplication);
        }

        //public override void WillEnterForeground(UIApplication uiApplication)
        //{
        //    FireLifetimeChanged(MvxLifetimeEvent.ActivatedFromMemory);
        //    base.WillEnterForeground(uiApplication);
        //}

        //public override void DidEnterBackground(UIApplication uiApplication)
        //{
        //    FireLifetimeChanged(MvxLifetimeEvent.Deactivated);
        //    base.DidEnterBackground(uiApplication);
        //}

        //public override void WillTerminate(UIApplication uiApplication)
        //{
        //    FireLifetimeChanged(MvxLifetimeEvent.Closing);
        //    base.WillTerminate(uiApplication);
        //}

        private void FireLifetimeChanged(MvxLifetimeEvent which)
        {
            LifetimeChanged?.Invoke(this, new MvxLifetimeEventArgs(which));
        }

        protected virtual void RegisterSetup()
        {
        }

        public event EventHandler<MvxLifetimeEventArgs> LifetimeChanged;
    }

    public abstract class MvxFormsWasabiUIApplication<TMvxWasabiUISetup, TApplication, TFormsApplication> : MvxFormsWasabiUIApplication
        where TMvxWasabiUISetup : MvxFormsWasabiUISetup<TApplication, TFormsApplication>, new()
        where TApplication : class, IMvxApplication, new()
        where TFormsApplication : Application, new()
    {
        protected override void RegisterSetup()
        {
            this.RegisterSetupType<TMvxWasabiUISetup>();
        }
    }
}
