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

            // Act & Assert
            Assert.Throws<DoesNotThrowAssertationException>(() => assertThatAction.DoesNotThrowException());
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
        public void DoesNotThrowException_InPositiveCase_ReturnThatObject()
        {
            // Arrange
            AssertThatAction assertThatAction = new(() => { });

            // Act
            var result = assertThatAction.DoesNotThrowException();

            // Assert
            Assert.Same(assertThatAction, result);
        }
    }
}
