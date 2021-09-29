using XunitAssert = Xunit.Assert;

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
            XunitAssert.Equal(item, Item);
            return this;
        }

        public AssertThat<T> IsEqualTo(object item)
        {
            XunitAssert.Equal(item, Item);
            return this;
        }

        public AssertThat<T> IsNull()
        {
            XunitAssert.Null(Item);
            return this;
        }

        public AssertThat<T> IsNotNull()
        {
            XunitAssert.NotNull(Item);
            return this;
        }

        public AssertThat<T> IsSame(T item)
        {
            XunitAssert.Same(item, Item);
            return this;
        }
    }

}