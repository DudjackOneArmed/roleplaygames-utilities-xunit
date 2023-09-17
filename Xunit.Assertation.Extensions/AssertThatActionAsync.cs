using System;
using System.Threading.Tasks;
using Xunit.Assertation.Extensions.Exceptions;

namespace Xunit.Assertation.Extensions
{
    public class AssertThatActionAsync
    {
        public Func<Task> Action { get; }

        public AssertThatActionAsync(Func<Task> action)
        {
            Action = action ?? throw new ArgumentNullException(nameof(action));
        }

        public AssertThatActionAsync Throws<TException>() where TException : Exception
        {
            try
            {
                Task.Run(Action.Invoke).ConfigureAwait(false).GetAwaiter().GetResult();
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

        public AssertThatActionAsync Throws<TException>(Predicate<Exception> predicate) where TException : Exception
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            try
            {
                Task.Run(Action.Invoke).ConfigureAwait(false).GetAwaiter().GetResult();
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

        public AssertThatActionAsync Throws()
        {
            try
            {
                Task.Run(Action.Invoke).ConfigureAwait(false).GetAwaiter().GetResult();
            }
            catch (Exception)
            {
                return this;
            }

            throw new ThrowsAssertationException();
        }

        public AssertThatActionAsync Throws(Predicate<Exception> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            try
            {
                Task.Run(Action.Invoke).ConfigureAwait(false).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                if (predicate(ex))
                    return this;
            }

            throw new ThrowsAssertationException();
        }

        public AssertThatActionAsync DoesNotThrowException()
        {
            try
            {
                Task.Run(Action.Invoke).ConfigureAwait(false).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw new DoesNotThrowAssertationException(ex);
            }

            return this;
        }
    }
}
