using System;
using System.Data;
using System.Threading.Tasks;
using Xunit.Assertation.Extensions.Exceptions;

namespace Xunit.Assertation.Extensions.Test
{
    public class AssertThatActionAsyncTest
    {
        [Fact]
        public void DoesNotThrowException_ActionDoesNotThrowException_DoesNotThrowException()
        {
            // Arrange
            AssertThatActionAsync assertThatActionAsync = new(() => Task.CompletedTask);

            // Act
            var exception = Record.Exception(() => assertThatActionAsync.DoesNotThrowException());

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void DoesNotThrowException_ActionThrowsException_ThrowsDoesNotThrowAssertationException()
        {
            // Arrange
            AssertThatActionAsync assertThatActionAsync = new(() => throw new Exception());

            // Act
            var exception = Record.Exception(() => assertThatActionAsync.DoesNotThrowException());

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<DoesNotThrowAssertationException>(exception);
        }

        [Fact]
        public void DoesNotThrowException_ActionDoesNotThrowException_ReturnsThatObject()
        {
            // Arrange
            AssertThatActionAsync assertThatActionAsync = new(() => Task.CompletedTask);

            // Act
            var result = assertThatActionAsync.DoesNotThrowException();

            // Assert
            Assert.Same(assertThatActionAsync, result);
        }

        [Fact]
        public async Task DoesNotThrowExceptionAsync_ActionDoesNotThrowException_DoesNotThrowException()
        {
            // Arrange
            AssertThatActionAsync assertThatActionAsync = new(() => Task.CompletedTask);

            // Act
            var exception = await Record.ExceptionAsync(assertThatActionAsync.DoesNotThrowExceptionAsync);

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public async Task DoesNotThrowExceptionAsync_ActionThrowsException_ThrowsDoesNotThrowAssertationException()
        {
            // Arrange
            AssertThatActionAsync assertThatActionAsync = new(() => throw new Exception());

            // Act
            var exception = await Record.ExceptionAsync(assertThatActionAsync.DoesNotThrowExceptionAsync);

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<DoesNotThrowAssertationException>(exception);
        }

        [Fact]
        public async Task DoesNotThrowExceptionAsync_ActionDoesNotThrowException_ReturnsThatObject()
        {
            // Arrange
            AssertThatActionAsync assertThatActionAsync = new(() => Task.CompletedTask);

            // Act
            var result = await assertThatActionAsync.DoesNotThrowExceptionAsync();

            // Assert
            Assert.Same(assertThatActionAsync, result);
        }

        [Fact]
        public void Throws_ActionThrowsException_ReturnsThatObject()
        {
            // Arrange
            AssertThatActionAsync assertThatActionAsync = new(() => throw new Exception());

            // Act
            var result = assertThatActionAsync.Throws();

            // Assert
            Assert.Same(assertThatActionAsync, result);
        }

        [Fact]
        public void Throws_ActionDoesNotThrowException_ThrowsThrowsAssertationException()
        {
            // Arrange
            AssertThatActionAsync assertThatActionAsync = new(() => Task.CompletedTask);

            // Act
            var exception = Record.Exception(() => assertThatActionAsync.Throws());

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ThrowsAssertationException>(exception);
        }

        [Fact]
        public async Task ThrowsAsync_ActionThrowsException_ReturnsThatObject()
        {
            // Arrange
            AssertThatActionAsync assertThatActionAsync = new(() => throw new Exception());

            // Act
            var result = await assertThatActionAsync.ThrowsAsync();

            // Assert
            Assert.Same(assertThatActionAsync, result);
        }

        [Fact]
        public async Task ThrowsAsync_ActionDoesNotThrowException_ThrowsThrowsAssertationException()
        {
            // Arrange
            AssertThatActionAsync assertThatActionAsync = new(() => Task.CompletedTask);

            // Act
            var exception = await Record.ExceptionAsync(assertThatActionAsync.ThrowsAsync);

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ThrowsAssertationException>(exception);
        }

        [Fact]
        public void ThrowsWithPredicate_ActionThrowsException_ReturnsThatObject()
        {
            // Arrange
            AssertThatActionAsync assertThatActionAsync = new(() => throw new InRowChangingEventException());

            // Act
            var result = assertThatActionAsync.Throws(x => x is InRowChangingEventException);

            // Assert
            Assert.Same(assertThatActionAsync, result);
        }

        [Fact]
        public void ThrowsWithPredicate_ActionDoesNotThrowExceptionByPredicate_ThrowsThrowsAssertationException()
        {
            // Arrange
            AssertThatActionAsync assertThatActionAsync = new(() => throw new InRowChangingEventException());

            // Act
            var exception = Record.Exception(() => assertThatActionAsync.Throws(x => x is ArgumentException));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ThrowsAssertationException>(exception);
        }

        [Fact]
        public void ThrowsWithPredicate_ActionDoesNotThrowException_ThrowsThrowsAssertationException()
        {
            // Arrange
            AssertThatActionAsync assertThatActionAsync = new(() => Task.CompletedTask);

            // Act
            var exception = Record.Exception(() => assertThatActionAsync.Throws());

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ThrowsAssertationException>(exception);
        }

        [Fact]
        public async Task ThrowsAsyncWithPredicate_ActionThrowsException_ReturnsThatObject()
        {
            // Arrange
            AssertThatActionAsync assertThatActionAsync = new(() => throw new InRowChangingEventException());

            // Act
            var result = await assertThatActionAsync.ThrowsAsync(x => x is InRowChangingEventException);

            // Assert
            Assert.Same(assertThatActionAsync, result);
        }

        [Fact]
        public async Task ThrowsAsyncWithPredicate_ActionDoesNotThrowExceptionByPredicate_ThrowsThrowsAssertationException()
        {
            // Arrange
            AssertThatActionAsync assertThatActionAsync = new(() => throw new InRowChangingEventException());

            // Act
            var exception = await Record.ExceptionAsync(() => assertThatActionAsync.ThrowsAsync(x => x is ArgumentException));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ThrowsAssertationException>(exception);
        }

        [Fact]
        public async Task ThrowsAsyncWithPredicate_ActionDoesNotThrowException_ThrowsThrowsAssertationException()
        {
            // Arrange
            AssertThatActionAsync assertThatActionAsync = new(() => Task.CompletedTask);

            // Act
            var exception = await Record.ExceptionAsync(() => assertThatActionAsync.ThrowsAsync());

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ThrowsAssertationException>(exception);
        }

        [Fact]
        public void ThrowsGeneric_ActionThrowsException_ReturnsThatObject()
        {
            // Arrange
            AssertThatActionAsync assertThatActionAsync = new(() => throw new ArgumentException());

            // Act
            var result = assertThatActionAsync.Throws<ArgumentException>();

            // Assert
            Assert.Same(assertThatActionAsync, result);
        }

        [Fact]
        public void ThrowsGeneric_ActionDoesNotThrowException_ThrowsThrowsAssertationException()
        {
            // Arrange
            AssertThatActionAsync assertThatActionAsync = new(() => Task.CompletedTask);

            // Act
            var exception = Record.Exception(() => assertThatActionAsync.Throws<ArgumentException>());

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ThrowsAssertationException>(exception);
        }

        [Fact]
        public void ThrowsGeneric_ActionThrowsWrongTypeException_ThrowsThrowsWrongExceptionTypeException()
        {
            // Arrange
            AssertThatActionAsync assertThatActionAsync = new(() => throw new Exception());

            // Act
            var exception = Record.Exception(() => assertThatActionAsync.Throws<ArgumentException>());

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ThrowsWrongExceptionTypeException<ArgumentException>>(exception);
        }

        [Fact]
        public async Task ThrowsAsyncGeneric_ActionThrowsException_ReturnsThatObject()
        {
            // Arrange
            AssertThatActionAsync assertThatActionAsync = new(() => throw new ArgumentException());

            // Act
            var result = await assertThatActionAsync.ThrowsAsync<ArgumentException>();

            // Assert
            Assert.Same(assertThatActionAsync, result);
        }

        [Fact]
        public async Task ThrowsAsyncGeneric_ActionDoesNotThrowException_ThrowsThrowsAssertationException()
        {
            // Arrange
            AssertThatActionAsync assertThatActionAsync = new(() => Task.CompletedTask);

            // Act
            var exception = await Record.ExceptionAsync(() => assertThatActionAsync.ThrowsAsync<ArgumentException>());

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ThrowsAssertationException>(exception);
        }

        [Fact]
        public async Task ThrowsAsyncGeneric_ActionThrowsWrongTypeException_ThrowsThrowsWrongExceptionTypeException()
        {
            // Arrange
            AssertThatActionAsync assertThatActionAsync = new(() => throw new Exception());

            // Act
            var exception = await Record.ExceptionAsync(() => assertThatActionAsync.ThrowsAsync<ArgumentException>());

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ThrowsWrongExceptionTypeException<ArgumentException>>(exception);
        }
    }
}
