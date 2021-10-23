namespace Xunit.Assertation.Extensions
{
    public class AssertThatBoolean : AssertThat<bool>
    {
        public AssertThatBoolean(bool item) : base(item)
        {

        }

        /// <summary>
        /// Assert that item is true
        /// </summary>
        public AssertThat<bool> IsTrue()
        {
            Assert.True(Item);
            return this;
        }

        /// <summary>
        /// Assert that item is false
        /// </summary>
        public AssertThat<bool> IsFalse()
        {
            Assert.False(Item);
            return this;
        }
    }
}
