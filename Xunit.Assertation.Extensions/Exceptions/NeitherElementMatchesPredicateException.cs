using System;

namespace Xunit.Assertation.Extensions.Exceptions
{
    public class NeitherElementMatchesPredicateException : Exception
    {
        public NeitherElementMatchesPredicateException() : base("Neither element matches the predicate")
        {

        }
    }
}
