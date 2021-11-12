namespace Xunit.Assertation.Extensions.Test
{
    public class AssertThatBooleanTest
    {
        [Fact]
        public void IsTrue_WhenItemIsTrue_DoesNotThrowException()
        {
            // Arrange
            var assert = new AssertThatBoolean(true);

            // Act && Assert
            Assert.ThatCode(() => assert.IsTrue()).DoesNotThrowException();
        }

        [Fact]
        public void IsFalse_WhenItemIsFalse_DoesNotThrowException()
        {
            // Arrange
            var assert = new AssertThatBoolean(false);

            // Act && Assert
            Assert.ThatCode(() => assert.IsFalse()).DoesNotThrowException();
        }

        [Fact]
        public void IsTrue_WhenItemIsFalse_ThrowsException()
        {
            // Arrange
            var assert = new AssertThatBoolean(false);

            // Act && Assert
            Assert.ThatCode(() => assert.IsTrue()).Throws();
        }

        [Fact]
        public void IsFalse_WhenItemIsTrue_ThrowsException()
        {
            // Arrange
            var assert = new AssertThatBoolean(true);

            // Act && Assert
            Assert.ThatCode(() => assert.IsFalse()).Throws();
        }
    }
}
