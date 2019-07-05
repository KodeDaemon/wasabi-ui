using MvvmCross;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Forms.Bindings;
using WasabiUI.MvvmCross.Binding;

namespace WasabiUI.MvvmCross.Forms.Bindings
{
    public class MvxFormsWasabiUIBindingBuilder : MvxWasabiUIBindingBuilder
    {
        public MvxFormsWasabiUIBindingBuilder()
        {
        }

        public override void DoRegistration()
        {
            base.DoRegistration();
            InitializeBindingCreator();
        }

        protected override IMvxTargetBindingFactoryRegistry CreateTargetBindingRegistry()
        {
            return new MvxFormsTargetBindingFactoryRegistry();
        }

        private void InitializeBindingCreator()
        {
            var creator = CreateBindingCreator();
            Mvx.IoCProvider.RegisterSingleton(creator);
        }

        protected virtual IMvxBindingCreator CreateBindingCreator()
        {
            return new MvxFormsBindingCreator();
        }
    }
}
