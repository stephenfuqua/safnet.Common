using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace safnet.Common.Exceptions
{
    public class DomainValidationException : Exception
    {
        public const string DefaultMessage = "A validation error has occurred.";
 
        public IEnumerable<ValidationResult> ValidationResults
        {
            get; private set;
        }

        private DomainValidationException() : base(DefaultMessage)
        {
        }


        public static DomainValidationException Create(IEnumerable<ValidationResult> results)
        {
            var e = new DomainValidationException
            {
                ValidationResults = results ?? throw new ArgumentNullException(nameof(results))
            };

            return e;
        }
    }
}
