using System;

namespace Screamer.Primitives
{
    public static class Guard
    {
        public static T CheckNull<T>(T param, string paramName) =>
            param == null ? throw new ArgumentNullException(paramName) : param;
    }
}