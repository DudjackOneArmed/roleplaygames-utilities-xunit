namespace Xunit.Assertation.Extensions.Test
{
    public class AssertThatBooleanExtensionsTest
    {
        [Fact]
        public void IsTrue_WhenItemIsTrue_DoesNotThrowException()
        {
            // Arrange && Act && Assert
            Assert.ThatCode(() => Assert.That(true).IsTrue()).DoesNotThrow();
        }

        [Fact]
        public void IsFalse_WhenItemIsFalse_DoesNotThrowException()
        {
            // Arrange && Act && Assert
            Assert.ThatCode(() => Assert.That(false).IsFalse()).DoesNotThrow();
        }

        [Fact]
        public void IsTrue_WhenItemIsFalse_ThrowsException()
        {
            // Arrange && Act && Assert
            Assert.ThatCode(() => Assert.That(false).IsTrue()).Throws();
        }

        [Fact]
        public void IsFalse_WhenItemIsTrue_ThrowsException()
        {
            // Arrange && Act && Assert
            Assert.ThatCode(() => Assert.That(true).IsFalse()).Throws();
        }
    }
}
