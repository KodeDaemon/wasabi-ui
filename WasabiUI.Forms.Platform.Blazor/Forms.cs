using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace WasabiUI.Forms.Platform.Blazor
{
    public static class Forms
    {
        public static bool IsInitialized { get; private set; }

        public static void Init()
        {
            if (IsInitialized)
                return;
            //IsInitialized = true;

            if(!IsInitialized)
            {
               // Internals.Log.Listeners.Add(new XamarinLogListener());
            }

            Device.SetIdiom(TargetIdiom.Desktop);
            Device.SetFlowDirection(FlowDirection.LeftToRight);
            Device.Info = new BlazorDeviceInfo();

            Device.PlatformServices = new BlazorPlatformServices();
            ExpressionSearch.Default = new BlazorExpressionSearch();

            if (!IsInitialized)
            {
                Registrar.RegisterAll(new[]
                {
                    typeof(ExportRendererAttribute),
                    typeof(ExportCellAttribute),
                    typeof(ExportImageSourceHandlerAttribute)
                });
            }

            IsInitialized = true;
        }
    }
}
