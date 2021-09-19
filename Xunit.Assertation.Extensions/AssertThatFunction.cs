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

        public void Throws<TException>() where TException : Exception
        {
            Xunit.Assert.Throws<TException>(() => Func.Invoke());
        }

        public void Throws()
        {
            Xunit.Assert.Throws<Exception>(() => Func.Invoke());
        }

        public void DoesNotThrow()
        {
            try
            {
                Func.Invoke();
            }
            catch (Exception ex)
            {
                throw new DoesNotThrowAssertationException(ex);
            }
        }

        public void Returns(T expectedResult)
        {
            Assert.That(Func.Invoke()).IsSame(expectedResult);
        }
    }
}
