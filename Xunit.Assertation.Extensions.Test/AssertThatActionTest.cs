using System;
using Xunit.Assertation.Extensions.Exceptions;

namespace Xunit.Assertation.Extensions.Test
{
    public class AssertThatActionTest
    {
        [Fact]
        public void DoesNotThrow_ActionDoesNotThrowException_DoesNotThrowException()
        {
            // Arrange
            AssertThatAction assertThatAction = new(() => { });

            // Act
            var exception = Record.Exception(() => assertThatAction.DoesNotThrow());

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void DoesNotThrow_ActionThrowsException_ThrowsDoesNotThrowAssertationException()
        {
            // Arrange
            AssertThatAction assertThatAction = new(() => throw new Exception());

            // Act & Assert
            Assert.Throws<DoesNotThrowAssertationException>(() => assertThatAction.DoesNotThrow());
        }

        [Fact]
        public void Throws_InPositiveCase_ReturnThatObject()
        {
            // Arrange
            AssertThatAction assertThatAction = new(() => throw new Exception());

            // Act
            var result = assertThatAction.Throws();

            // Assert
            Assert.Same(assertThatAction, result);
        }

        [Fact]
        public void DoesNotThrow_InPositiveCase_ReturnThatObject()
        {
            // Arrange
            AssertThatAction assertThatAction = new(() => { });

            // Act
            var result = assertThatAction.DoesNotThrow();

            // Assert
            Assert.Same(assertThatAction, result);
        }
    }
}
