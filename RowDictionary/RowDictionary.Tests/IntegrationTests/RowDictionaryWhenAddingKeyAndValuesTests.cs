using NUnit.Framework;

namespace RowDictionary.Tests.IntegrationTests
{
    [TestFixture]
    public class RowDictionaryWhenAddingKeyAndValuesTests
    {
        [Test]
        public void ShouldBeAbleToAddANewValueAndRetriveTheSameValueUsingTheSameKey()
        {
            //Arrange
            var key = "key";
            var expectedValue = "Hola mundo";
            var sut = new RowDictionary<string, string>();
            sut.Add(key, expectedValue);
            string result;

            //Act
            sut.TryGetValue(key, out result);

            //Assert
            Assert.That(result, Is.EqualTo(expectedValue));
        }

        [Test]
        public void ShouldBeAbleToRetrieveTheValueUsingTheKeyWhenTheKeyIsNonPrimitive()
        {
            //Arrange
            var myKey = new {FirstName = "ABC", LastName = "DFG"};
            const string whenTheKeyIsAnObject = "WhenTheKeyIsAnObject";
            var sut = new RowDictionary<object, string>();
            sut.Add(myKey, whenTheKeyIsAnObject);
            string result;

            //Act
            sut.TryGetValue(myKey, out result);

            //Assert
            Assert.That(result, Is.EqualTo(whenTheKeyIsAnObject));
        }

        [Test]
        public void ShouldBeAbleToRetrieveTheValueUsingTheKeyWhenThereIsMoreThanOneValueInserted()
        {
            //Arrange
            var key = 04;
            var expectedValue = "expectedValue";
            var sut = new RowDictionary<int, string>();
            sut.Add(01, "01");
            sut.Add(02, "02");
            sut.Add(03, "03");
            sut.Add(key, expectedValue);
            string result;

            //Act
            sut.TryGetValue(key, out result);

            //Assert
            Assert.That(result, Is.EqualTo(expectedValue));
        }

        [Test]
        public void ShouldBeAbleToRetrieveTheValueUsingTheKeyWhenThereIsOnlyOneValueInserted()
        {
            //Arrange
            var key = 01;
            var expectedValue = "expectedValue";
            var sut = new RowDictionary<int, string>();
            sut.Add(key, expectedValue);
            string result;

            //Act
            sut.TryGetValue(key, out result);

            //Assert
            Assert.That(result, Is.EqualTo(expectedValue));
        }
    }
}