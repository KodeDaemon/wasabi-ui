using System;
using System.Reflection;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.SignalR;
using WasabiUI.Forms.Core;

namespace WasabiUI.Forms.Platform.Blazor
{
    public class BuildableComponent : ComponentBase, IBuildableComponent 
    {
        public IVisualElementRenderer Renderer { get; set; }

        public static bool IsRendererInitialized {
            get;
            set;
        }
        private static Renderer _blazorRenderer;

        public void Build(RenderTreeBuilder builder)
        {
            Register();

            BuildRenderTree(builder);
        }

        private void Register()
        {
            var bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

            var renderHandleFieldInfo = typeof(ComponentBase).GetField("_renderHandle", bindingFlags);
            if (renderHandleFieldInfo == null)
                return;

            var renderHandle = (RenderHandle)renderHandleFieldInfo?.GetValue(this);

            if (IsRendererInitialized && !renderHandle.IsInitialized)
            {
                var componentIdFieldInfo = typeof(RenderHandle).GetField("_componentId", bindingFlags);
                if (componentIdFieldInfo == null)
                    return;

                var componentId = 0; //(int)componentIdFieldInfo.GetValue(renderHandle);

                //var rendererFieldInfo = typeof(RenderHandle).GetField("_renderer", bindingFlags);
                //var blazorRenderer = (Renderer)rendererFieldInfo?.GetValue(renderHandle);
                //if (blazorRenderer == null)
                //    return;

                var attachAndInitComponentMethodInfo = typeof(Renderer).GetMethod("AttachAndInitComponent", bindingFlags);
                attachAndInitComponentMethodInfo.Invoke(_blazorRenderer, new object[] { this, componentId });
            }
            else
            {
                var rendererFieldInfo = typeof(RenderHandle).GetField("_renderer", bindingFlags);
                _blazorRenderer = (Renderer)rendererFieldInfo?.GetValue(renderHandle);

                IsRendererInitialized = true;
            }
        }
    }

    
}
