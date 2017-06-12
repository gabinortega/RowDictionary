using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using RowDictionary.Models;
using RowDictionary.Services;

namespace RowDictionary.Tests.UnitTests.Services
{
    [TestFixture]
    public class CellComparerTests
    {
        [Test]
        public void ShouldReturnTheSameResultThatKeyComparerReturn()
        {
            //Arrange
            var key01 = 1;
            var key02 = 2;
            var cell01 = new Cell<int, string>(key01);
            var cell02 = new Cell<int, string>(key02);
            var keyComparerResult = 99;
            var mockEqualityServiceProvider = MockRepository.GenerateMock<IComparer<int>>();
            mockEqualityServiceProvider.Stub(x => x.Compare(key01, key02)).Return(keyComparerResult);
            var sut = new CellComparer<int, string>(mockEqualityServiceProvider);


            //Act
            var result = sut.Compare(cell01, cell02);

            //Assert
            Assert.That(result, Is.EqualTo(keyComparerResult));
        }

        [Test]
        public void ShouldReturnMinusOneWhenKey1IsNull()
        {
            //Arrange
            string key01 = null;
            var key02 = "key02";
            var expectedResult = -1;
            var cell01 = new Cell<string, string>(key01);
            var cell02 = new Cell<string, string>(key02);
            var mockEqualityServiceProvider = MockRepository.GenerateMock<IComparer<string>>();
            var sut = new CellComparer<string, string>(mockEqualityServiceProvider);

            //Act
            var result = sut.Compare(cell01, cell02);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }


        [Test]
        public void ShouldReturnMinusOneWhenCell1IsNull()
        {
            //Arrange
            string key01 = null;
            var key02 = "key02";
            var expectedResult = -1;
            Cell<string, string> cell01 = null;
            var cell02 = new Cell<string, string>(key02);
            var mockEqualityServiceProvider = MockRepository.GenerateMock<IComparer<string>>();
            var sut = new CellComparer<string, string>(mockEqualityServiceProvider);

            //Act
            var result = sut.Compare(cell01, cell02);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void ShouldReturnOneWhenKey2IsNull()
        {
            //Arrange
            var key01 = "key01";
            string key02 = null;
            var expectedResult = 1;
            var cell01 = new Cell<string, string>(key01);
            var cell02 = new Cell<string, string>(key02);
            var mockEqualityServiceProvider = MockRepository.GenerateMock<IComparer<string>>();
            var sut = new CellComparer<string, string>(mockEqualityServiceProvider);

            //Act
            var result = sut.Compare(cell01, cell02);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void ShouldReturnOneWhenCell2IsNull()
        {
            //Arrange
            var key01 = "key01";
            string key02 = null;
            var expectedResult = 1;
            var cell01 = new Cell<string, string>(key01);
            Cell<string, string> cell02 = null;
            var mockEqualityServiceProvider = MockRepository.GenerateMock<IComparer<string>>();
            var sut = new CellComparer<string, string>(mockEqualityServiceProvider);

            //Act
            var result = sut.Compare(cell01, cell02);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
