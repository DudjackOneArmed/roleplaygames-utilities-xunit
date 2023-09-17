using System;

namespace Xunit.Assertation.Extensions.Exceptions
{
    public class NotOrderedByParameterException : Exception
    {
        public object SmallerElement { get; }

        public object GreaterElement { get; }

        public NotOrderedByParameterException(object smallerElement, int smallerElementIndex, object greaterElement, int greaterElementIndex)
            : base($"Collection was not ordered by paramter because element {greaterElement} (at ${greaterElementIndex}) is greater than {smallerElement} (at ${smallerElementIndex})")
        {
            SmallerElement = smallerElement;
            GreaterElement = greaterElement;
        }
    }
}
