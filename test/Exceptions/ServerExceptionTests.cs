using safnet.Common.BaseClasses;
using safnet.Common.Exceptions;
using System;
using NUnit.Framework;
using Shouldly;

namespace safnet.Common.UnitTests.Exceptions
{
    public class ServerExceptionTest
    {
        public class Entity : IEntity
        {
            public int Id { get; set; }
        }

        [TestFixture]
        public class WrapAGeneralExceptionInServerExceptionWithNonNullId
        {
            const int Id = 23423423;
            const string Action = "Update";
            const string Message = "this is a message";
            static Exception _exception = new Exception(Message);
            static Type _type = typeof(Entity);
            private ServerException _result;

            [SetUp]
            public void Act()
            {
                _result = ServerException.HandleException<Entity>(_exception, Action, Id);
            }

            [Test]
            public void ConfirmThatTheExceptionMessageIsStaticConstant()
            {
                _result.Message.ShouldBe(ServerException.DefaultMessage);
            }

            [Test]
            public void ConfirmTheInnerException()
            {
                _result.InnerException.ShouldBeSameAs(_exception);
            }

            [Test]
            public void ConfirmTheContentDescriptionProperty()
            {
                _result.Content.Description.ShouldBe(Message);
            }

            [Test]
            public void ConfirmTheContentIdProperty()
            {
                _result.Content.Id.ShouldBe(Id);
            }

            [Test]
            public void ConfirmTheContentActionProperty()
            {
                _result.Content.Action.ShouldBe(Action);
            }

            [Test]
            public void ConfirmTheContentModelTypeProperty()
            {
                _result.Content.ModelType.ShouldBe(_type);
            }
        }

        [TestFixture]
        public class CreateExceptionForAFailedDatabaseUpdate
        {
            const string Description = "Something bad happened";
            const int Id = 23423423;
            const string Action = "Update";
            static Type _type = typeof(Entity);
            private ServerException _result;

            [SetUp]
            public void Act()
            {
                _result = ServerException.UpdateFailed<Entity>(Description,  Id);
            }

            [Test]
            public void ConfirmThatTheExceptionMessageIsStaticConstant()
            {
                _result.Message.ShouldBe(ServerException.DefaultMessage);
            }

            [Test]
            public void ConfirmTheContentDescriptionProperty()
            {
                _result.Content.Description.ShouldBe(Description);
            }

            [Test]
            public void ConfirmTheContentIdProperty()
            {
                _result.Content.Id.ShouldBe(Id);
            }

            [Test]
            public void ConfirmTheContentActionProperty()
            {
                _result.Content.Action.ShouldBe(Action);
            }

            [Test]
            public void ConfirmTheContentModelTypeProperty()
            {
                _result.Content.ModelType.ShouldBe(_type);
            }
        }
    }
}
