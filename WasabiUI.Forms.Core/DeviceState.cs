using System;
using Microsoft.JSInterop;

namespace WasabiUI.Forms.Core
{
    public class DeviceState
    {
        public Orientation DeviceOrientation { get; set; }

        private static DeviceState _current = null;

        public DeviceState(IJSRuntime js)
        {
            var j = ExposedObject.ExposedObject.From(js);
            Microsoft.AspNetCore.SignalR.IClientProxy client = null;
            var connected = false;

            try
            {
                var proxy = j._clientProxy;
                connected = proxy.Connected;
                client = proxy.Client as Microsoft.AspNetCore.SignalR.IClientProxy;
            }
            catch
            {
                Console.WriteLine("IJSRuntime is not connected.");
            }
            
            if (!connected || client == null)
                return;

            js.InvokeAsync<string>("getOrientation").ContinueWith(t =>
            {
                OrientationChanged(t.Result);
            });

            if (_current != null)
                throw new NotSupportedException("This class must be singleton");

            _current = this;
        }

        public event EventHandler<Orientation> OnOrientationChanged;

        [JSInvokable]
        public static void OrientationChanged(string orientation)
        {
            if (_current == null) return;
            _current.DeviceOrientation = orientation.ToLower().Contains("landscape") ? Orientation.Landscape : Orientation.Portrait;
            Console.WriteLine("OrientationChanged: " + orientation);
            _current.OnOrientationChanged?.Invoke(_current, _current.DeviceOrientation);
        }
    }

    public enum Orientation
    {
        Landscape,
        Portrait
    }

}
