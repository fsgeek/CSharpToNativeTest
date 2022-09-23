using System;
using System.Diagnostics;
using System.Management;
using System.Reactive;
using System.Reactive.Linq;

namespace DeviceChangeMonitor
{
    /// <summary>
    /// Detects USB device changes on your computer
    /// </summary>
    public interface IDeviceChangeListener
    {
        /// <summary>
        /// Raises an event as soon as a new USB device has been detected or the device configuration has been changed.
        /// </summary>
        IObservable<Unit> Stream { get; }
    }

    /// <summary>
    /// Detects USB device changes on your computer. 
    /// </summary>
    public class DeviceChangeListener : IDeviceChangeListener, IDisposable
    {
        private static readonly TimeSpan THROTTLE_TIME = TimeSpan.FromMilliseconds(100);

        // requires reference to System.Management.dll
        private readonly ManagementEventWatcher _watcher = new ManagementEventWatcher();

        private bool _isDisposed;

        public DeviceChangeListener()
        {
            // EventType is one of:
            //  1 = Configuration Change
            //  2 = Device Arrival
            //  3 = Device Removal
            //  4 = Docking
            //
            var query = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2 or EventType = 3");

            Stream = Observable
                .FromEventPattern<EventArrivedEventHandler, EventArrivedEventArgs>(
                    h => _watcher.EventArrived += h,
                    h => _watcher.EventArrived -= h)
                .TakeWhile(_ => !_isDisposed)
                .Select(_ => Unit.Default)
                .Throttle(THROTTLE_TIME)
                .Do(e => LogDeviceChange())
                .Publish()
                .RefCount();

            _watcher.Query = query;
            _watcher.Start();
        }

        private static void LogDeviceChange()
        {
            Debug.Print("A device added/removed/changed event has been received.");
        }

        public IObservable<Unit> Stream { get; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            if (_isDisposed)
            {
                return;
            }

            _watcher.Stop();
            _isDisposed = true;
        }
    }
}