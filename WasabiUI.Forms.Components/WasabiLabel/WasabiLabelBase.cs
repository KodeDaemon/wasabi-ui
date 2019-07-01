using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Components;
using WasabiUI.Forms.Core;

namespace WasabiUI.Forms.Components
{
    public class WasabiLabelBase : ComponentBase
    {
        [Parameter]
        public string Text { get; set; }
    }
}
