using System;
using System.Threading.Tasks;
using Xunit.Assertation.Extensions.Exceptions;

namespace Xunit.Assertation.Extensions.Test
{
    public class AssertThatFunctionAsyncTest
    {
        [Fact]
        public void DoesNotThrowException_FunctionDoesNotThrowException_DoesNotThrowException()
        {
            // Arrange
            AssertThatFunctionAsync<object> assertThatActionAsync = new(() => Task.FromResult(new object()));

            // Act
            var exception = Record.Exception(() => assertThatActionAsync.DoesNotThrowException());

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void DoesNotThrowException_FunctionThrowsException_ThrowsDoesNotThrowAssertationException()
        {
            // Arrange
            AssertThatFunctionAsync<object> assertThatActionAsync = new(() => throw new Exception());

            // Act
            var exception = Record.Exception(() => assertThatActionAsync.DoesNotThrowException());

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<DoesNotThrowAssertationException>(exception);
        }

        [Fact]
        public void DoesNotThrowException_FunctionDoesNotThrowException_ReturnsThatObject()
        {
            // Arrange
            AssertThatFunctionAsync<object> assertThatActionAsync = new(() => Task.FromResult(new object()));

            // Act
            var result = assertThatActionAsync.DoesNotThrowException();

            // Assert
            Assert.Same(assertThatActionAsync, result);
        }

        [Fact]
        public void Throws_FunctionThrowsException_ReturnsThatObject()
        {
            // Arrange
            AssertThatFunctionAsync<object> assertThatActionAsync = new(() => throw new Exception());

            // Act
            var result = assertThatActionAsync.Throws();

            // Assert
            Assert.Same(assertThatActionAsync, result);
        }

        [Fact]
        public void Throws_FunctionDoesNotThrowException_ThrowsThrowsAssertationException()
        {
            // Arrange
            AssertThatFunctionAsync<object> assertThatActionAsync = new(() => Task.FromResult(new object()));

            // Act
            var exception = Record.Exception(() => assertThatActionAsync.Throws());

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ThrowsAssertationException>(exception);
        }

        [Fact]
        public void ThrowsGeneric_FunctionThrowsException_ReturnsThatObject()
        {
            // Arrange
            AssertThatFunctionAsync<object> assertThatActionAsync = new(() => throw new ArgumentException());

            // Act
            var result = assertThatActionAsync.Throws<ArgumentException>();

            // Assert
            Assert.Same(assertThatActionAsync, result);
        }

        [Fact]
        public void ThrowsGeneric_FunctionDoesNotThrowException_ThrowsThrowsAssertationException()
        {
            // Arrange
            AssertThatFunctionAsync<object> assertThatActionAsync = new(() => Task.FromResult(new object()));

            // Act
            var exception = Record.Exception(() => assertThatActionAsync.Throws<ArgumentException>());

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ThrowsAssertationException>(exception);
        }

        [Fact]
        public void ThrowsGeneric_FunctionThrowsWrongTypeException_ThrowsThrowsWrongExceptionTypeException()
        {
            // Arrange
            AssertThatFunctionAsync<object> assertThatActionAsync = new(() => throw new Exception());

            // Act
            var exception = Record.Exception(() => assertThatActionAsync.Throws<ArgumentException>());

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ThrowsWrongExceptionTypeException<ArgumentException>>(exception);
        }

        [Fact]
        public void Returns_FunctionReturnsExpectedResult_ReturnsThatObject()
        {
            // Arrange
            object obj = new();
            AssertThatFunctionAsync<object> assertThatActionAsync = new(() => Task.FromResult(obj));

            // Act
            var result = assertThatActionAsync.Returns(obj);

            // Assert
            Assert.Same(assertThatActionAsync, result);
        }

        [Fact]
        public void Returns_FunctionReturnsNotExpectedResult_ThrowsReturnsWrongResultException()
        {
            // Arrange
            AssertThatFunctionAsync<object> assertThatActionAsync = new(() => Task.FromResult(new object()));

            // Act
            var exception = Record.Exception(() => assertThatActionAsync.Returns(new object()));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ReturnsWrongResultException<object>>(exception);
        }
    }
}
