using System;

namespace Xunit.Assertation.Extensions.Exceptions
{
    /// <summary>
    /// Represents when code throws exception of not expected type
    /// </summary>
    /// <typeparam name="TExpectedExceptionType">Expected exception type</typeparam>
    public class ThrowsWrongExceptionTypeException<TExpectedExceptionType> : Exception
        where TExpectedExceptionType : Exception
    {
        /// <summary>
        /// Exception that was recived instead of expected exception type instance
        /// </summary>
        public Exception ActualException { get; }

        public ThrowsWrongExceptionTypeException(Exception actualException) : base($"Code throws wrong exception type. Expected for {typeof(TExpectedExceptionType)}, but actual was {actualException.GetType()}")
        {
            ActualException = actualException;
        }
    }
}
