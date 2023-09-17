using System;
using System.Collections.Generic;
using System.Linq;
using Xunit.Assertation.Extensions.Exceptions;

namespace Xunit.Assertation.Extensions
{
    /// <summary>
    /// Contains methods to verify IEnumerable objects
    /// </summary>
    public class AssertThatIEnumerable<U, T> : AssertThat<U> where U : IEnumerable<T>
    {
        public AssertThatIEnumerable(U item) : base(item)
        {
        }

        /// <summary>
        /// Verifies that collection contains item
        /// </summary>
        /// <param name="item">The item to find in collection</param>
        public AssertThatIEnumerable<U, T> Contains(T item)
        {
            Assert.Contains(item, Item);
            return this;
        }

        /// <summary>
        /// Verifies that collection contains items
        /// </summary>
        /// <param name="items">The items to find in collection</param>
        public AssertThatIEnumerable<U, T> Contains(params T[] items)
        {
            var errorElements = new List<T>();

            foreach(var item in items)
            {
                if (!Item.Contains(item))
                    errorElements.Add(item);
            }

            if (errorElements.Any())
                throw new CollectionDoesNotContainElementsExceptions<T>(errorElements);

            return this;
        }

        /// <summary>
        /// Verifies that collection contains items
        /// </summary>
        /// <param name="items">The items to find in collection</param>
        public AssertThatIEnumerable<U, T> Contains(IEnumerable<T> items)
        {
            var errorElements = new List<T>();

            foreach(var item in items)
            {
                if (!Item.Contains(item))
                    errorElements.Add(item);
            }

            if (errorElements.Any())
                throw new CollectionDoesNotContainElementsExceptions<T>(errorElements);

            return this;
        }

        /// <summary>
        /// Verifies that collection does not contain item
        /// </summary>
        /// <param name="item">The item to find in collection</param>
        public AssertThatIEnumerable<U, T> DoesNotContain(T item)
        {
            Assert.DoesNotContain(item, Item);
            return this;
        }

        /// <summary>
        /// Verifies that collection does not contain items
        /// </summary>
        /// <param name="item">The items to find in collection</param>
        public AssertThatIEnumerable<U, T> DoesNotContain(params T[] items)
        {
            var errorElements = new List<T>();

            foreach (var item in items)
            {
                if (Item.Contains(item))
                    errorElements.Add(item);
            }

            if (errorElements.Any())
                throw new CollectionContainsElementsExceptions<T>(errorElements);

            return this;
        }

        /// <summary>
        /// Verifies that collection does not contain items
        /// </summary>
        /// <param name="item">The items to find in collection</param>
        public AssertThatIEnumerable<U, T> DoesNotContain(IEnumerable<T> items)
        {
            var errorElements = new List<T>();

            foreach (var item in items)
            {
                if (Item.Contains(item))
                    errorElements.Add(item);
            }

            if (errorElements.Any())
                throw new CollectionContainsElementsExceptions<T>(errorElements);

            return this;
        }

        /// <summary>
        /// Verifies that collection contains exactly given number of elements, which meet the creteria  provided by the element inspectors
        /// </summary>
        /// <param name="elementInspectors">The element inspectors, which inspect each element in turn. The total number of element inpectors must exactly macth the number of elements in collection</param>
        public AssertThatIEnumerable<U, T> Collection(params Action<T>[] elementInspectors)
        {
            Assert.Collection(Item, elementInspectors);
            return this;
        }

        /// <summary>
        /// Verifies that collection contains given count of elements
        /// </summary>
        /// <param name="count">Count of elements</param>
        public AssertThatIEnumerable<U, T> HasCount(int count)
        {
            Assert.Equal(count, Item.Count());
            return this;
        }

        /// <summary>
        /// Verifies that collection is empty
        /// </summary>
        public AssertThatIEnumerable<U, T> IsEmpty()
        {
            Assert.Empty(Item);
            return this;
        }

        /// <summary>
        /// Verifies that collection is not empty
        /// </summary>
        public AssertThatIEnumerable<U, T> IsNotEmpty()
        {
            Assert.NotEmpty(Item);
            return this;
        }

        /// <summary>
        /// Verifies that collection contains only a single element
        /// </summary>
        public AssertThatIEnumerable<U, T> Single()
        {
            Assert.Single(Item);
            return this;
        }

        /// <summary>
        /// Verifies that collection contains only a single element
        /// </summary>
        /// <param name="item">The value to find in collection</param>
        public AssertThatIEnumerable<U, T> Single(T item)
        {
            Assert.Single(Item, item);
            return this;
        }

        /// <summary>
        /// Verifies that collection contains only a single element matching the predicate
        /// </summary>
        /// <param name="predicate">The item matching predicate</param>
        public AssertThatIEnumerable<U, T> Single(Predicate<T> predicate)
        {
            Assert.Single(Item, predicate);
            return this;
        }

        /// <summary>
        /// Verifies that collection contains items only single
        /// </summary>
        /// <param name="items">Items to find in collection</param>
        public AssertThatIEnumerable<U, T> Single(params T[] items)
        {
            var errorElements = new List<T>();

            foreach (var item in items)
            {
                var countItems = Item.Count(x => x.Equals(item));

                if (countItems != 1)
                    errorElements.Add(item);
            }

            if (errorElements.Any())
                throw new CollectionContainsNotSingleElementsException<T>(errorElements);

            return this;
        }

        /// <summary>
        /// Verifies that collection contains items only single
        /// </summary>
        /// <param name="items">Items to find in collection</param>
        public AssertThatIEnumerable<U, T> Single(IEnumerable<T> items)
        {
            var errorElements = new List<T>();

            foreach (var item in items)
            {
                var countItems = Item.Count(x => x.Equals(item));

                if (countItems != 1)
                    errorElements.Add(item);
            }

            if (errorElements.Any())
                throw new CollectionContainsNotSingleElementsException<T>(errorElements);

            return this;
        }

        /// <summary>
        /// Verifies that all collection elements matching the predicate
        /// </summary>
        /// <param name="predicate">The item matching predicate</param>
        public AssertThatIEnumerable<U, T> All(Predicate<T> predicate)
        {
            var result = Item.All(x => predicate(x));

            if (!result)
                throw new NotAllElementsMatchPredicateException();

            return this;
        }

        /// <summary>
        /// Verifies that any collection element matching the predicate
        /// </summary>
        /// <param name="predicate">The item matching predicate</param>
        public AssertThatIEnumerable<U, T> Any(Predicate<T> predicate)
        {
            var result = Item.Any(x => predicate(x));

            if (!result)
                throw new NeitherElementMatchesPredicateException();

            return this;
        }

        /// <summary>
        /// Tries to do action for each element and collect all exceptions to one
        /// </summary>
        /// <param name="action">Action for each item</param>
        public AssertThatIEnumerable<U, T> ForEach(Action<T> action)
        {
            var exceptions = new List<Exception>();

            foreach (var item in Item)
            {
                try
                {
                    action.Invoke(item);
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }

            if (exceptions.Any())
                throw new AssertForEachException(exceptions);
            else 
                return this;
        }

        /// <summary>
        /// Tries to do action for each element and collect all exceptions to one
        /// </summary>
        /// <param name="action">Action for each item</param>
        public AssertThatIEnumerable<U, T> AssertForEach(Action<AssertThat<T>> action)
        {
            var exceptions = new List<Exception>();

            foreach (var item in Item)
            {
                try
                {
                    action.Invoke(new AssertThat<T>(item));
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }

            return exceptions.Any() ? throw new AssertForEachException(exceptions) : this;
        }

        /// <summary>
        /// Checks if collection ordered ascending by parameter
        /// </summary>
        /// <param name="getParameter">How to get parameter from element</param>
        public AssertThatIEnumerable<U, T> OrderedBy<TParam>(Func<T, TParam> getParameter) where TParam : IComparable
        {
            var collection = Item.ToList();

            if (collection.Count > 1)
            {
                for (var i = 1; i < collection.Count; i++)
                {
                    var previousParameter = getParameter(collection[i - 1]);
                    var currentParameter = getParameter(collection[i]);

                    if (previousParameter.CompareTo(currentParameter) > 0)
                        throw new NotOrderedByParameterException(currentParameter, i, previousParameter, i - 1);
                }
            }

            return this;
        }

        /// <summary>
        /// Checks if collection ordered descending by parameter
        /// </summary>
        /// <param name="getParameter">How to get parameter from element</param>
        public AssertThatIEnumerable<U, T> OrderedByDescending<TParam>(Func<T, TParam> getParameter) where TParam : IComparable
        {
            var collection = Item.ToList();

            if (collection.Count > 1)
            {
                for (var i = 1; i < collection.Count; i++)
                {
                    var previousParameter = getParameter(collection[i - 1]);
                    var currentParameter = getParameter(collection[i]);

                    if (previousParameter.CompareTo(currentParameter) < 0)
                        throw new NotOrderedByParameterException(previousParameter, i, currentParameter, i - 1);
                }
            }

            return this;
        }
    }
}
