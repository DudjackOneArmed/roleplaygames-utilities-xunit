using System;
using System.Threading.Tasks;
using Xunit.Assertation.Extensions.Exceptions;

namespace Xunit.Assertation.Extensions
{
    public class AssertThatFunctionAsync<T>
    {
        public Func<Task<T>> Func { get; }

        public AssertThatFunctionAsync(Func<Task<T>> func)
        {
            Func = func ?? throw new ArgumentNullException(nameof(func));
        }

        public AssertThatFunctionAsync<T> Throws<TException>() where TException : Exception
        {
            try
            {
                Task.Run(Func.Invoke).ConfigureAwait(false).GetAwaiter().GetResult();
            }
            catch (TException)
            {
                return this;
            }
            catch (Exception ex)
            {
                throw new ThrowsWrongExceptionTypeException<TException>(ex);
            }

            throw new ThrowsAssertationException();
        }

        public AssertThatFunctionAsync<T> Throws<TException>(Predicate<Exception> predicate) where TException : Exception
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            try
            {
                Task.Run(Func.Invoke).ConfigureAwait(false).GetAwaiter().GetResult();
            }
            catch (TException ex)
            {
                if (predicate(ex))
                    return this;
            }
            catch (Exception ex)
            {
                throw new ThrowsWrongExceptionTypeException<TException>(ex);
            }

            throw new ThrowsAssertationException();
        }

        public AssertThatFunctionAsync<T> Throws()
        {
            try
            {
                Task.Run(Func.Invoke).ConfigureAwait(false).GetAwaiter().GetResult();
            }
            catch (Exception)
            {
                return this;
            }

            throw new ThrowsAssertationException();
        }

        public AssertThatFunctionAsync<T> Throws(Predicate<Exception> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            try
            {
                Task.Run(Func.Invoke).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                if (predicate(ex))
                    return this;
            }

            throw new ThrowsAssertationException();
        }

        public AssertThatFunctionAsync<T> DoesNotThrowException()
        {
            try
            {
                Task.Run(Func.Invoke).ConfigureAwait(false).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw new DoesNotThrowAssertationException(ex);
            }

            return this;
        }
        
        public AssertThatFunctionAsync<T> Returns(T expectedResult)
        {
            var result = Task.Run(Func.Invoke).ConfigureAwait(false).GetAwaiter().GetResult();

            return result.Equals(expectedResult)
                ? this
                : throw new ReturnsWrongResultException<T>(expectedResult, result);
        }
    }
}
