using NUnit.Framework;

namespace RowDictionary.Tests.IntegrationTests
{
    [TestFixture]
    public class RowDictionaryWhenKeyIsAnStringTests
    {
        [Test]
        public void ShouldSearchByKeyCaseInsensitiveUpperExample()
        {
            var key = "keyUPPERandlower";
            var expected = "expected";
            var sut = new RowDictionary<string, string> { { key, expected } };
            var result02 = sut[key.ToUpper()];
            Assert.That(result02, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldSearchByKeyCaseInsensitiveLowerExample()
        {
            var key = "keyUPPERandlower";
            var expected = "expected";
            var sut = new RowDictionary<string, string> { { key, expected } };
            var result03 = sut[key.ToLower()];
            Assert.That(result03, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldSearchByKeyCaseInsensitiveTheSameKey()
        {
            var key = "keyUPPERandlower";
            var expected = "expected";
            var sut = new RowDictionary<string, string> { { key, expected } };
            var result01 = sut[key];
            Assert.That(result01, Is.EqualTo(expected));
        }
    }
}
