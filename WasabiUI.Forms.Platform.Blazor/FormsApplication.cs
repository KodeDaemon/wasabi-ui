using System;
using System.ComponentModel;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.RenderTree;
using WasabiUI.Forms.Components;
using WasabiUI.Forms.Core;
using Xamarin.Forms;
using IComponent = Microsoft.AspNetCore.Components.IComponent;

namespace WasabiUI.Forms.Platform.Blazor
{
    public class FormsApplication : IComponent
    {
        private readonly RenderFragment _renderFragment;
        private RenderHandle _renderHandle;

        Application _application;
        internal Platform Platform { get; private set; }

        public static FormsApplication Current { get; set; }

        public FormsApplication()
        {
            Current = this;

            _renderFragment = builder =>
            {
                //_hasPendingQueuedRender = false;
                //_hasNeverRendered = false;
                BuildRenderTree(builder);
            };
        }

        protected virtual void OnInit()
        {
        }

        public void Redraw()
        {
            _renderHandle.Render(_renderFragment);
        }

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

        protected void BuildRenderTree(RenderTreeBuilder builder)
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
            //var renderHandleFieldInfo = typeof(ComponentBase).GetField("_renderHandle", bindingFlags);

            //if (renderHandleFieldInfo != null)
            //{
                //var renderHandle = (RenderHandle)renderHandleFieldInfo?.GetValue(this);

                var componentIdFieldInfo = typeof(RenderHandle).GetField("_componentId", bindingFlags);
                if (componentIdFieldInfo != null)
                {
                    var componentId = (int)componentIdFieldInfo.GetValue(_renderHandle);

                    var rendererFieldInfo = typeof(RenderHandle).GetField("_renderer", bindingFlags);
                    var blazorRenderer = (Renderer)rendererFieldInfo?.GetValue(_renderHandle);

                    if (blazorRenderer != null)
                    {
                        var formsRenderer = Platform.GetRenderer(_application.MainPage);

                        var attachAndInitComponentMethodInfo = typeof(Renderer).GetMethod("AttachAndInitComponent", bindingFlags);
                        //attachAndInitComponentMethodInfo.Invoke(blazorRenderer, new object[] { formsRenderer.NativeView, componentId });

                        //formsRenderer.NativeView.Build(builder);
                    }
                //}

                _renderHandle.Render(builder =>
                {
                    var formsRenderer = Platform.GetRenderer(_application.MainPage);

                    formsRenderer.ComponentContainer.Configure(_renderHandle);

                    formsRenderer.ComponentContainer.Render();

                    //formsRenderer.NativeView.Build(builder);
                    //((IVisualNativeElementRenderer)formsRenderer).Render(builder);

                    //builder.OpenComponent<WasabiButton>(0);
                    //builder.AddAttribute(1, "Text", "Click Me!");
                    //builder.AddAttribute(3, "onclick", EventCallback.Factory.Create(this, OnClick));
                    //builder.CloseComponent();
                });
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

        private void OnClick(UIMouseEventArgs e)
        {

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

            Platform.SetPage(_application.MainPage, _renderHandle);
            //_layout.AddView(Platform.GetViewGroup());
        }

        public void Configure(RenderHandle renderHandle)
        {
            _renderHandle = renderHandle;
        }

        public Task SetParametersAsync(ParameterCollection parameters)
        {
            parameters.SetParameterProperties(this);

            OnInit();
            Render();

            return Task.CompletedTask;
        }

        private void Render()
        {
            //_renderHandle.Render(_renderFragment);
            Redraw();
        }
    }
}
