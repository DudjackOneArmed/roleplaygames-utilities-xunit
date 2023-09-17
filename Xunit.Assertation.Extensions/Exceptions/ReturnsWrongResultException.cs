using System;

namespace Xunit.Assertation.Extensions.Exceptions
{
    /// <summary>
    /// Represents when code returns not expected result
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ReturnsWrongResultException<T> : Exception
    {
        /// <summary>
        /// Expected result
        /// </summary>
        public T Expected { get; }

        /// <summary>
        /// Actual result
        /// </summary>
        public T Actual { get; }

        public ReturnsWrongResultException(T expected, T actual)
        {
            Expected = expected;
            Actual = actual;
        }
    }
}
