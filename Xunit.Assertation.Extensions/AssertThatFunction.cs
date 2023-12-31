﻿using System;
using Xunit.Assertation.Extensions.Exceptions;

namespace Xunit.Assertation.Extensions
{
    public class AssertThatFunction<T>
    {
        public Func<T> Func { get; }

        public AssertThatFunction(Func<T> func)
        {
            Func = func ?? throw new ArgumentNullException(nameof(func));
        }

        public AssertThatFunction<T> Throws<TException>() where TException : Exception
        {
            try
            {
                Func.Invoke();
            }
            catch (TException)
            {
                return this;
            }
            catch (Exception ex)
            {
                throw new ThrowsWrongExceptionTypeException<TException>(ex);
            }

            throw new ThrowsAssertationException();
        }

        public AssertThatFunction<T> Throws<TException>(Predicate<Exception> predicate) where TException : Exception
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            try
            {
                Func.Invoke();
            }
            catch (TException ex)
            {
                if (predicate(ex))
                    return this;
            }
            catch (Exception ex)
            {
                throw new ThrowsWrongExceptionTypeException<TException>(ex);
            }

            throw new ThrowsAssertationException();
        }

        public AssertThatFunction<T> Throws()
        {
            try
            {
                Func.Invoke();
            }
            catch (Exception)
            {
                return this;
            }

            throw new ThrowsAssertationException();
        }

        public AssertThatFunction<T> Throws(Predicate<Exception> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            try
            {
                Func.Invoke();
            }
            catch (Exception ex)
            {
                if (predicate(ex))
                    return this;
            }

            throw new ThrowsAssertationException();
        }

        public AssertThatFunction<T> DoesNotThrowException()
        {
            try
            {
                Func.Invoke();
            }
            catch (Exception ex)
            {
                throw new DoesNotThrowAssertationException(ex);
            }

            return this;
        }

        public AssertThatFunction<T> Returns(T expectedResult)
        {
            var result = Func.Invoke();

            return result.Equals(expectedResult)
                ? this
                : throw new ReturnsWrongResultException<T>(expectedResult, result);
        }
    }
}
