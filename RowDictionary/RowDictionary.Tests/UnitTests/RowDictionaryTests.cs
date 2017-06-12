using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using RowDictionary.Models;
using RowDictionary.Services;

namespace RowDictionary.Tests.UnitTests
{
    [TestFixture]
    public class RowDictionaryTests
    {
        [Test]
        public void WhenGettingAValueAndTheKeyExistsShould()
        {
            //Arrange
            var key = 01;
            var expectedValue = "expectedValue";
            var comparer = Comparer<int>.Default;
            var mockEqualityServiceProvider = MockRepository.GenerateMock<IEqualityServiceProvider<int>>();
            mockEqualityServiceProvider.Stub(x => x.GetKeyComparer(comparer)).Return(comparer);
            var sut = new RowDictionary<int, string>(comparer, mockEqualityServiceProvider);
            sut.Add(key, expectedValue);
            string resultValue;

            //Act
            resultValue = sut[key];

            //Assert
            Assert.That(resultValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void WhenInstantiatingANewDictionaryShouldCallGetComparer()
        {
            //Arrange
            var comparer = Comparer<int>.Default;
            var mockEqualityServiceProvider = MockRepository.GenerateMock<IEqualityServiceProvider<int>>();

            //Act
            var sut = new RowDictionary<int, string>(comparer, mockEqualityServiceProvider);

            //Assert
            mockEqualityServiceProvider.AssertWasCalled(x => x.GetKeyComparer(comparer));
        }

        [Test]
        public void WhenTryingToGetAValueAndTheKeyDoesNotExistShould()
        {
            //Arrange
            var key = "key";
            var thisKeyDoesNotExist = "thisKeyDoesNotExist";
            var expectedValue = "expectedValue";
            var comparer = (IComparer<string>) StringComparer.InvariantCultureIgnoreCase;
            var mockEqualityService = MockRepository.GenerateMock<IComparer<Cell<string, string>>>();
            var mockEqualityServiceProvider = MockRepository.GenerateMock<IEqualityServiceProvider<string>>();
            mockEqualityServiceProvider.Stub(x => x.GetKeyComparer(comparer)).Return(comparer);
            mockEqualityService
                .Stub(s => s.Compare(
                    Arg<Cell<string, string>>.Matches(x => x.Key == key), 
                    Arg<Cell<string, string>>.Matches(x => x.Key == thisKeyDoesNotExist)))
                .Return(-1);

            var sut = new RowDictionary<string, string>(comparer, mockEqualityServiceProvider);
            sut.Add(key, expectedValue);
            string resultValue;

            //Act
            var resultBooleanValue = sut.TryGetValue(thisKeyDoesNotExist, out resultValue);

            //Assert
            Assert.That(resultBooleanValue, Is.False);
        }

        [Test]
        public void WhenTryingToGetAValueAndTheKeyExistsShould()
        {
            //Arrange
            var key = 01;
            var expectedValue = "expectedValue";
            var comparer = Comparer<int>.Default;
            var mockEqualityService = MockRepository.GenerateMock<IComparer<Cell<int, string>>>();
            var mockEqualityServiceProvider = MockRepository.GenerateMock<IEqualityServiceProvider<int>>();
            mockEqualityServiceProvider.Stub(x => x.GetKeyComparer(comparer)).Return(comparer);
            mockEqualityService
                .Stub(s => s.Compare(
                    Arg<Cell<int, string>>.Matches(x => x.Key == key), 
                    Arg<Cell<int, string>>.Matches(x => x.Key == key)))
                    .Return(0);
            var sut = new RowDictionary<int, string>(comparer, mockEqualityServiceProvider);
            sut.Add(key, expectedValue);
            string resultValue;

            //Act
            var resultBooleanValue = sut.TryGetValue(key, out resultValue);

            //Assert
            Assert.That(resultBooleanValue, Is.True);
            Assert.That(resultValue, Is.EqualTo(expectedValue));
        }
    }
}