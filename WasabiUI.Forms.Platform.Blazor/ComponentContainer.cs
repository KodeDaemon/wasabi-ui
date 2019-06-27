using System.Collections.Generic;
using Microsoft.AspNetCore.Components.RenderTree;

namespace WasabiUI.Forms.Platform.Blazor
{
    public class ComponentContainer : BuildableComponent
    {
        private readonly List<BuildableComponent> _components = new List<BuildableComponent>();

        public List<BuildableComponent> Children { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            //builder.AddContent(0, "Hello World");
            foreach (var component in _components)
            {
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
