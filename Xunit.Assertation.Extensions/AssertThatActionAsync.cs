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

        public async Task<AssertThatActionAsync> ThrowsAsync<TException>() where TException : Exception
        {
            try
            {
                await Action.Invoke();
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

        public async Task<AssertThatActionAsync> ThrowsAsync<TException>(Predicate<Exception> predicate) where TException : Exception
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            try
            {
                await Action.Invoke();
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

        public async Task<AssertThatActionAsync> ThrowsAsync()
        {
            try
            {
                await Action.Invoke();
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

        public async Task<AssertThatActionAsync> ThrowsAsync(Predicate<Exception> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            try
            {
                await Action.Invoke();
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

        public async Task<AssertThatActionAsync> DoesNotThrowExceptionAsync()
        {
            try
            {
                await Action.Invoke();
            }
            catch (Exception ex)
            {
                throw new DoesNotThrowAssertationException(ex);
            }

            return this;
        }
    }
}
