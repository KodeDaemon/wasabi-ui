using Microsoft.AspNetCore.Components.RenderTree;

namespace WasabiUI.Forms.Platform.Blazor
{
    public class LabelComponent : BuildableComponent
    {
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            //base.BuildRenderTree(builder);

            builder.AddContent(6, "<lABEL>");
        }
    }
}
