using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;

namespace WasabiUI.Forms.Platform.Blazor
{
    public class BuildableComponent : ComponentBase
    {
        public IVisualElementRenderer Renderer { get; set; }

        public void Build(RenderTreeBuilder builder)
        {
            BuildRenderTree(builder);
        }
    }
}
