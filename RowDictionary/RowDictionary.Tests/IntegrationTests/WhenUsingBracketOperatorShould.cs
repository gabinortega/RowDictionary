using System.Collections.Generic;
using NUnit.Framework;

namespace RowDictionary.Tests.IntegrationTests
{
    [TestFixture]
    public class WhenUsingBracketOperatorShould
    {
        [Test]
        public void ShouldBeAbleToRetrieveTheValueUsingTheKeyWhenThereIsOnlyOneValueInserted()
        {
            var key = 55;
            var expectedValue = "expectedValue";
            var dict = new RowDictionary<int, string> { { key, expectedValue } };
            var result = dict[key];

            Assert.That(result, Is.EqualTo(expectedValue));
        }

        [Test]
        public void ShouldBeAbleToRetrieveTheValueUsingTheKeyWhenThereIsMoreThanOneValueInserted()
        {
            var key = 41;
            var anotherValue = "anotherValue";
            var dict = new RowDictionary<int, string> { { 7, "abc" }, { 410, "era" }, { 8, "era" }, { key, anotherValue } };
            var result = dict[key];

            Assert.That(result, Is.EqualTo(anotherValue));
        }

        [Test]
        public void ShouldBeAbleToRetrieveTheValueUsingTheKeyWhenTheKeyIsNonPrimitive()
        {
            var myKey = new { FirstName = "ABC", LastName = "DFG" };
            var WhenTheKeyIsAnObject = "WhenTheKeyIsAnObject";
            var dict = new RowDictionary<object, string>
            {
                {myKey, WhenTheKeyIsAnObject}
            };
            var result = dict[myKey];

            Assert.That(result, Is.EqualTo(WhenTheKeyIsAnObject));
        }

        [Test]
        public void ShouldThrowAnExceptionIfTheKeyDoesNotExist()
        {
            var dict = new RowDictionary<object, string>
            {
                {01, "Value01"},
            };
            string result;
            Assert.That(() => result = dict["keyDoesNotExist"], Throws.TypeOf<KeyNotFoundException>());
        }
    }
}
