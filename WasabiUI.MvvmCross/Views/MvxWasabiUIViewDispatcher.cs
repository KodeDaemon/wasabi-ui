using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.ViewModels;
using MvvmCross.Views;
using WasabiUI.MvvmCross.Presenters;

namespace WasabiUI.MvvmCross.Views
{
    public class MvxWasabiUIViewDispatcher
        : MvxWasabiUIMainThreadDispatcher, IMvxViewDispatcher
    {
        private readonly IMvxWasabiUIViewPresenter _presenter;

        public MvxWasabiUIViewDispatcher(IMvxWasabiUIViewPresenter presenter)
        {
            _presenter = presenter;
        }

        public async Task<bool> ShowViewModel(MvxViewModelRequest request)
        {
            Func<Task> action = () =>
            {
                //MvxLog.Instance.Trace("WasabiUINavigation", "Navigate requested");
                return _presenter.Show(request);
            };
            await ExecuteOnMainThreadAsync(action);
            return true;
        }

        public async Task<bool> ChangePresentation(MvxPresentationHint hint)
        {
            await ExecuteOnMainThreadAsync(() => _presenter.ChangePresentation(hint));
            return true;
        }
    }
}
