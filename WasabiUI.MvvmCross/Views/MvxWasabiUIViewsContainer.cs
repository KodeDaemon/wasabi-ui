using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.ViewModels;
using MvvmCross.Views;

namespace WasabiUI.MvvmCross.Views
{
    public class MvxWasabiUIViewsContainer
        : MvxViewsContainer
            , IMvxWasabiUIViewsContainer
    {
        public MvxViewModelRequest CurrentRequest { get; private set; }
    }
}
