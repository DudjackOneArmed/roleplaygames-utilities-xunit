using System;
using System.Collections.Generic;
using System.Text;

namespace Xunit.Assertation.Extensions.Exceptions
{
    public class CollectionContainsNotSingleElementsException<T> : Exception
    {
        public ICollection<T> NotSingleElements { get; }

        public CollectionContainsNotSingleElementsException(ICollection<T> notSingleElements)
            : base($"Collection does not contain single following elements: { new StringBuilder().AppendJoin(',', notSingleElements) }")
        {
            NotSingleElements = notSingleElements;
        }
    }
}
