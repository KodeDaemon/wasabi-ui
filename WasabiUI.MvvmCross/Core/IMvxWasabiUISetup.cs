using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Core;
using WasabiUI.Forms.Platform.Blazor;

namespace WasabiUI.MvvmCross.Core
{
    public interface IMvxWasabiUISetup : IMvxSetup
    {
        void PlatformInitialize(FormsApplication coreApplication);
    }
}
