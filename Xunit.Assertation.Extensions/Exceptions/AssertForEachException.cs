using System;
using System.Collections.Generic;
using System.Text;

namespace Xunit.Assertation.Extensions.Exceptions
{
    public class AssertForEachException : Exception
    {
        public IReadOnlyCollection<Exception> InnerExceptions { get; }

        public AssertForEachException(IReadOnlyCollection<Exception> exceptions, string message) : base(message)
        {
            InnerExceptions = exceptions ?? throw new ArgumentNullException(nameof(exceptions));
        }

        public AssertForEachException(IReadOnlyCollection<Exception> exceptions) : this(exceptions, CreateErrorMessage(exceptions))
        {

        }

        private static string CreateErrorMessage(IReadOnlyCollection<Exception> exceptions)
        {
            var message = new StringBuilder($"Assertation has {exceptions.Count} errors:\n");

            foreach (var exception in exceptions)
            {
                message.AppendLine(exception.Message);
            }

            return message.ToString();
        }
    }
}
