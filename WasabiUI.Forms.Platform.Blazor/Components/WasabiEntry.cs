using MatBlazor;
using Microsoft.AspNetCore.Components.RenderTree;
using WasabiUI.Forms.Core;

namespace WasabiUI.Forms.Platform.Blazor.Components
{
    public class WasabiEntry : BuildableComponent
    {
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenComponent<MatTextField>(0);
            //builder.AddAttribute(1, "ChildContent", (RenderFragment)((builder2 =>
            //{
            //    builder2.AddContent(2, "Sometext");
            //})));
            builder.CloseComponent();
        }
    }
}
