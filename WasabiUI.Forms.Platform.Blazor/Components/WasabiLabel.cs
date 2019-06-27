using Microsoft.AspNetCore.Components.RenderTree;

namespace WasabiUI.Forms.Platform.Blazor.Components
{
    public class WasabiLabel : BuildableComponent
    {
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.AddContent(0, "label");
            //builder.OpenComponent<MatTextField>(0);
            //builder.AddAttribute(1, "ChildContent", (RenderFragment)((builder2 =>
            //{
            //    builder2.AddContent(2, "Sometext");
            //})));
            //builder.CloseComponent();
        }
    }
}
