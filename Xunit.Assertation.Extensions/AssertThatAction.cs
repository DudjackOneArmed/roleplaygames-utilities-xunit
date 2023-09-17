using System;
using System.Threading.Tasks;
using Xunit.Assertation.Extensions.Exceptions;

namespace Xunit.Assertation.Extensions
{
    public class AssertThatAction
    {
        public Action Action { get; }

        public AssertThatAction(Action action)
        {
            Action = action ?? throw new ArgumentNullException(nameof(action));
        }

        public AssertThatAction Throws<TException>() where TException : Exception
        {
            try
            {
                Action.Invoke();
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

        public AssertThatAction Throws<TException>(Predicate<Exception> predicate) where TException : Exception
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            try
            {
                Action.Invoke();
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

        public AssertThatAction Throws()
        {
            try
            {
                Action.Invoke();
            }
            catch (Exception)
            {
                return this;
            }

            throw new ThrowsAssertationException();
        }

        public AssertThatAction Throws(Predicate<Exception> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            try
            {
                Action.Invoke();
            }
            catch (Exception ex)
            {
                if (predicate(ex))
                    return this;
            }

            throw new ThrowsAssertationException();
        }

        public AssertThatAction DoesNotThrowException()
        {
            try
            {
                Action.Invoke();
            }
            catch (Exception ex)
            {
                throw new DoesNotThrowAssertationException(ex);
            }

            return this;
        }
    }
}
