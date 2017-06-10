using NUnit.Framework;

namespace RowDictionary.Tests.IntegrationTests
{
    [TestFixture]
    public class RowDictionaryWhenAddingKeyAndValuesTests
    {
        [Test]
        public void ShouldBeAbleToAddANewValueAndRetriveTheSameValueUsingTheSameKey()
        {
            var key = "key";
            var expectedValue = "Hola mundo";
            var sut = new RowDictionary<string, string>();
            sut.Add(key, expectedValue);
            string result;
            sut.TryGetValue(key, out result);

            Assert.That(result, Is.EqualTo(expectedValue));
        }

        [Test]
        public void ShouldBeAbleToRetrieveTheValueUsingTheKeyWhenThereIsOnlyOneValueInserted()
        {
            var key = 01;
            var expectedValue = "expectedValue";
            var sut = new RowDictionary<int, string>();
            sut.Add(key, expectedValue);
            string result;
            sut.TryGetValue(key, out result);

            Assert.That(result, Is.EqualTo(expectedValue));
        }

        [Test]
        public void ShouldBeAbleToRetrieveTheValueUsingTheKeyWhenThereIsMoreThanOneValueInserted()
        {
            var key = 04;
            var expectedValue = "expectedValue";
            var sut = new RowDictionary<int, string>();
            sut.Add(01, "01");
            sut.Add(02, "02");
            sut.Add(03, "03");
            sut.Add(key, expectedValue);
            string result;
            sut.TryGetValue(key, out result);

            Assert.That(result, Is.EqualTo(expectedValue));
        }

        [Test]
        public void ShouldBeAbleToRetrieveTheValueUsingTheKeyWhenTheKeyIsNonPrimitive()
        {
            var myKey = new { FirstName = "ABC", LastName = "DFG" };
            const string whenTheKeyIsAnObject = "WhenTheKeyIsAnObject";
            var sut = new RowDictionary<object, string>();
            sut.Add(myKey, whenTheKeyIsAnObject);
            string result;
            sut.TryGetValue(myKey, out result);

            Assert.That(result, Is.EqualTo(whenTheKeyIsAnObject));
        }
    }
}
