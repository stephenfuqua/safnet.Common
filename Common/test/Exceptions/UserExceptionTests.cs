using safnet.Common.Exceptions;
using System.Collections.Generic;
using NUnit.Framework;
using Shouldly;

namespace safnet.Common.UnitTests.Exceptions
{
    [TestFixture]
    public class UserExceptionTests
    {
        [Test]
        public void ConfirmTheBasicConstructor()
        {
            var expected = "asdfasdf";
            var actual = new UserException(expected);

            actual.Message.ShouldBe(expected);
        }
        
        [Test]
        public void ConfirmMessageFromListWithOneError()
        {
            var expected = "one";
            var errors = new List<string>() { expected };

            var actual = UserException.FromMultipleMessages(errors);

            actual.Message.ShouldBe(expected);
        }

        [Test]
        public void ConfirmMessageFromListWithTwoErrors()
        {
            var errors = new List<string>() { "one", "two" };
            var expected = "one, two";

            var actual = UserException.FromMultipleMessages(errors);

            actual.Message.ShouldBe(expected);
        }
    }
}
