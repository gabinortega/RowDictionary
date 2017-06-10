using NUnit.Framework;

namespace RowDictionary.Tests.IntegrationTests
{
    [TestFixture]
    public class RowDictionaryWhenCreatingANewDictionaryTests
    {
        [Test]
        public void ShouldBeAbleToSpecifyAnyTypeOfTheKeyPrimitiveExample()
        {
            var sut = new RowDictionary< int , string>();
            Assert.That(sut.GetType(), Is.EqualTo(typeof(RowDictionary<int, string>)));
        }

        [Test]
        public void ShouldBeAbleToSpecifyAnyTypeOfTheKeyObjectExample()
        {
            var sut = new RowDictionary<object, string>();
            Assert.That(sut.GetType(), Is.EqualTo(typeof(RowDictionary<object, string>)));
        }

        [Test]
        public void ShouldBeAbleToSpecifyAnyTypeOfTheValuePrimitiveExample()
        {
            var sut = new RowDictionary<int, int>();
            Assert.That(sut.GetType(), Is.EqualTo(typeof(RowDictionary<int, int>)));
        }

        [Test]
        public void ShouldBeAbleToSpecifyAnyTypeOfTheValueObjectExample()
        {
            var sut = new RowDictionary<int, object>();
            Assert.That(sut.GetType(), Is.EqualTo(typeof(RowDictionary<int, object>)));
        }
    }
}
