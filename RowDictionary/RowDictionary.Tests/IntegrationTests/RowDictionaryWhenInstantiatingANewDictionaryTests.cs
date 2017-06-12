using System;
using NUnit.Framework;

namespace RowDictionary.Tests.IntegrationTests
{
    [TestFixture]
    public class RowDictionaryWhenInstantiatingANewDictionaryTests
    {
        [Test]
        public void ShouldBeAbleToSpecifyEqualityServiceToUse()
        {
            //Arrange
            var equalityService = StringComparer.CurrentCulture;

            //Act
            var sut = new RowDictionary<string, string>(equalityService);

            //Assert
            Assert.That(sut, Is.TypeOf<RowDictionary<string, string>>());
        }
    }
}