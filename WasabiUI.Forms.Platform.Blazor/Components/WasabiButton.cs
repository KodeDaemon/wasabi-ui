using System;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;

namespace WasabiUI.Forms.Platform.Blazor.Components
{
    public class WasabiButton : BuildableComponent
    {
        [Parameter]
        public string Text { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenComponent<MatButton>(0);
            builder.AddAttribute(1, "ChildContent", (RenderFragment)((builder2 =>
            {
                builder2.AddContent(2, Text);
            })));
            builder.AddAttribute(3, "onclick", EventCallback.Factory.Create(this, OnClick));
            builder.CloseComponent();
        }

        public Action<WasabiButton> OnClickAction;

        [Parameter]
        protected EventCallback<UIMouseEventArgs> OnClick { get; set; }

        //private void OnClick(UIMouseEventArgs e)
        //{
        //    OnClickAction?.Invoke(this);
        //}
    }
}
