using NUnit.Framework;
using System;
using Shouldly;
using safnet.Common.StringExtensions;

namespace safnet.Common.UnitTests.GuardExtensions
{
    [TestFixture]
    public class StringGuardTests
    {
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
                        (null as string).MustNotBeNull(ArgName);
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

            [TestFixture]
            public class When_asserting_not_null_or_empty
            {
                protected const string ArgName = "asdfg";
                protected Exception Exception;

                [SetUp]
                public void Act()
                {
                    try
                    {
                        (null as string).MustNotBeNullOrEmpty(ArgName);
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
        public class Given_some_spaces
        {
            [TestFixture]
            public class When_asserting_not_null
            {
                protected const string Original = "       ";
                protected const string ArgName = "asdfg";
                protected string Result;

                [SetUp]
                public void Act()
                {
                    Result = Original.MustNotBeNull(ArgName);
                }

                [Test]
                public void Then_return_original_string()
                {
                    Result.ShouldBe(Original);
                }
            }

            [TestFixture]
            public class When_asserting_not_null_or_empty
            {
                protected const string Original = "       ";
                protected const string ArgName = "asdfg";
                protected Exception Exception;

                [SetUp]
                public void Act()
                {
                    try
                    {
                        Original.MustNotBeNullOrEmpty(ArgName);
                    }
                    catch (Exception ex)
                    {
                        Exception = ex;
                    }
                }

                [Test]
                public void Then_throw_ArgumentException()
                {
                    Exception.ShouldBeAssignableTo<ArgumentException>();
                }

                [Test]
                public void Then_exception_message_should_contain_argument_name()
                {
                    (Exception as ArgumentException).ParamName.ShouldBe(ArgName);
                }
            }

        }

        [TestFixture]
        public class Given_random_string_value
        {
            [TestFixture]
            public class When_asserting_not_null
            {
                protected const string Original = "random value";
                protected const string ArgName = "asdfg";
                protected string Result;

                [SetUp]
                public void Act()
                {
                    Result = Original.MustNotBeNull(ArgName);
                }

                [Test]
                public void Then_return_original_string()
                {
                    Result.ShouldBe(Original);
                }
            }

            [TestFixture]
            public class When_asserting_not_null_or_empty
            {
                protected const string Original = "random value";
                protected const string ArgName = "asdfg";
                protected string Result;

                [SetUp]
                public void Act()
                {
                    Result = Original.MustNotBeNullOrEmpty(ArgName);
                }

                [Test]
                public void Then_return_original_string()
                {
                    Result.ShouldBe(Original);
                }
            }

        }
    }
}
