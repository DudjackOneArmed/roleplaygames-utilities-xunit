﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit.Assertation.Extensions;
using Xunit.Assertation.Extensions.Exceptions;

namespace Xunit
{
    public partial class Assert
    {
        /// <summary>
        /// Get assertation service for boolean
        /// </summary>
        /// <param name="item">Verifying item</param>
        /// <returns>Assertation service for boolean</returns>
        public static AssertThatBoolean That(bool item)
        {
            return new AssertThatBoolean(item);
        }

        /// <summary>
        /// Get assertation service for collections
        /// </summary>
        /// <param name="item">Verifying item</param>
        /// <returns>Assertation service for collections</returns>
        public static AssertThatIEnumerable<IEnumerable<T>, T> ThatCollection<T>(IEnumerable<T> item)
        {
            return new AssertThatIEnumerable<IEnumerable<T>, T>(item);
        }

        public static AssertThat<T> That<T>(T item)
        {
            return new AssertThat<T>(item);
        }

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
                throw new AssertAllException(exceptions);
        }

        public static AssertThatAction ThatCode(Action action) => new AssertThatAction(action);

        public static AssertThatFunction<T> ThatCode<T>(Func<T> func) => new AssertThatFunction<T>(func);

        public static AssertThatActionAsync ThatAsyncCode(Func<Task> func) => new AssertThatActionAsync(func);

        public static AssertThatFunctionAsync<T> ThatAsyncCode<T>(Func<Task<T>> func) => new AssertThatFunctionAsync<T>(func);
    }
}
