using System;
using System.ComponentModel;
using System.Reflection;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.RenderTree;
using WasabiUI.Forms.Core;
using Xamarin.Forms;

namespace WasabiUI.Forms.Platform.Blazor
{
    public class FormsApplication : BuildableComponent
    {
        Application _application;
        internal Platform Platform { get; private set; }

        protected void LoadApplication(Application application)
        {
            if (_application != null)
                _application.PropertyChanged -= ApplicationOnPropertyChanged;

            _application = application ?? throw new ArgumentNullException(nameof(application));
            //((IApplicationController)application).SetAppIndexingProvider(new AndroidAppIndexProvider(this));
            Xamarin.Forms.Application.SetCurrentApplication(application);

            //SetSoftInputMode();

            application.PropertyChanged += ApplicationOnPropertyChanged;

            SetMainPage();
        }

        void ApplicationOnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "MainPage")
            {
            //    UpdateMainPage();
            }
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            //var component = ExposedObject.ExposedObject.From(this);

            //var renderHandle = component._renderHandle;

            //if (!renderHandle.IsInitialized)
            //    return;

            //var componentId = (int)component._componentId;
            //var blazorRenderer = renderHandle._renderer;
            //var formsRenderer = Platform.GetRenderer(_application.MainPage);

            //blazorRenderer.AttachAndInitComponent(formsRenderer.NativeView, componentId);

            //var componentBase = GetType().BaseType.BaseType;

            var bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            var renderHandleFieldInfo = typeof(ComponentBase).GetField("_renderHandle", bindingFlags);

            if (renderHandleFieldInfo != null)
            {
                var renderHandle = (RenderHandle)renderHandleFieldInfo?.GetValue(this);

                var componentIdFieldInfo = typeof(RenderHandle).GetField("_componentId", bindingFlags);
                if (componentIdFieldInfo != null)
                {
                    var componentId = (int)componentIdFieldInfo.GetValue(renderHandle);

                    var rendererFieldInfo = typeof(RenderHandle).GetField("_renderer", bindingFlags);
                    var blazorRenderer = (Renderer)rendererFieldInfo?.GetValue(renderHandle);

                    if (blazorRenderer != null)
                    {
                        var formsRenderer = Platform.GetRenderer(_application.MainPage);

                        var attachAndInitComponentMethodInfo = typeof(Renderer).GetMethod("AttachAndInitComponent", bindingFlags);
                        attachAndInitComponentMethodInfo.Invoke(blazorRenderer, new object[] { formsRenderer.NativeView, componentId });

                        formsRenderer.NativeView.Build(builder);
                    }
                }
            }


            //var bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            //field = this.GetType().GetField("_renderer", bindingFlags);
            //var blazorRenderer = (Renderer)field?.GetValue(renderHandle);

            //MethodInfo attachAndInitComponentMethodInfo = typeof(Renderer).GetMethod("AttachAndInitComponent");
            //attachAndInitComponentMethodInfo.Invoke(blazorRenderer, new object[] { renderer.NativeView, componentId });

            //return (T)field?.GetValue(obj);


            //var formsRenderer = Platform.GetRenderer(_application.MainPage);
            //formsRenderer.NativeView.Build(builder);
        }

        void SetMainPage()
        {
            if (!Forms.IsInitialized)
                throw new InvalidOperationException("Call Forms.Init (Activity, Bundle) before this");

            if (Platform != null)
            {
                Platform.SetPage(_application.MainPage);
                return;
            }

            //PopupManager.ResetBusyCount(this);

            Platform = new Platform();

//            if (_application != null)
//            {
//#pragma warning disable CS0618 // Type or member is obsolete
//                // The Platform property is no longer necessary, but we have to set it because some third-party
//                // library might still be retrieving it and using it
//                _application.Platform = Platform;
//#pragma warning restore CS0618 // Type or member is obsolete
//            }

            Platform.SetPage(_application.MainPage);
            //_layout.AddView(Platform.GetViewGroup());
        }
    }
}
