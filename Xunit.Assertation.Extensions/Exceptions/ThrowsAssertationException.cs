using System;

namespace Xunit.Assertation.Extensions.Exceptions
{
    public class ThrowsAssertationException : Exception
    {
        public ThrowsAssertationException() : base($"Code does not throw exception")
        {

        }
    }
}
