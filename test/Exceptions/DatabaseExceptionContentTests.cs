using NUnit.Framework;
using safnet.Common.Exceptions;

namespace safnet.Common.UnitTests.Exceptions
{
    [TestFixture]
    public class DatabaseExceptionContentTests
    {
        [Test]
        public void ConfirmGetAndSetForId()
        {
            var expected = 2234;

            var system = new DatabaseExceptionContent();

            system.Id = expected;

            var actual = system.Id;

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void ConfirmGetAndSetForIdAsNull()
        {
            var system = new DatabaseExceptionContent();

            system.Id = null;

            Assert.Null(system.Id);
        }

        [Test]
        public void ConfirmGetAndSetForAction()
        {
            var expected = "2234";

            var system = new DatabaseExceptionContent();

            system.Action = expected;

            var actual = system.Action;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ConfirmGetAndSetForModelType()
        {
            var expected = this.GetType();

            var system = new DatabaseExceptionContent();

            system.ModelType = expected;

            var actual = system.ModelType;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ConfirmGetAndSetForDescription()
        {
            var expected = "2234";

            var system = new DatabaseExceptionContent();

            system.Description = expected;

            var actual = system.Description;

            Assert.AreEqual(expected, actual);
        }
    }
}
