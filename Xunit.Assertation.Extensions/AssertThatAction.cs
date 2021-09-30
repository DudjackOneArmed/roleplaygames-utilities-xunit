using System;
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
            Assert.Throws<TException>(() => Action.Invoke());
            return this;
        }

        public AssertThatAction Throws()
        {
            Assert.Throws<Exception>(() => Action.Invoke());
            return this;
        }

        public AssertThatAction DoesNotThrow()
        {
            try
            {
                Action.Invoke();
                return this;
            } 
            catch(Exception ex)
            {
                throw new DoesNotThrowAssertationException(ex);
            }
        }
    }
}
