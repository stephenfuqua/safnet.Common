using System;
using System.Collections.Generic;
using Shouldly;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using safnet.Common.Exceptions;

namespace safnet.Common.UnitTests.Exceptions
{
    public class DomainValidationExceptionTests
    {
        [TestFixture]
        public class Constructor
        {
            [TestFixture]

            public class ConfirmHappyPath
            {
                private List<ValidationResult> _list = new List<ValidationResult>();
                private DomainValidationException _result;

                [SetUp]
                public void Act()
                {
                    _result = DomainValidationException.Create(_list);
                }

                [Test]
                public void ContainsTheValidationList()
                {
                    _result.ValidationResults.ShouldBeSameAs(_list);
                }

                [Test]
                public void HasTheDefaultMessage()
                {
                    _result.Message.ShouldBe(DomainValidationException.DefaultMessage);
                }
            }

            [Test]
            public void ConfirmDoesNotAcceptNullArgument()
            {
                Action act = () => DomainValidationException.Create(null);
                act.ShouldThrow<ArgumentNullException>();
            }
        }
    }
}
