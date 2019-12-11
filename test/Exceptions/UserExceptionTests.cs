using safnet.Common.Exceptions;
using System.Collections.Generic;
using NUnit.Framework;

namespace safnet.Common.UnitTests.Exceptions
{
    public class UserExceptionTests
    {
        [Test]
        public void ConfirmTheBasicConstructor()
        {
            var message = "asdfasdf";
            var actual = new UserException(message);
            Assert.AreEqual(message, actual.Message);
        }
        
        [Test]
        public void ConfirmMessageFromListWithOneError()
        {
            var errors = new List<string>() { "one" };
            var expected = "one";

            var actual = UserException.FromMultipleMessages(errors);

            Assert.AreEqual(expected, actual.Message);
        }

        [Test]
        public void ConfirmMessageFromListWithTwoErrors()
        {
            var errors = new List<string>() { "one", "two" };
            var expected = "one, two";

            var actual = UserException.FromMultipleMessages(errors);

            Assert.AreEqual(expected, actual.Message);
        }
    }
}
