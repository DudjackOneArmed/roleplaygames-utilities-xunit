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

        public void Throws<TException>() where TException : Exception
        {
            Xunit.Assert.Throws<TException>(() => Action.Invoke());
        }

        public void Throws()
        {
            Xunit.Assert.Throws<Exception>(() => Action.Invoke());
        }

        public void DoesNotThrow()
        {
            try
            {
                Action.Invoke();
            } 
            catch(Exception ex)
            {
                throw new DoesNotThrowAssertationException(ex);
            }
        }
    }
}
