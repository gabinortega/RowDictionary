using NUnit.Framework;

namespace RowDictionary.Tests.IntegrationTests
{
    [TestFixture]
    public class WhenAddingKeyAndValuesShould
    {
        [Test]
        public void ShouldBeAbleToAddANewValueAndRetriveTheSameValueUsingTheSameKey()
        {
            var key = "key";
            var value = "Hola mundo";
            var dict = new RowDictionary<string, string>();
            dict.Add(key, value);
            string result;
            dict.TryGetValue(key, out result);

            Assert.That(result, Is.EqualTo(value));
        }

        [Test]
        public void ShouldBeAbleToRetrieveTheValueUsingTheKeyWhenThereIsOnlyOneValueInserted()
        {
            var key = 01;
            var expectedValue = "expectedValue";
            var dict = new RowDictionary<int, string>();
            dict.Add(key, expectedValue);
            string result;
            dict.TryGetValue(key, out result);

            Assert.That(result, Is.EqualTo(expectedValue));
        }

        [Test]
        public void ShouldBeAbleToRetrieveTheValueUsingTheKeyWhenThereIsMoreThanOneValueInserted()
        {
            var key = 04;
            var expectedValue = "expectedValue";
            var dict = new RowDictionary<int, string>();
            dict.Add(01, "01");
            dict.Add(02, "02");
            dict.Add(03, "03");
            dict.Add(key, expectedValue);
            string result;
            dict.TryGetValue(key, out result);

            Assert.That(result, Is.EqualTo(expectedValue));
        }

        [Test]
        public void ShouldBeAbleToRetrieveTheValueUsingTheKeyWhenTheKeyIsNonPrimitive()
        {
            var myKey = new { FirstName = "ABC", LastName = "DFG" };
            const string whenTheKeyIsAnObject = "WhenTheKeyIsAnObject";
            var dict = new RowDictionary<object, string>();
            dict.Add(myKey, whenTheKeyIsAnObject);
            string result;
            dict.TryGetValue(myKey, out result);

            Assert.That(result, Is.EqualTo(whenTheKeyIsAnObject));
        }
    }
}
