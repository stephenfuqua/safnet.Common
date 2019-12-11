using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using safnet.Common.Exceptions;

namespace safnet.Common.UnitTests.Exceptions
{
    public class DomainValidationExceptionTests
    {
        public class Constructor
        {
            [Test]
            public void ConfirmHappyPath()
            {
                var list = new List<ValidationResult>();

                var system = DomainValidationException.Create(list);

                Assert.AreSame(list, system.ValidationResults);
                Assert.AreEqual(DomainValidationException.DefaultMessage, ((Exception) system).Message);
            }

            [Test]
            public void ConfirmDoesNotAcceptNullArgument()
            {
                Assert.Throws<ArgumentNullException>(() => DomainValidationException.Create(null));
            }
        }
    }
}
