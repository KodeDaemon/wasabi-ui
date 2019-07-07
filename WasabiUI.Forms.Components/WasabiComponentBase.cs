using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Components;

namespace WasabiUI.Forms.Components
{
    public class WasabiComponentBase : ComponentBase
    {
        protected ClassMapper ClassMapper { get; } = new ClassMapper();

        protected StyleMapper StyleMapper { get; } = new StyleMapper();
    }
}
