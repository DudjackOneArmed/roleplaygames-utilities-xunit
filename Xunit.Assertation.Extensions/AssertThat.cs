namespace Xunit.Assertation.Extensions
{
    public class AssertThat<T>
    {
        public T Item { get; }

        public AssertThat(T item)
        {
            Item = item;
        }

        public AssertThat<T> IsEqualTo(T item)
        {
            Assert.Equal(item, Item);
            return this;
        }

        public AssertThat<T> IsEqualTo(object item)
        {
            Assert.Equal(item, Item);
            return this;
        }

        public AssertThat<T> IsNull()
        {
            Assert.Null(Item);
            return this;
        }

        public AssertThat<T> IsNotNull()
        {
            Assert.NotNull(Item);
            return this;
        }

        public AssertThat<T> IsSame(T item)
        {
            Assert.Same(item, Item);
            return this;
        }

        /// <summary>
        /// Verifies that item is exactly the given type (and not derived)
        /// </summary>
        /// <typeparam name="U">Checking type</typeparam>
        public AssertThat<T> IsType<U>()
        {
            Assert.IsType<U>(Item);
            return this;
        }


        /// <summary>
        /// Verifies that item is exactly not the given type
        /// </summary>
        /// <typeparam name="U">Checking type</typeparam>
        public AssertThat<T> IsNotType<U>()
        {
            Assert.IsNotType<U>(Item);
            return this;
        }
    }
}