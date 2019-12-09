using System;

namespace safnet.Common.Exceptions
{
    public class DoesNotExistException : Exception
    {
        public DoesNotExistException(string message) : base(message)
        {

        }
    }
}
