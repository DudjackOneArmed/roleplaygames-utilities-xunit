﻿namespace Xunit.Assertation.Extensions.Test
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
            Assert.Null(exception);
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
            Assert.NotNull(exception);
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
            Assert.Null(exception);
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
            Assert.NotNull(exception);
        }

        [Fact]
        public void IsNotNull_ItemIsNull_ThrowsException()
        {
            // Arrange
            var assertation = new AssertThat<object>(null);

            // Act
            var exception = Record.Exception(() => assertation.IsNotNull());

            // Assert
            Assert.NotNull(exception);
        }

        [Fact]
        public void IsNotNull_ItemIsNotNull_DoesNotThrowException()
        {
            // Arrange
            var assertation = new AssertThat<object>(new());

            // Act
            var exception = Record.Exception(() => assertation.IsNotNull());

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void IsEqualTo_InPositiveCase_ReturnThatObject()
        {
            // Arrange
            object obj = new();
            var assertThat = new AssertThat<object>(obj);

            // Act
            var result = assertThat.IsEqualTo(obj);

            // Assert
            Assert.Same(assertThat, result);
        }

        [Fact]
        public void IsNull_InPositiveCase_ReturnThatObject()
        {
            // Arrange
            var assertThat = new AssertThat<object>(null);

            // Act
            var result = assertThat.IsNull();

            // Assert
            Assert.Same(assertThat, result);
        }

        [Fact]
        public void IsNotNull_InPositiveCase_ReturnThatObject()
        {
            // Arrange
            var assertThat = new AssertThat<object>(new());

            // Act
            var result = assertThat.IsNotNull();

            // Assert
            Assert.Same(assertThat, result);
        }

        [Fact]
        public void IsSame_InPositiveCase_ReturnThatObject()
        {
            // Arrange
            object obj = new();
            var assertThat = new AssertThat<object>(obj);

            // Act
            var result = assertThat.IsSame(obj);

            // Assert
            Assert.Same(assertThat, result);
        }

        [Fact]
        public void IsType_ItemIsThatType_DoesNotThrowException()
        {
            // Arrange
            var assertation = new AssertThat<object>(new());

            // Act
            var exception = Record.Exception(() => assertation.IsType<object>());

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void IsType_ItemIsNotThatType_ThrowsException()
        {
            // Arrange
            var assertation = new AssertThat<object>(new());

            // Act
            var exception = Record.Exception(() => assertation.IsType<string>());

            // Assert
            Assert.NotNull(exception);
        }

        [Fact]
        public void IsType_InPositiveCase_ReturnThatObject()
        {
            // Arrange
            var assertThat = new AssertThat<object>(new());

            // Act
            var result = assertThat.IsType<object>();

            // Assert
            Assert.Same(assertThat, result);
        }

        [Fact]
        public void IsNotType_ItemIsNotThatType_DoesNotThrowException()
        {
            // Arrange
            var assertation = new AssertThat<object>(new());

            // Act
            var exception = Record.Exception(() => assertation.IsNotType<string>());

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void IsNotType_ItemIsThatType_ThrowsException()
        {
            // Arrange
            var assertation = new AssertThat<object>(new());

            // Act
            var exception = Record.Exception(() => assertation.IsNotType<object>());

            // Assert
            Assert.NotNull(exception);
        }

        [Fact]
        public void IsNotType_InPositiveCase_ReturnThatObject()
        {
            // Arrange
            var assertThat = new AssertThat<object>(new());

            // Act
            var result = assertThat.IsNotType<string>();

            // Assert
            Assert.Same(assertThat, result);
        }

        [Theory]
        [InlineData(12, 13)]
        public void IsNotEqualTo_ItemIsNotEqualToExpected_DoesNotThrowException(int actual, int expected)
        {
            // Arrange
            var assertation = new AssertThat<int>(actual);

            // Act
            var exception = Record.Exception(() => assertation.IsNotEqualTo(expected));

            // Assert
            Assert.Null(exception);
        }

        [Theory]
        [InlineData(12, 12)]
        public void IsNotEqualTo_ItemIsEqualToExpected_ThrowsException(int actual, int expected)
        {
            // Arrange
            var assertation = new AssertThat<int>(actual);

            // Act
            var exception = Record.Exception(() => assertation.IsNotEqualTo(expected));

            // Assert
            Assert.NotNull(exception);
        }

        [Fact]
        public void IsNotEqualTo_InPositiveCase_ReturnThatObject()
        {
            // Arrange
            var obj = 2;
            var assertThat = new AssertThat<int>(1);

            // Act
            var result = assertThat.IsNotEqualTo(obj);

            // Assert
            Assert.Same(assertThat, result);
        }
    }
}
