using System;
using Microsoft.AspNetCore.Components.RenderTree;
using WasabiUI.Forms.Components;
using WasabiUI.Forms.Core;
using Xamarin.Forms;

namespace WasabiUI.Forms.Platform.Blazor.Renderers
{
    public class DefaultRenderer : VisualElementRenderer<View>
    {
        //protected override IWasabiComponentHandle<WasabiLabel> CreateComponentHandle()
        //{
        //    return new WasabiComponentHandle<WasabiLabel>();
        //}

        //protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        //{
        //    base.OnElementChanged(e);

        //    if (e.NewElement != null)
        //    {
        //        if (Control == null)
        //        {
        //            SetNativeControl(CreateComponentHandle());
        //        }
        //    }
        //}
    }
}
