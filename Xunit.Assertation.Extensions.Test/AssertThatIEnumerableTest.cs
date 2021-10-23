using System;
using System.Collections.Generic;
using System.Linq;
using Xunit.Assertation.Extensions.Exceptions;

namespace Xunit.Assertation.Extensions.Test
{
    public class AssertThatIEnumerableTest
    {
        public static object[] CollectionData => new object[]
        {
            new object[] { new List<int> { 1, 2, 3 } }
        };

        [Theory]
        [MemberData(nameof(CollectionData))]
        public void Contains_WhenCollectionContainsItem_DoesNotThrowException(ICollection<int> collection)
        {
            // Arrange
            var assert = new AssertThatIEnumerable<ICollection<int>, int>(collection);

            // Act && Assert
            Assert.ThatCode(() => assert.Contains(collection.First())).DoesNotThrowException();
        }

        [Theory]
        [MemberData(nameof(CollectionData))]
        public void Contains_WhenCollectionDoesNotContainItem_ThrowsException(ICollection<int> collection)
        {
            // Arrange
            var assert = new AssertThatIEnumerable<ICollection<int>, int>(collection);

            // Act && Assert
            Assert.ThatCode(() => assert.Contains(0)).Throws();
        }

        [Theory]
        [MemberData(nameof(CollectionData))]
        public void DoesNotContain_WhenCollectionDoesNotContainItem_DoesNotThrowException(ICollection<int> collection)
        {
            // Arrange
            var assert = new AssertThatIEnumerable<ICollection<int>, int>(collection);

            // Act && Assert
            Assert.ThatCode(() => assert.DoesNotContain(0)).DoesNotThrowException();
        }

        [Theory]
        [MemberData(nameof(CollectionData))]
        public void DoesNotContain_WhenCollectionContainsItem_ThrowsException(ICollection<int> collection)
        {
            // Arrange
            var assert = new AssertThatIEnumerable<ICollection<int>, int>(collection);

            // Act && Assert
            Assert.ThatCode(() => assert.DoesNotContain(collection.First())).Throws();
        }

        [Theory]
        [MemberData(nameof(CollectionData))]
        public void HasCount_WhenCheckCollectionCount_DoesNotThrowException(ICollection<int> collection)
        {
            // Arrange
            var assert = new AssertThatIEnumerable<ICollection<int>, int>(collection);

            // Act && Assert
            Assert.ThatCode(() => assert.HasCount(collection.Count)).DoesNotThrowException();
        }

        [Theory]
        [MemberData(nameof(CollectionData))]
        public void HasCount_WhenCheckNotCollectionCount_ThrowsException(ICollection<int> collection)
        {
            // Arrange
            var assert = new AssertThatIEnumerable<ICollection<int>, int>(collection);

            // Act && Assert
            Assert.ThatCode(() => assert.HasCount(0)).Throws();
        }
        public static object[] EmptyCollection_Data => new object[]
        {
            new object[] { new List<int>() }
        };

        [Theory]
        [MemberData(nameof(EmptyCollection_Data))]
        public void IsEmpty_WhenCollectionIsEmpty_DoesNotThrowException(ICollection<int> collection)
        {
            // Arrange
            var assert = new AssertThatIEnumerable<ICollection<int>, int>(collection);

            // Act && Assert
            Assert.ThatCode(() => assert.IsEmpty()).DoesNotThrowException();
        }

        [Theory]
        [MemberData(nameof(CollectionData))]
        public void IsEmpty_WhenCollectionIsNotEmpty_ThrowsException(ICollection<int> collection)
        {
            // Arrange
            var assert = new AssertThatIEnumerable<ICollection<int>, int>(collection);

            // Act && Assert
            Assert.ThatCode(() => assert.IsEmpty()).Throws();
        }

        [Theory]
        [MemberData(nameof(CollectionData))]
        public void IsNotEmpty_WhenCollectionIsNotEmpty_DoesNotThrowException(ICollection<int> collection)
        {
            // Arrange
            var assert = new AssertThatIEnumerable<ICollection<int>, int>(collection);

            // Act && Assert
            Assert.ThatCode(() => assert.IsNotEmpty()).DoesNotThrowException();
        }

        [Theory]
        [MemberData(nameof(EmptyCollection_Data))]
        public void IsNotEmpty_WhenCollectionIsEmpty_ThrowsException(ICollection<int> collection)
        {
            // Arrange
            var assert = new AssertThatIEnumerable<ICollection<int>, int>(collection);

            // Act && Assert
            Assert.ThatCode(() => assert.IsNotEmpty()).Throws();
        }
        public static object[] SingleCollection_Data => new object[]
        {
            new object[] { new List<int>() { 1 } }
        };

        [Theory]
        [MemberData(nameof(SingleCollection_Data))]
        public void Single_WhenCollectionHasOneElement_DoesNotThrowException(ICollection<int> collection)
        {
            // Arrange
            var assert = new AssertThatIEnumerable<ICollection<int>, int>(collection);

            // Act && Assert
            Assert.ThatCode(() => assert.Single()).DoesNotThrowException();
        }

        [Theory]
        [MemberData(nameof(CollectionData))]
        public void Single_WhenCollectionHasSeveralElements_ThrowsException(ICollection<int> collection)
        {
            // Arrange
            var assert = new AssertThatIEnumerable<ICollection<int>, int>(collection);

            // Act && Assert
            Assert.ThatCode(() => assert.Single()).Throws();
        }

        [Theory]
        [MemberData(nameof(SingleCollection_Data))]
        public void Single_WhenCollectionHasOneElementWichIsLookingFor_DoesNotThrowException(ICollection<int> collection)
        {
            // Arrange
            var assert = new AssertThatIEnumerable<ICollection<int>, int>(collection);

            // Act && Assert
            Assert.ThatCode(() => assert.Single(collection.First())).DoesNotThrowException();
        }

        [Theory]
        [MemberData(nameof(SingleCollection_Data))]
        public void Single_WhenCollectionHasOneElementAndSearcchingOther_ThrowsException(ICollection<int> collection)
        {
            // Arrange
            var assert = new AssertThatIEnumerable<ICollection<int>, int>(collection);

            // Act && Assert
            Assert.ThatCode(() => assert.Single(0)).Throws();
        }

        [Theory]
        [MemberData(nameof(SingleCollection_Data))]
        [MemberData(nameof(CollectionData))]
        public void Single_WhenPredicateIsTruthy_DoesNotThrowException(ICollection<int> collection)
        {
            // Arrange
            var assert = new AssertThatIEnumerable<ICollection<int>, int>(collection);

            // Act && Assert
            Assert.ThatCode(() => assert.Single(x => x == collection.First())).DoesNotThrowException();
        }

        [Theory]
        [MemberData(nameof(SingleCollection_Data))]
        [MemberData(nameof(CollectionData))]
        public void Single_WhenPredicateIsFalsy_ThrowsException(ICollection<int> collection)
        {
            // Arrange
            var assert = new AssertThatIEnumerable<ICollection<int>, int>(collection);

            // Act && Assert
            Assert.ThatCode(() => assert.Single(x => x == int.MinValue)).Throws();
        }

        [Theory]
        [MemberData(nameof(CollectionData))]
        public void All_WhenPredicateIsTruthy_DoesNotThrowException(ICollection<int> collection)
        {
            // Arrange
            var assert = new AssertThatIEnumerable<ICollection<int>, int>(collection);

            // Act && Assert
            Assert.ThatCode(() => assert.All(x => x is int)).DoesNotThrowException();
        }

        [Theory]
        [MemberData(nameof(CollectionData))]
        public void All_WhenPredicateIsFalsy_ThrowsException(ICollection<int> collection)
        {
            // Arrange
            var assert = new AssertThatIEnumerable<ICollection<int>, int>(collection);

            // Act && Assert
            Assert.ThatCode(() => assert.All(x => x is double)).Throws<NotAllElementsMatchPredicateException>();
        }

        [Theory]
        [MemberData(nameof(CollectionData))]
        public void Any_WhenPredicateIsTruthy_DoesNotThrowException(ICollection<int> collection)
        {
            // Arrange
            var assert = new AssertThatIEnumerable<ICollection<int>, int>(collection);

            // Act && Assert
            Assert.ThatCode(() => assert.Any(x => x == collection.Last())).DoesNotThrowException();
        }

        [Theory]
        [MemberData(nameof(CollectionData))]
        public void Any_WhenPredicateIsFalsy_ThrowsException(ICollection<int> collection)
        {
            // Arrange
            var assert = new AssertThatIEnumerable<ICollection<int>, int>(collection);

            // Act && Assert
            Assert.ThatCode(() => assert.Any(x => x is double)).Throws<NeitherElementMatchesPredicateException>();
        }

        [Theory]
        [MemberData(nameof(SingleCollection_Data))]
        [MemberData(nameof(CollectionData))]
        public void Collection_WhenPredicateIsTruthy_DoesNotThrowException(ICollection<int> collection)
        {
            // Arrange
            var assert = new AssertThatIEnumerable<ICollection<int>, int>(collection);
            var inspectors = new System.Action<int>[collection.Count];

            for (int i = 0; i < inspectors.Length; i++)
                inspectors[i] = x => { };

            // Act && Assert
            Assert.ThatCode(() => assert.Collection(inspectors)).DoesNotThrowException();
        }

        [Theory]
        [MemberData(nameof(CollectionData))]
        public void Collection_WhenPredicateIsFalsy_ThrowsException(ICollection<int> collection)
        {
            // Arrange
            var assert = new AssertThatIEnumerable<ICollection<int>, int>(collection);
            var inspectors = new System.Action<int>[collection.Count + 1];

            for (int i = 0; i < inspectors.Length; i++)
                inspectors[i] = x => { };

            // Act && Assert
            Assert.ThatCode(() => assert.Collection(inspectors)).Throws();
        }

        [Theory]
        [MemberData(nameof(CollectionData))]
        public void ForEach_AllActionsAreDoneSuccessfully_DoesNotThrowException(ICollection<int> collection)
        {
            // Arrange
            var assert = new AssertThatIEnumerable<ICollection<int>, int>(collection);

            // Act && Assert
            Assert.ThatCode(() => assert.ForEach(x => { })).DoesNotThrowException();
        }

        [Theory]
        [MemberData(nameof(CollectionData))]
        public void ForEach_OneActionThrowsException_ThrowsAssertForEachException(ICollection<int> collection)
        {
            // Arrange
            var assert = new AssertThatIEnumerable<ICollection<int>, int>(collection);
            
            void action(int x)
            {
                if (x == collection.Last())
                    throw new Exception();
            }

            // Act && Assert
            Assert.ThatCode(() => assert.ForEach(action)).Throws<AssertForEachException>();
        }

        [Theory]
        [MemberData(nameof(CollectionData))]
        public void AssertForEach_AllAssertationsAreDoneSuccessfully_DoesNotThrowException(ICollection<int> collection)
        {
            // Arrange
            var assert = new AssertThatIEnumerable<ICollection<int>, int>(collection);

            // Act && Assert
            Assert.ThatCode(() => assert.AssertForEach(x => { })).DoesNotThrowException();
        }

        [Theory]
        [MemberData(nameof(CollectionData))]
        public void AssertForEach_OneAssertationThrowsException_ThrowsAssertForEachException(ICollection<int> collection)
        {
            // Arrange
            var assert = new AssertThatIEnumerable<ICollection<int>, int>(collection);

            void action(AssertThat<int> x)
            {
                if (x.Item == collection.Last())
                    throw new Exception();
            }

            // Act && Assert
            Assert.ThatCode(() => assert.AssertForEach(action)).Throws<AssertForEachException>();
        }
    }
}
