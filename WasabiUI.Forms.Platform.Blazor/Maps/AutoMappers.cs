using AutoMapper;
using WasabiUI.Forms.Components;
using Xamarin.Forms;

namespace WasabiUI.Forms.Platform.Blazor.Maps
{
    public class StackLayoutProfile : Profile
    {
        public StackLayoutProfile()
        {
            CreateMap<StackLayout, WasabiStackLayout>();
        }
    }
}