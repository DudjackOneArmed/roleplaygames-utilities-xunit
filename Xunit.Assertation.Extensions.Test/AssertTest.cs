using Xunit.Assertation.Extensions.Exceptions;

namespace Xunit.Assertation.Extensions.Test
{
    public class AssertTest
    {
        [Fact]
        public void All_ActionsNotThrowExceptions_DoesNotThrowException()
        {
            // Arrange & Act
            var exception = Record.Exception(() => Assert.All(
                () => Assert.Equal(1, 1),
                () => Assert.Equal(-12, -12)
                )
            );

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void All_ActionsNotThrowException_ThrowException()
        {
            // Arrange & Act
            var exception = Record.Exception(() => Assert.All(
                () => Assert.Equal(1, 1),
                () => Assert.Equal(-12, -2)
                )
            );

            // Assert
            Assert.NotNull(exception);
        }

        [Fact]
        public void All_ActionsNotThrowException_ThrowExceptionAndHas2InnerExceptions()
        {
            // Arrange & Act
            var exception = Record.Exception(() => Assert.All(
                () => Assert.Equal(1, 1),
                () => Assert.Equal(-12, -2),
                () => Assert.Equal(12, 2)
                )
            );

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<AssertAllExceptions>(exception);

            var assertAllExceptions = exception as AssertAllExceptions;

            Assert.Equal(2, assertAllExceptions.InnerExceptions.Count);
        }
    }
}
