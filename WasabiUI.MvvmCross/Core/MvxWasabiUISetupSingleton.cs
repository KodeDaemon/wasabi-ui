using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Core;
using WasabiUI.Forms.Platform.Blazor;

namespace WasabiUI.MvvmCross.Core
{
    public class MvxWasabiUISetupSingleton
        : MvxSetupSingleton
    {
        public static MvxWasabiUISetupSingleton EnsureSingletonAvailable(FormsApplication coreApplication)
        {
            var instance = EnsureSingletonAvailable<MvxWasabiUISetupSingleton>();
            instance.PlatformSetup<MvxWasabiUISetup>()?.PlatformInitialize(coreApplication);
            return instance;
        }
    }
}
