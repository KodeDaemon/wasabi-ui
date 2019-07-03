using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Base;

namespace WasabiUI.MvvmCross.Views
{
    public class MvxWasabiUIMainThreadDispatcher : MvxMainThreadAsyncDispatcher
    {
        public override bool IsOnMainThread => true;

        public override bool RequestMainThreadAction(Action action, bool maskExceptions = true)
        {
            //TODO: implement
            ExceptionMaskedAction(action, maskExceptions);
            return true;
        }
    }
}
