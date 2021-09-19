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
                () => Xunit.Assert.Equal(1, 1),
                () => Xunit.Assert.Equal(-12, -12)
                )
            );

            // Assert
            Xunit.Assert.Null(exception);
        }

        [Fact]
        public void All_ActionsNotThrowException_ThrowException()
        {
            // Arrange & Act
            var exception = Record.Exception(() => Assert.All(
                () => Xunit.Assert.Equal(1, 1),
                () => Xunit.Assert.Equal(-12, -2)
                )
            );

            // Assert
            Xunit.Assert.NotNull(exception);
        }

        [Fact]
        public void All_ActionsNotThrowException_ThrowExceptionAndHas2InnerExceptions()
        {
            // Arrange & Act
            var exception = Record.Exception(() => Assert.All(
                () => Xunit.Assert.Equal(1, 1),
                () => Xunit.Assert.Equal(-12, -2),
                () => Xunit.Assert.Equal(12, 2)
                )
            );

            // Assert
            Xunit.Assert.NotNull(exception);
            Xunit.Assert.IsType<AssertAllExceptions>(exception);

            var assertAllExceptions = exception as AssertAllExceptions;

            Xunit.Assert.Equal(2, assertAllExceptions.InnerExceptions.Count);
        }
    }
}
