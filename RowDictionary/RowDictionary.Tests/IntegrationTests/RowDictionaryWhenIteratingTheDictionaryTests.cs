using System.Linq;
using NUnit.Framework;

namespace RowDictionary.Tests.IntegrationTests
{
    [TestFixture]
    public class RowDictionaryWhenIteratingTheDictionaryTests
    {
        [Test]
        public void ShouldIterateExactlyAsManyTimesAsKeysAdded()
        {
            //Arrange
            var sut = new RowDictionary<int, string>();
            sut.Add(01, "Value01");
            sut.Add(02, "Value02");
            sut.Add(03, "Value03");
            sut.Add(04, "Value04");
            sut.Add(05, "Value05");
            sut.Add(06, "Value06");

            //Act
            var totalItems = sut.Cast<object>().Count();

            //Assert
            Assert.That(totalItems, Is.EqualTo(6));
        }
    }
}