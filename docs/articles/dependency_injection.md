# Dependency Injection

In some cases, classes should not directly create an instance of the `SectionsParser` class, because if you change the implementation, you will have to make changes in the classes that depend on `SectionsParser`.

**Example:**
```cs
class Foo
{
    private SectionsParser parser;

    public Foo()
    {
        parser = new SectionsParser();
    }
}

class Bar
{
    private SectionsParser parser;

    public Bar()
    {
        parser = new SectionsParser();
    }
}
```
The classes `Foo` and `Bar` create the instance in the constructor, this makes it difficult to reverse the dependency. In the future you could create a new class that inherits from `SectionsParser` (if you read the previous article, you will understand what I mean) and this would cause changes in two classes: `Foo` and `Bar`:
```cs
class Foo
{
    private SectionsParser parser;

    public Foo()
    {
        // change #1
        parser = new CustomParser();
    }
}

class Bar
{
    private SectionsParser parser;

    public Bar()
    {
        // change #2
        parser = new CustomParser();
    }
}
```

So to avoid those changes in the future, you can make use of Dependency Injection:
```cs
class Foo
{
    private SectionsParser parser;

    public Foo(SectionsParser parser)
    {
        this.parser = parser;
    }
}

class Bar
{
    private SectionsParser parser;

    public Bar(SectionsParser parser)
    {
        this.parser = parser;
    }
}
```
You can also make use of the `ISectionsParser` interface instead of the base `SectionsParser` class:
```cs
//To import the interface.
using SeztionParser.Interfaces;

class Foo
{
    private ISectionsParser parser;

    public Foo(ISectionsParser parser)
    {
        this.parser = parser;
    }
}

class Bar
{
    private ISectionsParser parser;

    public Bar(ISectionsParser parser)
    {
        this.parser = parser;
    }
}
```
You probably don't want to inject the dependency manually, as in this example:
```cs
class Program
{
    static void Main(string[] args)
    {
        var foo = new Foo(new SectionsParser());
        var bar = new Bar(new CustomParser());
        //...
    }
}
```
So in the end we would consider using a service container to handle dependency injection. Microsoft has created a [package](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection) in NuGet specifically for this.

The above example could be done in this way using the container DI:
```cs
// import all types.
using Microsoft.Extensions.DependencyInjection;
using SeztionParser.Interfaces;
using SeztionParser.Providers;

class Program
{
    static void Main(string[] args)
    {
        IServiceCollection services = new ServiceCollection();
        // Register services.
        services.AddTransient<ISectionsParser, SectionsParser>()
            .AddTransient<Foo>()
            .AddTransient<Bar>();
        // Creates the service container.
        ServiceProvider serviceProvider = services.BuildServiceProvider();
        // Retrieves an instance of the service and the container resolves the dependencies.
        var foo = serviceProvider.GetRequiredService<Foo>();
        var bar = serviceProvider.GetRequiredService<Bar>();
        /*
            more code...
        */
        serviceProvider.Dispose();
    }
}
```
**Note:** You can read more about it at this [link](https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection).