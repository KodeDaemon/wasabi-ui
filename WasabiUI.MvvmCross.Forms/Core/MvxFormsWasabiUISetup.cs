using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using MvvmCross;
using MvvmCross.Binding;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Forms.Core;
using MvvmCross.Forms.Presenters;
using MvvmCross.IoC;
using MvvmCross.Localization;
using MvvmCross.Plugin;
using MvvmCross.ViewModels;
using WasabiUI.MvvmCross.Core;
using WasabiUI.MvvmCross.Forms.Bindings;
using WasabiUI.MvvmCross.Forms.Presenters;
using WasabiUI.MvvmCross.Presenters;
using Xamarin.Forms;

namespace WasabiUI.MvvmCross.Forms.Core
{
    public abstract class MvxFormsWasabiUISetup : MvxWasabiUISetup, IMvxFormsSetup
    {
        private List<Assembly> _viewAssemblies;
        private Application _formsApplication;

        public override IEnumerable<Assembly> GetViewAssemblies()
        {
            if (_viewAssemblies == null)
            {
                _viewAssemblies = new List<Assembly>(base.GetViewAssemblies());
            }

            return _viewAssemblies;
        }

        //protected override IMvxIoCProvider InitializeIoC()
        //{
        //    var provider = base.InitializeIoC();
        //    provider.RegisterSingleton<IMvxFormsSetup>(this);
        //    return provider;
        //}

        protected override void InitializeApp(IMvxPluginManager pluginManager, IMvxApplication app)
        {
            base.InitializeApp(pluginManager, app);
            _viewAssemblies.AddRange(GetViewModelAssemblies());
        }

        public virtual Application FormsApplication
        {
            get
            {
                if (!WasabiUI.Forms.Platform.Blazor.Forms.IsInitialized)
                {
                    WasabiUI.Forms.Platform.Blazor.Forms.Init();
                }

                if (_formsApplication == null)
                {
                    _formsApplication = CreateFormsApplication();
                }
                if (Application.Current != _formsApplication)
                {
                    Application.Current = _formsApplication;
                }
                return _formsApplication;
            }
        }

        protected abstract Application CreateFormsApplication();

        protected virtual IMvxFormsPagePresenter CreateFormsPagePresenter(IMvxFormsViewPresenter viewPresenter)
        {
            var formsPagePresenter = new MvxFormsPagePresenter(viewPresenter);
            Mvx.IoCProvider.RegisterSingleton<IMvxFormsPagePresenter>(formsPagePresenter);
            return formsPagePresenter;
        }

        protected override IMvxWasabiUIViewPresenter CreateViewPresenter()
        {
            var presenter = new MvxFormsWasabiUIViewPresenter(FormsApplication);
            Mvx.IoCProvider.RegisterSingleton<IMvxFormsViewPresenter>(presenter);
            presenter.FormsPagePresenter = CreateFormsPagePresenter(presenter);
            return presenter;
        }

        protected override IEnumerable<Assembly> ValueConverterAssemblies
        {
            get
            {
                var toReturn = new List<Assembly>(base.ValueConverterAssemblies)
                {
                    typeof(MvxLanguageConverter).Assembly
                };
                return toReturn;
            }
        }

        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            MvxFormsSetupHelper.FillTargetFactories(registry);
            base.FillTargetFactories(registry);
        }

        protected override void FillBindingNames(IMvxBindingNameRegistry registry)
        {
            MvxFormsSetupHelper.FillBindingNames(registry);
            base.FillBindingNames(registry);
        }

        protected override MvxBindingBuilder CreateBindingBuilder() => new MvxFormsWasabiUIBindingBuilder();

        protected override IMvxNameMapping CreateViewToViewModelNaming()
        {
            return new MvxPostfixAwareViewToViewModelNameMapping("View", "Page");
        }
    }

    public class MvxFormsWasabiUISetup<TApplication, TFormsApplication> : MvxFormsWasabiUISetup
        where TApplication : class, IMvxApplication, new()
        where TFormsApplication : Application, new()
    {
        public override IEnumerable<Assembly> GetViewAssemblies()
        {
            return new List<Assembly>(base.GetViewAssemblies().Union(new[] { typeof(TFormsApplication).GetTypeInfo().Assembly }));
        }

        public override IEnumerable<Assembly> GetViewModelAssemblies()
        {
            return new[] { typeof(TApplication).GetTypeInfo().Assembly };
        }

        protected override Application CreateFormsApplication() => new TFormsApplication();

        protected override IMvxApplication CreateApp() => Mvx.IoCProvider.IoCConstruct<TApplication>();
    }
}
