using System.Linq;
using NUnit.Framework;

namespace RowDictionary.Tests
{
    [TestFixture]
    class WhenIteratingTheDictionaryShould
    {
        [Test]
        public void ShouldIterateExactlyAsManyTimesAsKeysAdded()
        {
            var dict = new RowDictionary<int, string>();
            dict.Add(01, "Value01");
            dict.Add(02, "Value02");
            dict.Add(03, "Value03");
            dict.Add(04, "Value04");
            dict.Add(05, "Value05");
            dict.Add(06, "Value06");

            var totalItems = dict.Cast<object>().Count();
            Assert.That(totalItems, Is.EqualTo(6));
        }
    }
}
