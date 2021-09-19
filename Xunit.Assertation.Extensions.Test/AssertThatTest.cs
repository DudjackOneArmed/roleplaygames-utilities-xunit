namespace Xunit.Assertation.Extensions.Test
{
    public class AssertThatTest
    {
        [Theory]
        [InlineData(12, 12)]
        public void IsEqualTo_IntegerItemEqualExpected_DoesNotThrowException(int actual, int expected)
        {
            // Arrange
            var assertation = new AssertThat<int>(actual);

            // Act
            var exception = Record.Exception(() => assertation.IsEqualTo(expected));

            // Assert
            Xunit.Assert.Null(exception);
        }

        [Theory]
        [InlineData(12, 13)]
        public void IsEqualTo_IntegerItemNotEqualExpected_ThrowsException(int actual, int expected)
        {
            // Arrange
            var assertation = new AssertThat<int>(actual);

            // Act
            var exception = Record.Exception(() => assertation.IsEqualTo(expected));

            // Assert
            Xunit.Assert.NotNull(exception);
        }

        [Theory]
        [InlineData(12.01, 12.01)]
        public void IsEqualTo_DoubleItemEqualExpected_DoesNotThrowException(double actual, double expected)
        {
            // Arrange
            var assertation = new AssertThat<double>(actual);

            // Act
            var exception = Record.Exception(() => assertation.IsEqualTo(expected));

            // Assert
            Xunit.Assert.Null(exception);
        }

        [Theory]
        [InlineData(12.01, 12.02)]
        public void IsEqualTo_DoubleItemNotEqualExpected_ThrowsException(double actual, double expected)
        {
            // Arrange
            var assertation = new AssertThat<double>(actual);

            // Act
            var exception = Record.Exception(() => assertation.IsEqualTo(expected));

            // Assert
            Xunit.Assert.NotNull(exception);
        }

        [Fact]
        public void IsNotNull_ItemIsNull_ThrowsException()
        {
            // Arrange
            var assertation = new AssertThat<object>(null);

            // Act
            var exception = Record.Exception(() => assertation.IsNotNull());

            // Assert
            Xunit.Assert.NotNull(exception);
        }

        [Fact]
        public void IsNotNull_ItemIsNotNull_DiesNotThrowException()
        {
            // Arrange
            var assertation = new AssertThat<object>(new());

            // Act
            var exception = Record.Exception(() => assertation.IsNotNull());

            // Assert
            Xunit.Assert.Null(exception);
        }
    }
}
