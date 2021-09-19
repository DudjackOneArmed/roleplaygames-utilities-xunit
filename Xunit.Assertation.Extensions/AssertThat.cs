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

        public void IsEqualTo(T item)
        {
            XunitAssert.Equal(item, Item);
        }

        public void IsEqualTo(object item)
        {
            XunitAssert.Equal(item, Item);
        }

        public void IsNull()
        {
            XunitAssert.Null(Item);
        }

        public void IsNotNull()
        {
            XunitAssert.NotNull(Item);
        }

        public void IsSame(T item) => XunitAssert.Same(item, Item);
    }
}
