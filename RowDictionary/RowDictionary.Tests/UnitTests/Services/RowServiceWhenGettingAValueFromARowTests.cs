using System.Collections.Generic;
using NUnit.Framework;
using RowDictionary.Services;

namespace RowDictionary.Tests.UnitTests.Services
{
    [TestFixture]
    public class RowServiceWhenGettingAValueFromARowTests
    {
        private List<KeyValuePair<int, string>> _row;
        private IRowService<int, string> _sut;

        [SetUp]
        public void BeforeEachTest()
        {
            _row = new List<KeyValuePair<int, string>>();
            _sut = new RowService<int, string>();
        }

        [Test]
        public void ShouldBeAbleToRetrieveTheValueUsingTheKeyWhenThereIsOnlyOneValueInserted()
        {
            var key = 55;
            var expectedValue = "expectedValue";
            _sut.Add(_row, key, expectedValue);
            var result = _sut.Get(_row, EqualityComparer<int>.Default, key);

            Assert.That(result, Is.EqualTo(expectedValue));
        }

        [Test]
        public void ShouldBeAbleToRetrieveTheValueUsingTheKeyWhenThereIsMoreThanOneValueInserted()
        {
            var key = 41;
            var expectedValue = "anotherValue";
            _sut.Add(_row, 7, "abcdf");
            _sut.Add(_row, 410, "cuatrocientos diez");
            _sut.Add(_row, 8, "eight");
            _sut.Add(_row, key, expectedValue);
            var result = _sut.Get(_row, EqualityComparer<int>.Default, key);

            Assert.That(result, Is.EqualTo(expectedValue));
        }

        [Test]
        public void ShouldThrowAnExceptionIfTheKeyDoesNotExist()
        {
            var nonExistentKey = 99;
            _sut.Add(_row, 00, "abcdf");
            string result;
            Assert.That(() => result = _sut.Get(_row, EqualityComparer<int>.Default, nonExistentKey), Throws.TypeOf<KeyNotFoundException>());
        }
    }
}
