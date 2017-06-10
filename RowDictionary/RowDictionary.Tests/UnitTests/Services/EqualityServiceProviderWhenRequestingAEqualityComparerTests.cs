using System;
using System.Collections.Generic;
using NUnit.Framework;
using RowDictionary.Services;

namespace RowDictionary.Tests.UnitTests.Services
{
    [TestFixture]
    public class EqualityServiceProviderWhenRequestingAEqualityComparerTests
    {
        [Test]
        public void ShouldBeCaseInsensitiveWhenIsAString()
        {
            var sut = new EqualityServiceProvider<string>();
            var result = sut.GetEqualityService(EqualityComparer<string>.Default);

            Assert.That(result.GetType(),Is.EqualTo(StringComparer.InvariantCultureIgnoreCase.GetType()));
        }

        [Test]
        public void ShouldBeATheOneProviderWhenIsNotString()
        {
            var sut = new EqualityServiceProvider<int>();
            var result = sut.GetEqualityService(EqualityComparer<int>.Default);

            Assert.That(result.GetType(), Is.Not.EqualTo(StringComparer.InvariantCultureIgnoreCase.GetType()));
        }
    }
}
