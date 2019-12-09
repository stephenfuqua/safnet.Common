using safnet.Common.BaseClasses;
using safnet.Common.Exceptions;
using System;
using Xunit;

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

            [Fact]
            public void ConfirmThatTheExceptionMessageIsStaticConstant()
            {
                Assert.Equal(ServerException.DefaultMessage, ((Exception) RunTheTest()).Message);
            }

            [Fact]
            public void ConfirmTheInnerException()
            {
                Assert.Same(_exception, RunTheTest().InnerException);
            }

            [Fact]
            public void ConfirmTheContentDescriptionProperty()
            {
                Assert.Equal(Message, RunTheTest().Content.Description);
            }

            [Fact]
            public void ConfirmTheContentIdProperty()
            {
                Assert.Equal(Id, RunTheTest().Content.Id);
            }

            [Fact]
            public void ConfirmTheContentActionProperty()
            {
                Assert.Equal(Action, RunTheTest().Content.Action);
            }

            [Fact]
            public void ConfirmTheContentModelTypeProperty()
            {
                Assert.Equal(_type, RunTheTest().Content.ModelType);
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

            [Fact]
            public void ConfirmThatTheExceptionMessageIsStaticConstant()
            {
                Assert.Equal(ServerException.DefaultMessage, ((Exception) RunTheTest()).Message);
            }

            [Fact]
            public void ConfirmTheContentDescriptionProperty()
            {
                Assert.Equal(Description, RunTheTest().Content.Description);
            }

            [Fact]
            public void ConfirmTheContentIdProperty()
            {
                Assert.Equal(Id, RunTheTest().Content.Id);
            }

            [Fact]
            public void ConfirmTheContentActionProperty()
            {
                Assert.Equal(Action, RunTheTest().Content.Action);
            }

            [Fact]
            public void ConfirmTheContentModelTypeProperty()
            {
                Assert.Equal(_type, RunTheTest().Content.ModelType);
            }
        }
    }
}
