using System;

namespace AutoUpdaterDotNET
{
    public sealed class AutoUpdaterErrorEventArgs : EventArgs
    {
        public AutoUpdaterErrorEventArgs(Exception exception)
        {
            Exception = exception;
        }

        public Exception Exception { get; }
    }
}
