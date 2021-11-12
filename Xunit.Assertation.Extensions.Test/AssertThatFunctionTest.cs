using System;
using Xunit.Assertation.Extensions.Exceptions;

namespace Xunit.Assertation.Extensions.Test
{
    public class AssertThatFunctionTest
    {
        [Fact]
        public void DoesNotThrowException_FunctionDoesNotThrowException_DoesNotThrowException()
        {
            // Arrange
            AssertThatFunction<object> assertThatAction = new(() => new object());

            // Act
            var exception = Record.Exception(() => assertThatAction.DoesNotThrowException());

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void DoesNotThrowException_FunctionThrowsException_ThrowsDoesNotThrowAssertationException()
        {
            // Arrange
            AssertThatFunction<object> assertThatAction = new(() => throw new Exception());

            // Act & Assert
            Assert.Throws<DoesNotThrowAssertationException>(() => assertThatAction.DoesNotThrowException());
        }

        [Fact]
        public void Throws_InPositiveCase_ReturnThatObject()
        {
            // Arrange
            AssertThatFunction<object> assertThatAction = new(() => throw new Exception());

            // Act
            var result = assertThatAction.Throws();

            // Assert
            Assert.Same(assertThatAction, result);
        }

        [Fact]
        public void DoesNotThrowException_InPositiveCase_ReturnThatObject()
        {
            // Arrange
            AssertThatFunction<object> assertThatAction = new(() => new object());

            // Act
            var result = assertThatAction.DoesNotThrowException();

            // Assert
            Assert.Same(assertThatAction, result);
        }

        [Fact]
        public void Returns_InPositiveCase_ReturnThatObject()
        {
            // Arrange
            object obj = new();
            AssertThatFunction<object> assertThatAction = new(() => obj);

            // Act
            var result = assertThatAction.Returns(obj);

            // Assert
            Assert.Same(assertThatAction, result);
        }
    }
}
