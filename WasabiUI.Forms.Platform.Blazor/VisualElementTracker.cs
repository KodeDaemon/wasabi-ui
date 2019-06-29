using System;
using WasabiUI.Forms.Core;

namespace WasabiUI.Forms.Platform.Blazor
{
    public class VisualElementTracker
    {
        bool _disposed;

        public event EventHandler NativeControlUpdated;

        public VisualElementTracker(IVisualElementRenderer renderer)
        {
        }

        void OnUpdateNativeControl()
        {
        }

        void UpdateNativeControl()
        {
            if (_disposed)
                return;

            OnUpdateNativeControl();

            NativeControlUpdated?.Invoke(this, EventArgs.Empty);
        }
    }
}
