using System.Collections.Generic;
using NUnit.Framework;

namespace RowDictionary.Tests.IntegrationTests
{
    [TestFixture]
    public class RowDictionaryWhenUsingBracketOperatorTests
    {
        [Test]
        public void ShouldBeAbleToRetrieveTheValueUsingTheKeyWhenTheKeyIsNonPrimitive()
        {
            //Arrange
            var myKey = new {FirstName = "ABC", LastName = "DFG"};
            var WhenTheKeyIsAnObject = "WhenTheKeyIsAnObject";
            var sut = new RowDictionary<object, string>
            {
                {myKey, WhenTheKeyIsAnObject}
            };

            //Act
            var result = sut[myKey];

            //Assert
            Assert.That(result, Is.EqualTo(WhenTheKeyIsAnObject));
        }

        [Test]
        public void ShouldBeAbleToRetrieveTheValueUsingTheKeyWhenThereIsMoreThanOneValueInserted()
        {
            //Arrange
            var key = 41;
            var anotherValue = "anotherValue";
            var sut = new RowDictionary<int, string> {{7, "abc"}, {410, "era"}, {8, "era"}, {key, anotherValue}};

            //Act
            var result = sut[key];

            //Assert
            Assert.That(result, Is.EqualTo(anotherValue));
        }

        [Test]
        public void ShouldBeAbleToRetrieveTheValueUsingTheKeyWhenThereIsOnlyOneValueInserted()
        {
            //Arrange
            var key = 55;
            var expectedValue = "expectedValue";
            var sut = new RowDictionary<int, string> {{key, expectedValue}};

            //Act
            var result = sut[key];

            //Assert
            Assert.That(result, Is.EqualTo(expectedValue));
        }

        [Test]
        public void ShouldThrowAnExceptionIfTheKeyDoesNotExist()
        {
            //Arrange
            var sut = new RowDictionary<string, string>
            {
                {"key01", "Value01"}
            };
            string result;

            //Act
            //Assert
            Assert.That(() => result = sut["keyDoesNotExist"], Throws.TypeOf<KeyNotFoundException>());
        }
    }
}