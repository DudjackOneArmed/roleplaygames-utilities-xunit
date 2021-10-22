using System;

namespace Xunit.Assertation.Extensions.Exceptions
{
    public class NotAllElementsMatchPredicateException : Exception
    {
        public NotAllElementsMatchPredicateException() : base("Not all elements matching the predicate")
        {

        }
    }
}
