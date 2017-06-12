using NUnit.Framework;

namespace RowDictionary.Tests.IntegrationTests
{
    [TestFixture]
    public class RowDictionaryWhenKeyIsAnStringTests
    {
        [Test]
        public void ShouldSearchByKeyCaseInsensitiveLowerExample()
        {
            //Arrange
            var key = "keyUPPERandlower";
            var expected = "expected";
            var sut = new RowDictionary<string, string> {{key, expected}};

            //Act
            var result03 = sut[key.ToLower()];

            //Assert
            Assert.That(result03, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldSearchByKeyCaseInsensitiveTheSameKey()
        {
            //Arrange
            var key = "keyUPPERandlower";
            var expected = "expected";
            var sut = new RowDictionary<string, string> {{key, expected}};

            //Act
            var result01 = sut[key];

            //Assert
            Assert.That(result01, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldSearchByKeyCaseInsensitiveUpperExample()
        {
            //Arrange
            var key = "keyUPPERandlower";
            var expected = "expected";
            var sut = new RowDictionary<string, string> {{key, expected}};

            //Act
            var result02 = sut[key.ToUpper()];

            //Assert
            Assert.That(result02, Is.EqualTo(expected));
        }
    }
}