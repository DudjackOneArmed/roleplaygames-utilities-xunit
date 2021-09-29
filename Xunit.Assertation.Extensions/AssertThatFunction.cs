using System;
using Xunit.Assertation.Extensions.Exceptions;

namespace Xunit.Assertation.Extensions
{
    public class AssertThatFunction<T>
    {
        public Func<T> Func { get; }

        public AssertThatFunction(Func<T> func)
        {
            Func = func ?? throw new ArgumentNullException(nameof(func));
        }

        public AssertThatFunction<T> Throws<TException>() where TException : Exception
        {
            Xunit.Assert.Throws<TException>(() => Func.Invoke());
            return this;
        }

        public AssertThatFunction<T> Throws()
        {
            Xunit.Assert.Throws<Exception>(() => Func.Invoke());
            return this;
        }

        public AssertThatFunction<T> DoesNotThrow()
        {
            try
            {
                Func.Invoke();
                return this;
            }
            catch (Exception ex)
            {
                throw new DoesNotThrowAssertationException(ex);
            }
        }

        public AssertThatFunction<T> Returns(T expectedResult)
        {
            Assert.That(Func.Invoke()).IsSame(expectedResult);
            return this;
        }
    }
}
