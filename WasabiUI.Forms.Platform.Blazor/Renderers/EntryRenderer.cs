using Microsoft.AspNetCore.Components.RenderTree;
using WasabiUI.Forms.Platform.Blazor.Components;
using Xamarin.Forms;

namespace WasabiUI.Forms.Platform.Blazor.Renderers
{
    public class EntryRenderer : ViewRenderer<Entry, WasabiEntry>
    {
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            (new WasabiEntry()).Build(builder);
        }
    }
}
