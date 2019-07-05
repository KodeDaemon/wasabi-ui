using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Forms.Presenters;
using MvvmCross.ViewModels;
using WasabiUI.MvvmCross.Presenters;
using Xamarin.Forms;

namespace WasabiUI.MvvmCross.Forms.Presenters
{
    public class MvxFormsWasabiUIViewPresenter
            : MvxWasabiUIViewPresenter
            , IMvxFormsViewPresenter
    {
        public MvxFormsWasabiUIViewPresenter(Application formsApplication) : base()
        {
            FormsApplication = formsApplication ?? throw new ArgumentNullException(nameof(formsApplication), "MvxFormsApplication cannot be null");
        }

        public Application FormsApplication { get; set; }

        private IMvxFormsPagePresenter _formsPagePresenter;
        public virtual IMvxFormsPagePresenter FormsPagePresenter
        {
            get
            {
                if (_formsPagePresenter == null)
                    throw new ArgumentNullException(nameof(FormsPagePresenter), "IMvxFormsPagePresenter cannot be null. Set the value in CreateViewPresenter in the setup.");
                return _formsPagePresenter;
            }
            set { _formsPagePresenter = value; }
        }

        public override Task<bool> Show(MvxViewModelRequest request)
        {
            return FormsPagePresenter.Show(request);
        }

        public override void RegisterAttributeTypes()
        {
            base.RegisterAttributeTypes();
            FormsPagePresenter.RegisterAttributeTypes();
        }

        public override async Task<bool> ChangePresentation(MvxPresentationHint hint)
        {
            if (!await FormsPagePresenter.ChangePresentation(hint)) return false;
            return await base.ChangePresentation(hint);
        }

        public override Task<bool> Close(IMvxViewModel viewModel)
        {
            return FormsPagePresenter.Close(viewModel);
        }

        public virtual bool ShowPlatformHost(Type hostViewModel = null)
        {
            //MvxFormsLog.Instance.Trace($"Showing of native host View in Forms is not supported.");
            return false;
        }

        public virtual bool ClosePlatformViews()
        {
            return true;
        }
    }
}
