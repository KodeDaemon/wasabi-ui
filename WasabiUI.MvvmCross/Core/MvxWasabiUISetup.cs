using System;
using System.Collections.Generic;
using System.Reflection;
using MvvmCross.Binding;
using MvvmCross.Binding.Binders;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Converters;
using MvvmCross.Core;
using MvvmCross.IoC;
using WasabiUI.MvvmCross.Binding;
using WasabiUI.MvvmCross.Presenters;
using WasabiUI.MvvmCross.Views;
using MvvmCross.Presenters;
using MvvmCross.ViewModels;
using MvvmCross.Views;
using MvvmCross;
using WasabiUI.Forms.Platform.Blazor;

namespace WasabiUI.MvvmCross.Core
{
    public abstract class MvxWasabiUISetup : MvxSetup, IMvxWasabiUISetup
    {
        protected FormsApplication CoreApplication { get; private set; }

        public virtual void PlatformInitialize(FormsApplication coreApplication)
        {
            CoreApplication = coreApplication;
        }

        private IMvxWasabiUIViewPresenter _presenter;
        protected IMvxWasabiUIViewPresenter Presenter
        {
            get
            {
                _presenter = _presenter ?? CreateViewPresenter();
                return _presenter;
            }
        }

        protected override void InitializePlatformServices()
        {
            RegisterPresenter();
            base.InitializePlatformServices();
        }

        protected sealed override IMvxViewsContainer CreateViewsContainer()
        {
            var container = CreateWasabiUIViewsContainer();
            Mvx.IoCProvider.RegisterSingleton(container);
            return container;
        }

        protected virtual IMvxWasabiUIViewsContainer CreateWasabiUIViewsContainer()
        {
            return new MvxWasabiUIViewsContainer();
        }

        protected virtual IMvxWasabiUIViewPresenter CreateViewPresenter()
        {
            return new MvxWasabiUIViewPresenter();
        }

        protected virtual void RegisterPresenter()
        {
            var presenter = Presenter;
            Mvx.IoCProvider.RegisterSingleton(presenter);
            Mvx.IoCProvider.RegisterSingleton<IMvxViewPresenter>(presenter);
        }

        protected override void InitializeLastChance()
        {
            InitializeBindingBuilder();
            base.InitializeLastChance();
        }

        protected virtual void InitializeBindingBuilder()
        {
            RegisterBindingBuilderCallbacks();
            var bindingBuilder = CreateBindingBuilder();
            bindingBuilder.DoRegistration();
        }

        protected virtual void RegisterBindingBuilderCallbacks()
        {
            Mvx.IoCProvider.CallbackWhenRegistered<IMvxValueConverterRegistry>(FillValueConverters);
            Mvx.IoCProvider.CallbackWhenRegistered<IMvxTargetBindingFactoryRegistry>(FillTargetFactories);
            Mvx.IoCProvider.CallbackWhenRegistered<IMvxBindingNameRegistry>(FillBindingNames);
        }

        protected virtual MvxBindingBuilder CreateBindingBuilder()
        {
            return new MvxWasabiUIBindingBuilder();
        }

        protected override IMvxViewDispatcher CreateViewDispatcher()
        {
            return new MvxWasabiUIViewDispatcher(Presenter);
        }

        protected override IMvxNameMapping CreateViewToViewModelNaming()
        {
            return new MvxPostfixAwareViewToViewModelNameMapping("View");
        }

        protected virtual void FillBindingNames(IMvxBindingNameRegistry registry)
        {
            // this base class does nothing
        }

        protected virtual void FillValueConverters(IMvxValueConverterRegistry registry)
        {
            registry.Fill(ValueConverterAssemblies);
            registry.Fill(ValueConverterHolders);
        }

        protected virtual List<Type> ValueConverterHolders => new List<Type>();

        protected virtual IEnumerable<Assembly> ValueConverterAssemblies
        {
            get
            {
                var toReturn = new List<Assembly>();
                toReturn.AddRange(GetViewModelAssemblies());
                toReturn.AddRange(GetViewAssemblies());
                return toReturn;
            }
        }

        protected virtual void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            // this base class does nothing
        }
    }

    public class MvxWasabiUISetup<TApplication> : MvxWasabiUISetup
        where TApplication : class, IMvxApplication, new()
    {
        protected override IMvxApplication CreateApp() => Mvx.IoCProvider.IoCConstruct<TApplication>();

        public override IEnumerable<Assembly> GetViewModelAssemblies()
        {
            return new[] { typeof(TApplication).GetTypeInfo().Assembly };
        }
    }
}
