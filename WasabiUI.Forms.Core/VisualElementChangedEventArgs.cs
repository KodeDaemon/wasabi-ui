using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WasabiUI.Forms.Core
{
    public class VisualElementChangedEventArgs : ElementChangedEventArgs<VisualElement>
    {
        public VisualElementChangedEventArgs(VisualElement oldElement, VisualElement newElement)
            : base(oldElement, newElement)
        {
        }
    }
}
