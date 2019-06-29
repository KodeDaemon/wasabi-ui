using Microsoft.AspNetCore.Components.RenderTree;
using WasabiUI.Forms.Core;

namespace WasabiUI.Forms.Platform.Blazor
{
    public class EntryComponent : BuildableComponent
    {
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "input");
            builder.AddAttribute(1, "type", "text");
            builder.CloseElement();
        }
    }
}
