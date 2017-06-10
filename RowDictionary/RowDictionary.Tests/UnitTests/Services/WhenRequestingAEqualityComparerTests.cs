using System;
using System.Collections.Generic;
using NUnit.Framework;
using RowDictionary.Services;

namespace RowDictionary.Tests.UnitTests.Services
{
    [TestFixture]
    public class WhenRequestingAEqualityComparerTests
    {
        [Test]
        public void ShouldBeCaseInsensitiveWhenIsAString()
        {
            var equalityServiceProvider = new EqualityServiceProvider<string>();
            var result = equalityServiceProvider.GetEqualityService(EqualityComparer<string>.Default);

            Assert.That(result.GetType(),Is.EqualTo(StringComparer.InvariantCultureIgnoreCase.GetType()));
        }

        [Test]
        public void ShouldBeATheOneProviderWhenIsNotString()
        {
            var equalityServiceProvider = new EqualityServiceProvider<int>();
            var result = equalityServiceProvider.GetEqualityService(EqualityComparer<int>.Default);

            Assert.That(result.GetType(), Is.Not.EqualTo(StringComparer.InvariantCultureIgnoreCase.GetType()));
        }
    }
}
