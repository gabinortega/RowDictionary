using System;
using System.Collections.Generic;
using NUnit.Framework;
using RowDictionary.Services;

namespace RowDictionary.Tests.UnitTests.Services
{
    [TestFixture]
    public class EqualityProviderTests
    {
        [Test]
        public void ShouldReturnCaseInsensitiveComparerWhenKeyIsAString()
        {
            //Arrange
            var sut = new EqualityServiceProvider<string>();

            //Act
            var result = sut.GetKeyComparer(Comparer<string>.Default);

            //Assert
            Assert.That(result.GetType(), Is.EqualTo(StringComparer.InvariantCultureIgnoreCase.GetType()));
        }

        [Test]
        public void ShouldReturnTheSameProviderWhenKeyIsNotString()
        {
            //Arrange
            var sut = new EqualityServiceProvider<int>();

            //Act
            var result = sut.GetKeyComparer(Comparer<int>.Default);

            //Assert
            Assert.That(result.GetType(), Is.Not.EqualTo(StringComparer.InvariantCultureIgnoreCase.GetType()));
        }
    }
}