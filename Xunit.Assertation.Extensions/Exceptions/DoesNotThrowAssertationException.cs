using System;

namespace Xunit.Assertation.Extensions.Exceptions
{
    public class DoesNotThrowAssertationException : Exception
    {
        public DoesNotThrowAssertationException(Exception innerException) : base($"Expected code does not throw exception, but there was: {innerException.Message}", innerException)
        {

        }
    }
}
