using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Components;

namespace WasabiUI.Forms.Components
{
    public class WasabiTextFieldBase : WasabiComponentBase
    {
        [Parameter]
        public string Text { get; set; }
    }
}
