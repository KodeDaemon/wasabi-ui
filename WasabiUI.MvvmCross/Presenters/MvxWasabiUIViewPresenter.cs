using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Presenters;
using MvvmCross.Presenters.Attributes;

namespace WasabiUI.MvvmCross.Presenters
{
    public class MvxWasabiUIViewPresenter : MvxAttributeViewPresenter, IMvxWasabiUIViewPresenter
    {
        public override MvxBasePresentationAttribute CreatePresentationAttribute(Type viewModelType, Type viewType)
        {
            return null;
        }

        public override void RegisterAttributeTypes()
        {
        }
    }
}
