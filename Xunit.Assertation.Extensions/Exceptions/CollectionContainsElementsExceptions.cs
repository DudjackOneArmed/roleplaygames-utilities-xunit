using System;
using System.Collections.Generic;
using System.Text;

namespace Xunit.Assertation.Extensions.Exceptions
{
    public class CollectionContainsElementsExceptions<T> : Exception
    {
        public ICollection<T> ContainedElements { get; }

        public CollectionContainsElementsExceptions(ICollection<T> containedElements)
            : base($"Collection contains following elements: {new StringBuilder().AppendJoin(',', containedElements)}")
        {
            ContainedElements = containedElements;
        }
    }
}
