using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Assertation.Extensions.Exceptions;

namespace Xunit.Assertation.Extensions.Test
{
    public class AssertThatFunctionTest
    {
        [Fact]
        public void DoesNotThrow_FunctionDoesNotThrowException_DoesNotThrowException()
        {
            // Arrange
            AssertThatFunction<object> assertThatAction = new(() => new object());

            // Act
            var exception = Record.Exception(() => assertThatAction.DoesNotThrow());

            // Assert
            Xunit.Assert.Null(exception);
        }

        [Fact]
        public void DoesNotThrow_FunctionThrowsException_ThrowsDoesNotThrowAssertationException()
        {
            // Arrange
            AssertThatFunction<object> assertThatAction = new(() => throw new Exception());

            // Act & Assert
            Xunit.Assert.Throws<DoesNotThrowAssertationException>(() => assertThatAction.DoesNotThrow());
        }
    }
}
