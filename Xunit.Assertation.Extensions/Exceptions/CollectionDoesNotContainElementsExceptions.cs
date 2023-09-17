using System;
using System.Collections.Generic;
using System.Text;

namespace Xunit.Assertation.Extensions.Exceptions
{
    public class CollectionDoesNotContainElementsExceptions<T> : Exception
    {
        public ICollection<T> UncontainedElements { get; }

        public CollectionDoesNotContainElementsExceptions(ICollection<T> uncontainedElements)
            : base($"Collection does not contain following elements: { new StringBuilder().AppendJoin(',', uncontainedElements) }")
        {
            UncontainedElements = uncontainedElements;
        }
    }
}
