using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.RenderTree;

namespace WasabiUI.Forms.Core
{
    public interface IBuildableComponent
    {
        void Build(RenderTreeBuilder builder);

    }
}
