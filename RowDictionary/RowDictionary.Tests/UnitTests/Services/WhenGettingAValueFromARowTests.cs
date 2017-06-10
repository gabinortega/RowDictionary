using System.Collections.Generic;
using NUnit.Framework;
using RowDictionary.Services;

namespace RowDictionary.Tests.UnitTests.Services
{
    [TestFixture]
    public class WhenGettingAValueFromARowTests
    {
        private List<KeyValuePair<int, string>> _row;
        private IRowService<int, string> _rowService;

        [SetUp]
        public void BeforeEachTest()
        {
            _row = new List<KeyValuePair<int, string>>();
            _rowService = new RowService<int, string>();
        }

        [Test]
        public void ShouldBeAbleToRetrieveTheValueUsingTheKeyWhenThereIsOnlyOneValueInserted()
        {
            var key = 55;
            var expectedValue = "expectedValue";
            _rowService.Add(_row, key, expectedValue);
            var result = _rowService.Get(_row, EqualityComparer<int>.Default, key);

            Assert.That(result, Is.EqualTo(expectedValue));
        }

        [Test]
        public void ShouldBeAbleToRetrieveTheValueUsingTheKeyWhenThereIsMoreThanOneValueInserted()
        {
            var key = 41;
            var expectedValue = "anotherValue";
            _rowService.Add(_row, 7, "abcdf");
            _rowService.Add(_row, 410, "cuatrocientos diez");
            _rowService.Add(_row, 8, "eight");
            _rowService.Add(_row, key, expectedValue);
            var result = _rowService.Get(_row, EqualityComparer<int>.Default, key);

            Assert.That(result, Is.EqualTo(expectedValue));
        }

        [Test]
        public void ShouldThrowAnExceptionIfTheKeyDoesNotExist()
        {
            var nonExistentKey = 99;
            _rowService.Add(_row, 00, "abcdf");
            string result;
            Assert.That(() => result = _rowService.Get(_row, EqualityComparer<int>.Default, nonExistentKey), Throws.TypeOf<KeyNotFoundException>());
        }
    }
}
