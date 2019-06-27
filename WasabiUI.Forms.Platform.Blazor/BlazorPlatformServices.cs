using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace WasabiUI.Forms.Platform.Blazor
{
    public class BlazorPlatformServices : IPlatformServices
    {
        public bool IsInvokeRequired => false;

        public string RuntimePlatform => "Blazor";

        public void BeginInvokeOnMainThread(Action action)
        {
            Task.Run(action);
        }

        public Ticker CreateTicker()
        {
            return new BlazorTicker();
        }

        class BlazorTicker: Ticker
        {
            Timer timer;
            protected override void DisableTimer()
            {
                var t = timer;
                timer = null;
                t?.Dispose();
            }
            protected override void EnableTimer()
            {
                if (timer != null)
                    return;
                var interval = TimeSpan.FromSeconds(1.0 / 30);
                timer = new Timer((_ => {
                    this.SendSignals();
                }), null, (int)interval.TotalMilliseconds, (int)interval.TotalMilliseconds);
            }
        }

        public Assembly[] GetAssemblies()
        {
            return AppDomain.CurrentDomain.GetAssemblies();
        }

        public string GetMD5Hash(string input)
        {
            throw new NotImplementedException();
        }

        public double GetNamedSize(NamedSize size, Type targetElementType, bool useOldSizes)
        {
            switch (size)
            {
                default:
                case NamedSize.Default:
                    return 16;
                case NamedSize.Micro:
                    return 9;
                case NamedSize.Small:
                    return 12;
                case NamedSize.Medium:
                    return 22;
                case NamedSize.Large:
                    return 32;
            }
        }

        public SizeRequest GetNativeSize(VisualElement view, double widthConstraint, double heightConstraint)
        {
            var renderer = Platform.GetRenderer(view);
            return renderer.GetDesiredSize(widthConstraint, heightConstraint);
        }

        public Task<Stream> GetStreamAsync(Uri uri, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public IIsolatedStorageFile GetUserStoreForApplication()
        {
            throw new NotImplementedException();
        }

        public void OpenUriAction(Uri uri)
        {
            throw new NotImplementedException();
        }

        public void QuitApplication()
        {
        }

        public void StartTimer(TimeSpan interval, Func<bool> callback)
        {
            Timer timer = null;
            timer = new Timer((_ => {
                if (!callback())
                {
                    timer?.Dispose();
                    timer = null;
                }
            }), null, (int)interval.TotalMilliseconds, (int)interval.TotalMilliseconds);
        }
    }
}
