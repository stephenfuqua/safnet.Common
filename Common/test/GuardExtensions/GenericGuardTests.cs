using NUnit.Framework;
using System;
using Shouldly;
using safnet.Common.GenericExtensions;

namespace safnet.Common.UnitTests.GuardExtensions
{
    [TestFixture]
    public class GenericGuardTests
    {
        public class TestClass
        {
        }

        [TestFixture]
        public class Given_null_value
        {
            [TestFixture]
            public class When_asserting_not_null
            {
                protected const string ArgName = "asdfg";
                protected Exception Exception;

                [SetUp]
                public void Act()
                {
                    try
                    {
                        (null as TestClass).MustNotBeNull(ArgName);
                    }
                    catch (Exception ex)
                    {
                        Exception = ex;
                    }
                }

                [Test]
                public void Then_throw_ArgumentNullException()
                {
                    Exception.ShouldBeAssignableTo<ArgumentNullException>();
                }

                [Test]
                public void Then_exception_message_should_contain_argument_name()
                {
                    (Exception as ArgumentNullException).ParamName.ShouldBe(ArgName);
                }
            }
        }

        [TestFixture]
        public class Given_instantiated_value
        {
            [TestFixture]
            public class When_asserting_not_null
            {
                protected const string ArgName = "asdfg";
                protected readonly TestClass Value = new TestClass();
                protected object Result;

                [SetUp]
                public void Act()
                {
                    Result = Value.MustNotBeNull(ArgName);
                }

                [Test]
                public void Then_return_original_object()
                {
                    Result.ShouldBeSameAs(Value);
                }
            }
        }
    }
}
