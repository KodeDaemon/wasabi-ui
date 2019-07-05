using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
using WasabiUI.Forms.Core;

namespace WasabiUI.Forms.Platform.Blazor
{
    public class WasabiComponentHandle<T> : WasabiComponentHandle, IWasabiComponentHandle<T> where T : IComponent
    {
        public WasabiComponentHandle() : base(typeof(T))
        {
        }
    }

    public class WasabiComponentHandle : IWasabiComponentHandle
    {
        public Type Type { get; set; }
        public IVisualElementRenderer Renderer { get; set; }

        public WasabiComponentHandle(Type type)
        {
            Type = type;
        }
    }

    public class ComponentContainer : IComponentContainer
    {
        public RenderHandle _renderHandle;
        //public RenderHandle RenderHandle => _renderHandle;

        private readonly List<IWasabiComponentHandle> _components = new List<IWasabiComponentHandle>();

        public List<IWasabiComponentHandle> Children => _components;

        public void RemoveChild(IWasabiComponentHandle child)
        {
            _components.Remove(child);
        }

        public void AppendChild(IWasabiComponentHandle child)
        {
            if (child != null)
                _components.Add(child);
        }

        public void Configure(RenderHandle renderHandle)
        {
            _renderHandle = renderHandle;
        }

        //public Task SetParametersAsync(ParameterCollection parameters)
        //{
        //    parameters.SetParameterProperties(this);
        //    Render();
        //    return Task.CompletedTask;
        //}

        public void Render()
        {
            var renderFragment = (RenderFragment)RenderContainer;

            _renderHandle.Render(renderFragment);
        }

        private void RenderContainer(RenderTreeBuilder builder)
        {
            RenderComponents(_components, builder);
        }

        private void RenderComponents(IEnumerable<IWasabiComponentHandle> components, RenderTreeBuilder builder)
        {
            foreach (var component in components)
            {

                component.Renderer.Render(builder);

                //if (component.Renderer is IVisualElementRenderer c)
                //{
                //    c.Render(builder);
                //}

                /*
                var container = (ComponentContainer)component.Renderer.ComponentContainer;

                if (component.Type == null)
                {
                    if (container._components.Count > 0)
                    {
                        RenderComponents(container._components, builder);
                    }
                }
                else
                {
                    //builder.OpenComponent(0, component.Type);
                    ((IVisualNativeElementRenderer) component.Renderer).Render(builder);
                    //builder.CloseComponent();
                }
                */
                //((IVisualNativeElementRenderer)component.Renderer).Render(builder);
            }
        }
    }
}
