using System;
using System.Collections.Generic;
using System.Linq;
using Xunit.Assertation.Extensions;
using Xunit.Assertation.Extensions.Exceptions;

namespace Xunit
{
    public partial class Assert
    {
        public static AssertThatIEnumerable<U, T> That<U, T>(U item) where U : IEnumerable<T>
        {
            return new AssertThatIEnumerable<U, T>(item);
        }

        /// <summary>
        /// Get assertation service for boolean
        /// </summary>
        /// <param name="item">Verifying item</param>
        /// <returns>Assertation service for boolean</returns>
        public static AssertThatBoolean That(bool item)
        {
            return new AssertThatBoolean(item);
        }

        public static AssertThat<T> That<T>(T item) => new AssertThat<T>(item);

        public static AssertThat<object> That(object item) => new AssertThat<object>(item);

        public static void All(params Action[] assertations)
        {
            var exceptions = new List<Exception>();

            foreach (var action in assertations)
            {
                try
                {
                    action.Invoke();
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }

            if (exceptions.Any())
                throw new AssertAllExceptions(exceptions);
        }

        public static AssertThatAction ThatCode(Action action) => new AssertThatAction(action);

        public static AssertThatFunction<T> ThatCode<T>(Func<T> func) => new AssertThatFunction<T>(func);
    }
}
