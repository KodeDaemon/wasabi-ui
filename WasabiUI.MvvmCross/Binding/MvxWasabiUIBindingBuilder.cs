using System;
using MvvmCross;
using MvvmCross.Base;
using MvvmCross.Converters;
using MvvmCross.Binding;
using MvvmCross.Binding.Binders;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Bindings.Target.Construction;

namespace WasabiUI.MvvmCross.Binding
{
    public class MvxWasabiUIBindingBuilder
            : MvxBindingBuilder
    {
        private readonly Action<IMvxTargetBindingFactoryRegistry> _fillRegistryAction;
        private readonly Action<IMvxValueConverterRegistry> _fillValueConvertersAction;
        private readonly Action<IMvxAutoValueConverters> _fillAutoValueConvertersAction;
        private readonly Action<IMvxBindingNameRegistry> _fillBindingNamesAction;

        public MvxWasabiUIBindingBuilder(Action<IMvxTargetBindingFactoryRegistry> fillRegistryAction = null,
                                    Action<IMvxValueConverterRegistry> fillValueConvertersAction = null,
                                    Action<IMvxAutoValueConverters> fillAutoValueConvertersAction = null,
                                    Action<IMvxBindingNameRegistry> fillBindingNamesAction = null)
        {
            _fillRegistryAction = fillRegistryAction;
            _fillValueConvertersAction = fillValueConvertersAction;
            _fillAutoValueConvertersAction = fillAutoValueConvertersAction;
            _fillBindingNamesAction = fillBindingNamesAction;
        }

        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            base.FillTargetFactories(registry);

            //TODO: Add targets

            _fillRegistryAction?.Invoke(registry);
        }

        protected override void FillValueConverters(IMvxValueConverterRegistry registry)
        {
            base.FillValueConverters(registry);

            _fillValueConvertersAction?.Invoke(registry);
        }

        protected override void FillAutoValueConverters(IMvxAutoValueConverters autoValueConverters)
        {
            base.FillAutoValueConverters(autoValueConverters);

            _fillAutoValueConvertersAction?.Invoke(autoValueConverters);
        }

        protected override void FillDefaultBindingNames(IMvxBindingNameRegistry registry)
        {
            base.FillDefaultBindingNames(registry);

            //TODO: Add default names

            _fillBindingNamesAction?.Invoke(registry);
        }
    }
}
