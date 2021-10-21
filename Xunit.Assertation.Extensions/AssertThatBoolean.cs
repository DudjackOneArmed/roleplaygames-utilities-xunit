namespace Xunit.Assertation.Extensions
{
    public static class AssertThatBooleanExtensions
    {
        /// <summary>
        /// Assert that item is true
        /// </summary>
        public static AssertThat<bool> IsTrue(this AssertThat<bool> assertThat)
        {
            Assert.True(assertThat.Item);
            return assertThat;
        }

        /// <summary>
        /// Assert that item is false
        /// </summary>
        public static AssertThat<bool> IsFalse(this AssertThat<bool> assertThat)
        {
            Assert.False(assertThat.Item);
            return assertThat;
        }
    }
}
