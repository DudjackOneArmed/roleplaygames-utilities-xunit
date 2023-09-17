using System;
using Xunit.Assertation.Extensions.Exceptions;

namespace Xunit.Assertation.Extensions.Test
{
    public class AssertThatActionTest
    {
        [Fact]
        public void DoesNotThrowException_ActionDoesNotThrowException_DoesNotThrowException()
        {
            // Arrange
            AssertThatAction assertThatAction = new(() => { });

            // Act
            var exception = Record.Exception(() => assertThatAction.DoesNotThrowException());

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void DoesNotThrowException_ActionThrowsException_ThrowsDoesNotThrowAssertationException()
        {
            // Arrange
            AssertThatAction assertThatAction = new(() => throw new Exception());

            // Act
            var exception = Record.Exception(() => assertThatAction.DoesNotThrowException());

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<DoesNotThrowAssertationException>(exception);
        }

        [Fact]
        public void DoesNotThrowException_ActionDoesNotThrowException_ReturnsThatObject()
        {
            // Arrange
            AssertThatAction assertThatAction = new(() => { });

            // Act
            var result = assertThatAction.DoesNotThrowException();

            // Assert
            Assert.Same(assertThatAction, result);
        }

        [Fact]
        public void Throws_ActionThrowsException_ReturnsThatObject()
        {
            // Arrange
            AssertThatAction assertThatAction = new(() => throw new Exception());

            // Act
            var result = assertThatAction.Throws();

            // Assert
            Assert.Same(assertThatAction, result);
        }

        [Fact]
        public void Throws_ActionDoesNotThrowException_ThrowsThrowsAssertationException()
        {
            // Arrange
            AssertThatAction assertThatAction = new(() => { });

            // Act
            var exception = Record.Exception(() => assertThatAction.Throws());

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ThrowsAssertationException>(exception);
        }

        [Fact]
        public void ThrowsGeneric_ActionThrowsException_ReturnsThatObject()
        {
            // Arrange
            AssertThatAction assertThatAction = new(() => throw new ArgumentException());

            // Act
            var result = assertThatAction.Throws<ArgumentException>();

            // Assert
            Assert.Same(assertThatAction, result);
        }

        [Fact]
        public void ThrowsGeneric_ActionDoesNotThrowException_ThrowsThrowsAssertationException()
        {
            // Arrange
            AssertThatAction assertThatAction = new(() => { });

            // Act
            var exception = Record.Exception(() => assertThatAction.Throws());

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ThrowsAssertationException>(exception);
        }

        [Fact]
        public void ThrowsGeneric_ActionThrowsWrongTypeException_ThrowsThrowsWrongExceptionTypeException()
        {
            // Arrange
            AssertThatAction assertThatAction = new(() => throw new Exception());

            // Act
            var exception = Record.Exception(() => assertThatAction.Throws<ArgumentException>());

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ThrowsWrongExceptionTypeException<ArgumentException>>(exception);
        }
    }
}
