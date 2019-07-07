using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Components;
using WasabiUI.Forms.Core;

namespace WasabiUI.Forms.Components
{
    public class WasabiButtonBase : WasabiComponentBase
    {
        [Parameter]
        public string Text { get; set; }

        [Parameter]
        protected EventCallback<UIMouseEventArgs> OnClick { get; set; }

        public Action<WasabiButton> OnClickAction;
    }
}
