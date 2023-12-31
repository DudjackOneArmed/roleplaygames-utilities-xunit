﻿using System;
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

            // Act
            var exception = Record.Exception(() => assertThatAction.DoesNotThrowException());

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<DoesNotThrowAssertationException>(exception);
        }

        [Fact]
        public void DoesNotThrowException_FuntionDoesNotThrowException_ReturnsThatObject()
        {
            // Arrange
            AssertThatFunction<object> assertThatAction = new(() => new object());

            // Act
            var result = assertThatAction.DoesNotThrowException();

            // Assert
            Assert.Same(assertThatAction, result);
        }

        [Fact]
        public void Throws_FunctionThrowsException_ReturnsThatObject()
        {
            // Arrange
            AssertThatFunction<object> assertThatAction = new(() => throw new Exception());

            // Act
            var result = assertThatAction.Throws();

            // Assert
            Assert.Same(assertThatAction, result);
        }

        [Fact]
        public void Throws_FunctionDoesNotThrowException_ThrowsThrowsAssertationException()
        {
            // Arrange
            AssertThatFunction<object> assertThatAction = new(() => new());

            // Act
            var exception = Record.Exception(() => assertThatAction.Throws());

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ThrowsAssertationException>(exception);
        }

        [Fact]
        public void ThrowsGeneric_FunctionThrowsException_ReturnsThatObject()
        {
            // Arrange
            AssertThatFunction<object> assertThatAction = new(() => throw new ArgumentException());

            // Act
            var result = assertThatAction.Throws<ArgumentException>();

            // Assert
            Assert.Same(assertThatAction, result);
        }

        [Fact]
        public void ThrowsGeneric_FunctionDoesNotThrowException_ThrowsThrowsAssertationException()
        {
            // Arrange
            AssertThatFunction<object> assertThatAction = new(() => new());

            // Act
            var exception = Record.Exception(() => assertThatAction.Throws<ArgumentException>());

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ThrowsAssertationException>(exception);
        }

        [Fact]
        public void ThrowsGeneric_FunctionThrowsWrongTypeException_ThrowsThrowsWrongExceptionTypeException()
        {
            // Arrange
            AssertThatFunction<object> assertThatAction = new(() => throw new Exception());

            // Act
            var exception = Record.Exception(() => assertThatAction.Throws<ArgumentException>());

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ThrowsWrongExceptionTypeException<ArgumentException>>(exception);
        }

        [Fact]
        public void Returns_FunctionReturnsExpectedResult_ReturnsThatObject()
        {
            // Arrange
            object obj = new();
            AssertThatFunction<object> assertThatAction = new(() => obj);

            // Act
            var result = assertThatAction.Returns(obj);

            // Assert
            Assert.Same(assertThatAction, result);
        }

        [Fact]
        public void Returns_FunctionReturnsWrongResult_ThrowsReturnsWrongResultException()
        {
            // Arrange
            AssertThatFunction<object> assertThatAction = new(() => new());

            // Act
            var exception = Record.Exception(() => assertThatAction.Returns(new()));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ReturnsWrongResultException<object>>(exception);
        }
    }
}
