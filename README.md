# EasyAsync
[![Build and Deploy](https://github.com/mehrandvd/EasyAsync/actions/workflows/build.yml/badge.svg)](https://github.com/mehrandvd/EasyAsync/actions/workflows/build.yml)
[![Build and Deploy](https://github.com/mehrandvd/EasyAsync/actions/workflows/publish-nuget.yml/badge.svg)](https://github.com/mehrandvd/EasyAsync/actions/workflows/publish-nuget.yml)
[![NuGet version (EasyAsync)](https://img.shields.io/nuget/v/EasyAsync.svg?style=flat)](https://www.nuget.org/packages/EasyAsync/)
[![NuGet downloads](https://img.shields.io/nuget/dt/EasyAsync.svg?style=flat)](https://www.nuget.org/packages/EasyAsync)

A library to make async even easier!

## Await Tuple
A tuple of tasks can be awaited and returns a tuple of results:

```csharp
var t1 = CountAsync();
var t2 = GetMessageAsync();

// You can await tuples directly!
var (count, message) = await (t1, t2);
```

## Await Enumerable
A tuple of tasks can be awaited and returns a tuple of results:

```csharp
var tasks = new List<Task>();
foreach (var item in items)
{
  var task = DoAsync(item);
  tasks.Add(task);
}

// You can await enumerables directly!
var results = await tasks;
```

## Forget Task
If you don't want to await on an async method, you can forget about it!

```csharp
DoAsync().Forget();
```

instead of 

```csharp
_ = DoAsync();
```

Using `Forget()` is better because you can still have exception handling by passing `onException` to `Forget`:

```csharp
StartAsync().Forget(onException: (exception) =>
                                 {
                                   // Handle the exception here...
                                 });
```
