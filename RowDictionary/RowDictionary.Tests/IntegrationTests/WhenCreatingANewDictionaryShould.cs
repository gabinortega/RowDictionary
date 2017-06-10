using NUnit.Framework;

namespace RowDictionary.Tests.IntegrationTests
{
    [TestFixture]
    public class WhenCreatingANewDictionaryShould
    {
        [Test]
        public void ShouldBeAbleToSpecifyAnyTypeOfTheKeyPrimitiveExample()
        {
            var dict = new RowDictionary< int , string>();
            Assert.That(dict.GetType(), Is.EqualTo(typeof(RowDictionary<int, string>)));
        }

        [Test]
        public void ShouldBeAbleToSpecifyAnyTypeOfTheKeyObjectExample()
        {
            var dict = new RowDictionary<object, string>();
            Assert.That(dict.GetType(), Is.EqualTo(typeof(RowDictionary<object, string>)));
        }

        [Test]
        public void ShouldBeAbleToSpecifyAnyTypeOfTheValuePrimitiveExample()
        {
            var dict = new RowDictionary<int, int>();
            Assert.That(dict.GetType(), Is.EqualTo(typeof(RowDictionary<int, int>)));
        }

        [Test]
        public void ShouldBeAbleToSpecifyAnyTypeOfTheValueObjectExample()
        {
            var dict = new RowDictionary<int, object>();
            Assert.That(dict.GetType(), Is.EqualTo(typeof(RowDictionary<int, object>)));
        }
    }
}
