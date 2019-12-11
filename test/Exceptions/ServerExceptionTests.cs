using safnet.Common.BaseClasses;
using safnet.Common.Exceptions;
using System;
using NUnit.Framework;

namespace safnet.Common.UnitTests.Exceptions
{
    public class ServerExceptionTest
    {
        public class Entity : IEntity
        {
            public int Id { get; set; }
        }

        public class WrapAGeneralExceptionInServerExceptionWithNonNullId
        {
            const int Id = 23423423;
            const string Action = "Update";
            const string Message = "this is a message";
            static Exception _exception = new Exception(Message);
            static Type _type = typeof(Entity);

            private ServerException RunTheTest()
            {
                return ServerException.HandleException<Entity>(_exception, Action, Id);
            }

            [Test]
            public void ConfirmThatTheExceptionMessageIsStaticConstant()
            {
                Assert.AreEqual(ServerException.DefaultMessage, ((Exception) RunTheTest()).Message);
            }

            [Test]
            public void ConfirmTheInnerException()
            {
                Assert.AreSame(_exception, RunTheTest().InnerException);
            }

            [Test]
            public void ConfirmTheContentDescriptionProperty()
            {
                Assert.AreEqual(Message, RunTheTest().Content.Description);
            }

            [Test]
            public void ConfirmTheContentIdProperty()
            {
                Assert.AreEqual(Id, RunTheTest().Content.Id);
            }

            [Test]
            public void ConfirmTheContentActionProperty()
            {
                Assert.AreEqual(Action, RunTheTest().Content.Action);
            }

            [Test]
            public void ConfirmTheContentModelTypeProperty()
            {
                Assert.AreEqual(_type, RunTheTest().Content.ModelType);
            }
        }

        public class CreateExceptionForAFailedDatabaseUpdate
        {
            const string Description = "Something bad happened";
            const int Id = 23423423;
            const string Action = "Update";
            static Type _type = typeof(Entity);


            private static ServerException RunTheTest()
            {
                return ServerException.UpdateFailed<Entity>(Description, Id);
            }

            [Test]
            public void ConfirmThatTheExceptionMessageIsStaticConstant()
            {
                Assert.AreEqual(ServerException.DefaultMessage, ((Exception) RunTheTest()).Message);
            }

            [Test]
            public void ConfirmTheContentDescriptionProperty()
            {
                Assert.AreEqual(Description, RunTheTest().Content.Description);
            }

            [Test]
            public void ConfirmTheContentIdProperty()
            {
                Assert.AreEqual(Id, RunTheTest().Content.Id);
            }

            [Test]
            public void ConfirmTheContentActionProperty()
            {
                Assert.AreEqual(Action, RunTheTest().Content.Action);
            }

            [Test]
            public void ConfirmTheContentModelTypeProperty()
            {
                Assert.AreEqual(_type, RunTheTest().Content.ModelType);
            }
        }
    }
}
