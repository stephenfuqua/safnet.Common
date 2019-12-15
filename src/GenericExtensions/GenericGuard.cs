using System;
namespace safnet.Common.GenericExtensions
{
    public static class GenericGuard
    {
        public static T MustNotBeNull<T>(this T value, string name)
        {
            if (value == null)
            {
                throw new ArgumentNullException(name);
            }

            return value;
        }
    }
}
