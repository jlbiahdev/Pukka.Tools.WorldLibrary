using System;

namespace Pukka.Tools.Countries.Utils
{
    internal static class ExceptionChecker
    {
        internal static void ThrowArgumentNullExceptionIfNullOrEmpty(dynamic obj, string paramName)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(paramName);
            }
            if (obj is string && string.IsNullOrWhiteSpace(obj.ToString()))
            {
                throw new ArgumentNullException(paramName);
            }
        }
    }
}
