﻿using System.Collections.Generic;
using NUnit.Framework;
using RowDictionary.Services;

namespace RowDictionary.Tests.UnitTests.Services
{
    [TestFixture]
    public class WhenTryingToGetAValueFromARowTests
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
        public void ShouldSetTheValueIfTheKeyExists()
        {
            var key = 55;
            var expectedValue = "expectedValue";
            _rowService.Add(_row, key, expectedValue);
            string resultValue;
            _rowService.TryGetValue(_row, EqualityComparer<int>.Default, key, out resultValue);

            Assert.That(resultValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void ShouldReturnTrueIfTheKeyExists()
        {
            var key = 55;
            var expectedValue = "expectedValue";
            _rowService.Add(_row, key, expectedValue);
            string resultValue;
            var resultBooleanValue = _rowService.TryGetValue(_row, EqualityComparer<int>.Default, key, out resultValue);

            Assert.That(resultBooleanValue, Is.EqualTo(true));
        }

        [Test]
        public void ShouldSetTheDefaultValueIfTheKeyDoesNotExists()
        {
            var nonExistentKey = 99;
            _rowService.Add(_row, 00, "abcdf");
            string resultValue = "previosValue";
            _rowService.TryGetValue(_row, EqualityComparer<int>.Default, nonExistentKey, out resultValue);

            Assert.That(resultValue, Is.EqualTo(null));
        }

        [Test]
        public void ShouldReturnFalseWhenTheKeyDoesNotExist()
        {
            var nonExistentKey = 99;
            _rowService.Add(_row, 00, "abcdf");
            string resultValue;
            var resultBooleanValue = _rowService.TryGetValue(_row, EqualityComparer<int>.Default, nonExistentKey, out resultValue);

            Assert.That(resultBooleanValue, Is.EqualTo(false));
        }
    }
}
