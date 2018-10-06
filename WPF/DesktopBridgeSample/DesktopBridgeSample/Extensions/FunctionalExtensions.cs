using System;

namespace DesktopBridgeSample.Extensions
{
    public static class FunctionalExtensions
    {
        public static T Lock<T>(object lockObject, Func<T> action)
        {
            lock (lockObject)
            {
                return action();
            }
        }
    }
}
