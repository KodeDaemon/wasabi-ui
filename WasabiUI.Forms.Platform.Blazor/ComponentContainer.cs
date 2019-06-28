using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
using WasabiUI.Forms.Core;

namespace WasabiUI.Forms.Platform.Blazor
{
    public class CreatableComponent<T> : CreateableComponent where T : BuildableComponent
    {
        public CreatableComponent() : base(typeof(T))
        {
            
        }
    }

    public class CreateableComponent
    {
        public Type Type { get; set; }

        public CreateableComponent(Type type)
        {
            Type = type;
        }
    }



    public class ComponentContainer : BuildableComponent, IComponentContainer
    {
        
        private readonly List<IBuildableComponent> _components = new List<IBuildableComponent>();
        //private readonly List<CreateableComponent> _components = new List<CreateableComponent>();

        public List<BuildableComponent> Children { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            //builder.AddContent(0, "Hello World");
            foreach (var component in _components)
            {
                //builder.OpenComponent(0, component.Type);
                //builder.CloseComponent();
                component.Build(builder);
                //builder.AddContent(1, component);
            }
        }

        public void RemoveChild(IBuildableComponent child)
        {
            _components.Remove(child);
        }

        public void AppendChild(IBuildableComponent child)
        {
            _components.Add(child);
        }
    }
}
