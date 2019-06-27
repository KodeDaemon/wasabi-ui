using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace WasabiUI.Forms.Platform.Blazor
{
    public class ResourcesProvider : ISystemResourcesProvider
    {
        ResourceDictionary _dictionary;

        public IResourceDictionary GetSystemResources()
        {
            _dictionary = new ResourceDictionary();

            return _dictionary;
        }
    }
}
