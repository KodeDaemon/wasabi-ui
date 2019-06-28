using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components.RenderTree;

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

    public class ComponentContainer : BuildableComponent
    {
        
        private readonly List<BuildableComponent> _components = new List<BuildableComponent>();
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

        public void RemoveChild(BuildableComponent child)
        {
            _components.Remove(child);
        }

        public void AppendChild(BuildableComponent child)
        {
            _components.Add(child);
        }
    }
}
