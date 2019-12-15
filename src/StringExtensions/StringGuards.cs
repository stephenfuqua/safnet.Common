using System;

namespace safnet.Common.StringExtensions
{
    public static class StringGuards
    {
        public static string MustNotBeNull(this string value, string name)
        {
            if (value == null)
            {
                throw new ArgumentNullException(name);
            }

            return value;
        }

        public static string MustNotBeNullOrEmpty(this string value, string name)
        {
            MustNotBeNull(value, name);

            if (value.Trim().Length == 0)
            {
                throw new ArgumentException("Argument cannot be an empty string", name);
            }

            return value;
        }
    }
}
