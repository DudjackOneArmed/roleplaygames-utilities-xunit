# xunit.assertation.extensions
---

That library extend xunit.assertation libraies class ```Assert``` with new methods like ```Assert.That(...)``` That library is made to simplify assertation in xunit. New methos does not replace standard ```Assert``` class mehtod, so you can use both, but I recommed to use one of it.

## How to use it
---

The simple assertation usage:

```sh
object obj = ...

Assert.That(obj)
	.IsNotNull()
	.IsEqualTo(obj);
```

## Extension methods
---

```Assert``` class extension methods in library:

- ```Assert.That(...)``` - contains methods to assert single value.
- ```Assert.ThatCollection(...)``` - contains methods to assert collection values.
- ```Assert.ThatCode(...)``` - contains methods to assert code behavior or result.
- ```Assert.ThatAsyncCode(...)``` - contains methods to assert async code behavior or result.
- ```Assert.All(...)``` - gets assertation expressions in params, than invoke each expressions and shows all assertation exceptions.

### Assert.That()
---

```Assert.That(obj)``` returns instance of assertation class that contains simple checks for ```obj```. For example:

```sh
// Act
var result = ...

// Assert
Assert.That(result).IsNotNull();
Assert.That(result.Amount).IsEqualTo(amount);
```

### Assert.ThatCollection()
---

```Assert.ThatCollection(collection)``` returns instance of assertation class that contains checks for ```collection```. For example:

```sh
// Act
var resultCollection = ...

// Assert
Assert.ThatCollection(resultCollection)
	.HasCount(expectedCount)
	.Any(x => x.ID == firsrtID && x.Amount == firstAmount)
	.Any(x => x.ID == secondID && x.Amount == secondAmount)
	.OrderedByDescending(x => x.Date);
```

Also ```Assert.ThatCollection(collection)``` contains methods for each ```collection``` element assertations:

- ```ForEach(x => ...)``` - gets lambda for each elements of ```collection```
- ```AssertForEach(x => ...)``` - gets lambda for each ```Assert.That(...)``` for each element of ```collection```

### Assert.ThatCode()
---

```Assert.ThatCode(() => DoSomething())``` returns instance of assertation class that contains checks for ```DoSomething()```. For example:

```sh
// Arrange
void DoSomething()
{
	...
}

// Act & Assert
Assert.ThatCode(() => DoSomething())
	.Throws<ArgumentOutOfRangeException>();
```

```Assert.ThatCode(() => DoSomething())``` contains next methods:

- ```Throws()```or ```Throws<TException>()```
- ```DoesNotThrowException()```
- ```Returns()``` - for functions

### Assert.ThatAsyncCode()
---

```Assert.ThatAsyncCode(() => DoSomethingAsync())``` returns instance of assertation class that contains checks for ```DoSomethingAsync()```. For example:

```sh
// Arrange
Task DoSomethingAsync()
{
	...
}

// Act & Assert
Assert.ThatAsyncCode(() => DoSomethingAsync())
	.Throws<ArgumentOutOfRangeException>();
```

```Assert.ThatAsyncCode(() => DoSomethingAsync())``` contains next methods:

- ```Throws()```or ```Throws<TException>()```
- ```DoesNotThrowException()```
- ```Returns()``` - for functions

### Assert.All()
---

```Assert.All(() => FirstCheck(), () => SecondCheck())``` does all params checks before to throw exception. For example:

```sh
// Arrange
var result = ...

// Assert
Assert.All(
	() => Assert.That(result.Message).IsEqualTo(expectedMessage),
	() => Assert.That(result.Date).IsEqualTo(expecteDate),
	() => Assert.That(result.Level).IsType<InfoLevel>(),
	() => Assert.That(result.Service).IsSame(expectedService));
```

## How to install to test project
---

Unfortunately you cannot use it with standard xunit test project. You need change some package first.
When you create simple xunit test project you have next two libraries form xunit:

- [xunit](https://www.nuget.org/packages/xunit)
- [xunit.runner.visualstudio](https://www.nuget.org/packages/xunit.runner.visualstudio)

To use our library you need to remove xunit library and install next libraries instead:

- [xunit.core](https://www.nuget.org/packages/xunit.core)
- [xunit.analyzers](https://www.nuget.org/packages/xunit.analyzers)
- [xunit.assertations.extensions](https://www.nuget.org/packages/xunit.assertation.extensions)

On the other hand you can remove [xunit](https://www.nuget.org/packages/xunit) library and just install [xunit.extended](https://www.nuget.org/packages/xunit.extended) library instead.
