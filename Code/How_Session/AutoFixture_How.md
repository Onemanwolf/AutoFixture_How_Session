# AutoFixture

[Docs](https://github.com/AutoFixture/AutoFixture)

## What is AutoFixture

### AutoFixture Defined

AutoFixture
AutoFixture is an open source library for .NET designed to minimize the 'Arrange' phase of your unit tests in order to maximize maintainability. Its primary goal is to allow developers to focus on what is being tested rather than how to setup the test scenario, by making it easier to create object graphs containing test data.

## Why Use AutoFixture

- Simplify the Arrange phase of tests
- Writing Less Test Code
- Improving Test Maintenance
- Anonymous Test Data and Object
- Less Brittle Test

## Getting Started With AutoFixture

## Clone Code and Create Test Project

1. Create folder Open Command Prompt and make dir AutoFixture_How_Session.

```console
C:\Users\tioleson>md AutoFixture_How_Session

```

2. Clone the repo from [AutoFixture_How_Session](https://github.com/Onemanwolf/AutoFixture_How_Session)

3. Open the DemoCode Solution.

4. Now the open DemoCode.Test project and open the TypeJoinerShould class.

5. Examine the TypeJoinerJoinTypeString test method.

```C#
        public void TypeJoinerJoinTypeString()
        {
            var sut = new TypeJoiner<string>();

            var valueOne = "Tim";
            var valueTwo = "Oleson";
            var expected = valueOne + " " + valueTwo;

            sut.Join(valueOne, valueTwo);

            sut.Joined.Should().Be(expected);

        }

```

## Install AutoFixture

First we need the NuGet Packages.

You can add the packages to the project file by double clicking it and pasting in below into the Item Group and the save project file. The packages will be installed for you.

```XML

<ItemGroup>
      <PackageReference Include="AutoFixture" Version="4.15.0" />
         <PackageReference Include="FluentAssertions" Version="5.10.3" />


</ItemGroup>
```

Or you can do it with the NuGet Package Manager

1. Right click on the Test project and select Manage NuGet packages... then goto the Browse textbox and paste or type in AutoFixture.

```C#
       using AutoFixture;
```

2. Now lets add FluentAssertions NuGet package to the project

```C#
      using FluentAssertions;
```

Note Examine the namespace:

```C#
        namespace AutoFixture
{
    //
    // Summary:
    //     Provides object creation services.
    public class Fixture : IFixture, ISpecimenBuilder, IEnumerable<ISpecimenBuilder>, IEnumerable
    {
        //
        // Summary:
        //     Initializes a new instance of the AutoFixture.Fixture class.
        public Fixture();
        //
        // Summary:
        //     Initializes a new instance of the AutoFixture.Fixture class with the supplied
        //     engine parts.
        public Fixture(DefaultRelays engineParts);
        //
        // Summary:
        //     Initializes a new instance of the AutoFixture.Fixture class with the supplied
        //     engine and a definition of what 'many' means.
        //
        // Parameters:
        //   engine:
        //     The engine.
        //
        //   multiple:
        //     The definition and implementation of 'many'.
        public Fixture(ISpecimenBuilder engine, MultipleRelay multiple);

        public IList<ISpecimenBuilderTransformation> Behaviors { get; }
        public IList<ISpecimenBuilder> Customizations { get; }
        //
        // Summary:
        //     Gets the core engine of the AutoFixture.Fixture instance.
        //
        // Remarks:
        //     This is the core engine that drives a AutoFixture.Fixture instance. Even with
        //     no AutoFixture.Fixture.Customizations or AutoFixture.Fixture.ResidueCollectors,
        //     the AutoFixture.Fixture.Engine should be capably of resolving a wide range of
        //     different requests, based on conventions.
        public ISpecimenBuilder Engine { get; }
        public bool OmitAutoProperties { get; set; }
        //
        // Summary:
        //     Gets or sets a number that controls how many objects are created when a AutoFixture.Fixture
        //     creates more than one anonymous objects.
        public int RepeatCount { get; set; }
        public IList<ISpecimenBuilder> ResidueCollectors { get; }

        public ICustomizationComposer<T> Build<T>();
        public object Create(object request, ISpecimenContext context);
        public IFixture Customize(ICustomization customization);
        public void Customize<T>(Func<ICustomizationComposer<T>, ISpecimenBuilder> composerTransformation);
        //
        // Summary:
        //     Gets an enumerator over the internal specimen builders used to create objects.
        //
        // Returns:
        //     An enumerator over the internal specimen builders used to create objects.
        [IteratorStateMachine(typeof(<GetEnumerator>d__27))]
        public IEnumerator<ISpecimenBuilder> GetEnumerator();
    }
}
```

# Create Anonymous Test Data and Object with AutoFixture

## Anonymous Test Data

**Data that is required to be present for the test to be able to execute, but where the value itself is unimportant.**

### Supported Frame Works

- Nunit
- xUnit.net
- MSTest
- Fixie

AutoFixture is independent of the testing framework or test runner

### Testing framework specific packages

- AutoFixture.Xunit
- AutoFixture.Xunit2
- AutoFixture.Nunit2
- AutoFixture.Nunit3

### Frameworks

- .Net Standard 1.5, 2.0
- .Net Framework 4.5.2 up

## AutoFixture offers packages that provide deeper integration with testing frameworks

### NuGet Packages

- AutoFixture
- AutoFixture.SeedExtensions
- AutoFakeItEasy
- AutomFoq
- AutoMoq
- AutoNSubstitute
- AutoRhinoMock
- Idioms
- Idimos.FsCheck

You can create anonymous test data without having to manually create Fixture instance.

Example;

```C#
         public class ProcessBufferShould
    {

        // Add Properties for Arrange Code and Fixture Class as demonstrated below
        IBuffer<double> _buffer { get; set;}
        Fixture _fixture { get; set;}
        ProcessBuffer<double> _sut { get; set;}


        public ProcessBufferShould()
        {
            _sut = new ProcessBuffer<double>();
            _fixture = new Fixture();
            _buffer = _fixture.Create<Buffer<double>>();
        }
```

Now refactor the test are first test method TypeJoinerJoinTypeString using AutoFixtures Fixture class.

```C#
        public void TypeJoinerJoinTypeString()
        {
            var sut = new TypeJoiner<string>();

            var valueOne = "Tim";
            var valueTwo = "Oleson";
            var expected = valueOne + " " + valueTwo;

            sut.Join(valueOne, valueTwo);

            sut.Joined.Should().Be(expected);

        }

```

1. We will refactor our test by implementing the Fixture class `var fixture = new Fixture();`

```C#
        public void TypeJoinerJoinTypeString()
        {
            var sut = new TypeJoiner<string>();
            var fixture = new Fixture();
            var valueOne = "Tim";
            var valueTwo = "Oleson";
            var expected = valueOne + " " + valueTwo;

            sut.Join(valueOne, valueTwo);

            sut.Joined.Should().Be(expected);

        }

```

2. Now lets lose the literal assignments with `fixture.Create<string>();`

```C#
        public void TypeJoinerJoinTypeString()
        {
            var sut = new TypeJoiner<string>();
            var fixture = new Fixture();
            var valueOne = fixture.Create<string>();
            var valueTwo = fixture.Create<string>();
            var expected = valueOne + " " + valueTwo;

            sut.Join(valueOne, valueTwo);

            sut.Joined.Should().Be(expected);

        }

```

Nice work now we have a test that is less brittle and use anonymous data instead of literal values.

### Anonymous Values Rules of the road

- Use anonymous values only when they don't have a specific meaning to the SUT.

- A given test must execute the same production code every time it is executed.

- Anonymous values should not affect logical program flow.

> "For input where the value holds a particular meaning in the context of the SUT,
> you will still need to hand-pick values as always. E.g. if the input is expected to
> be an XML string conforming to a particular schema ,a GUID string makes no sense"
> _**Mark Seemann**_ > [Blog](https://blog.ploeh.dk/2009/03/05/ConstrainedNon-Determinism)

_If you haven't now would be a good time to Install NuGet Package AutoFixture.SeedExtensions_

### Anonymous Types

- Create anonymous strings
- Create anonymous numbers
- Create anonymous dates and times
- Generating Enum and GUIDs
- Generating email address
- Creating sequences of anonymous values
- Creating anonymous instance of custom types
- Creating complex anonymous object graphs
- Creating object with DataAnnotations

### Create anonymous strings

Example:

```C#
        var fixture = new Fixture();
        var firstName = fixture.Create<string>();
        var lastName = fixture.Create<string>();

sut.Fullname.Should().Be(firstName + ' ' + lastName)
```

### Create anonymous numbers

```C#
        var fixture = new Fixture();`
        var firstName = fixture.Create<decimal>();

```

`var fixture = new Fixture();`
`var firstName = fixture.Create<decimal>();`

```C#
        byte b  =  fixture.Create<byte>();
        double d  =  fixture.Create<double>();
        short s =  fixture.Create<short>();
        long l  =  fixture.Create<long>();
        sbyte sb  =  fixture.Create<sbyte>();
        float f  =  fixture.Create<float>();
        ushort us  =  fixture.Create<ushort>();
        int i  =  fixture.Create<int>();
        ulong f  =  fixture.Create<ulong>();

```

### Create anonymous dates and times

```C#
        DateTime dateTime = fixture.Create<DateTime>();

```

1. Create `LogMessageCreatorShould` test class

```C#
        public class LogMessageCreatorShould
    {


    }
}

```

We will be testing this method which requires a string and a DateTime as parameters.

```C#

        public LogMessage Create(string message, DateTime when)
        {
            return new LogMessage
            {

                Year = when.Year,
                message = message
            };
        }
```

2. Create test method lets call it `CreateLogMessage`.

```C#
        [Fact]
        public void CreateLogMessage()
        {
            var sut = new LogMessageCreator();

            DateTime logTime = new DateTime(2020, 9, 3);

            LogMessage result = sut.Create("I want a sandwhich", logTime);


            Assert.Equal(logTime.Year, result.Year);


        }

```


Create DateTime

```C#
       [Fact]
        public void CreateLogMessage()
        {
            var sut = new LogMessageCreator();
            var fixture = new Fixture();

            //Add anonymous date time
            DateTime logTime = fixture.Create<DateTime>();


            //Add anonymous string
            LogMessage result = sut.Create(fixture.Create<string>(), logTime, Id);


            Assert.Equal(logTime.Year, result.Year);
            result.Year.Should().Be(logTime.Year);
            result.MessageType.Should().Be(type);
        }


````

### Generating Enum and GUIDs

1. Add Guid Id Property to the `LogMessage` class.

```C#

        public class LogMessage
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public string message { get; set; }

    }

```

Add the parameter for the Guid Id to the Create method.

```C#
         public LogMessage Create(string message, DateTime when, Guid Id)
        {
            return new LogMessage
            {
                Id = Id,
                Year = when.Year,
                message = message
            };
        }

```

```C#
       [Fact]
        public void CreateLogMessage()
        {
            var sut = new LogMessageCreator();
            var fixture = new Fixture();
            // DateTime logTime = new DateTime(2020, 9, 3);
            DateTime logTime = fixture.Create<DateTime>();

            //Add Id Guid
            var Id = fixture.Create<Guid>();

            LogMessage result = sut.Create(fixture.Create<string>(), logTime, Id);


            Assert.Equal(logTime.Year, result.Year);
            result.Year.Should().Be(logTime.Year);
            result.MessageType.Should().Be(type);
        }


```

Add Enum MessageType to the LogMessage Class

```C#
         public enum MessageType
    {
        Unspecified,
        NoOp,
        Failure,
        Success,
        Exception
    }
```

```C#

        public class LogMessage
    {
        public Guid Id { get; set; }
        public MessageType MessageType {get; set;}
        public int Year { get; set; }
        public string message { get; set; }

    }
```

```C#
       [Fact]
        public void CreateLogMessage()
        {
            var sut = new LogMessageCreator();
            var fixture = new Fixture();
            // DateTime logTime = new DateTime(2020, 9, 3);
            DateTime logTime = fixture.Create<DateTime>();
            //LogMessage result = sut.Create("I want a sandwich", logTime);

            //Add Id Guid
            var Id = fixture.Create<Guid>();


            //Add Message Type
            var type = fixture.Create<MessageType>();
            LogMessage result = sut.Create(fixture.Create<string>(), logTime, Id, type);


            Assert.Equal(logTime.Year, result.Year);
            result.Year.Should().Be(logTime.Year);
            result.MessageType.Should().Be(type);
        }


```

```C#
        public LogMessage Create(string message, DateTime when, Guid Id, MessageType type)
        {
            return new LogMessage
            {
                Id = Id,
                MessageType = type,
                Year = when.Year,
                message = message
            };
        }
```

```C#

public class LogMessage
    {
        public Guid Id { get; set; }
        public MessageType MessageType {get; set;}
        public int Year { get; set; }
        public string message { get; set; }

    }

```

## Create Email address with AutoFixture

1. Now lets create a Email Message Class right click add new class name it `EmailMessage.cs`.

```C#

                 public class EmailMessage
                 {
                 public Guid Id { get; set; }
                 public string ToAddress { get; set; }
                 public string FromAddress { get; set; }
                 public string Subject { get; set; }
                 public string Body { get; set; }
                 public bool IsImportant { get; set; }


                 public EmailMessage(Guid id,
                            string toAddress,
                            string fromAddress,
                            string subject,
                            string body,
                            bool isImportant)
                {
                  Id = id;
                  ToAddress = toAddress;
                  FromAddress = fromAddress;
                  Subject = subject;
                  Body = body;
                  IsImportant = isImportant;
                }



         }

```

2. Now add a test class to the test project call it EmailMessageShould.

```C#
                public class EmailMessageShould
                {


                }

```

3. Next we need to test we can construct an email message with all the parameters created with AutoFixture we will focus on Email Address for now we need the `using System.Net.Mail;` to we can use `MailAddress`.

```#
                using System.Net.Mail;
```
4. Install NuGet Package AutoFixture.SeedExtensions Will be used to seed the Email message with a string if you don't install you get a compile error.

5. Add the to address for the email with by first creating it with `MailAddress toAddress = fixture.Create<MailAddress>();`.

6. Now add the from address in the same way `MailAddress fromAddress = fixture.Create<MailAddress>();`
   `
7. Now add the rest of the constructor parameters Id with ` var Id = fixture.Create<Guid>();` the subject with `and the message body with` finally the IsImportant bool with `` now assert all your values.

> Challenge try different ways of using the fixture how could you improve this test?

> Notice the use of the AutoFixture.SeedExtensions ` fixture.Create<string>("Subject"),` by adding the string `"Subject"`create string fixture method prepends and string to the auto generated string.

```C#
                public class EmailMessageShould
                {

                    [Fact]
                    public void EmailMessageCreate()
                    {
                        var fixture = new Fixture();


                        MailAddress toAddress = fixture.Create<MailAddress>();
                        MailAddress fromAddress = fixture.Create<MailAddress>();

                        var Id = fixture.Create<Guid>();
                        var sut = new EmailMessage(
                            Id,
                            toAddress.Address,
                            fromAddress.Address,
                            fixture.Create<string>("Subject"),
                            fixture.Create<string>("Body"),
                            fixture.Create<bool>());

                        sut.Id.Should().Be(Id);
                        sut.ToAddress.Should().Be(toAddress.Address);
                        sut.FromAddress.Should().Be(fromAddress.Address);
                        sut.Subject.Should().Contain("Subject");
                        sut.Body.Should().Contain("Body");


                }

```

## Create Sequence of String

1. Lets create a new test Class in the test project just to play with some examples and call it `SequenceDemoShould.cs`.

```C#
         public class SequenceDemoShould
    {

    }
```

2. Now create a new test method call it `SequenceOfStrings`.

```C#

        [Fact]
        public void SequenceOfStrings()
        {
            var fixture = new Fixture();
            IEnumerable<string> list = fixture.CreateMany<string>();

            var listCount = list;

            listCount.Should().HaveCount(3);

        }
```

Autofixture be default adds a count of 3 we can specify and count by adding count number to the `CreateMany<string>(6);`

```C#

        [Fact]
        public void SequenceOfStrings()
        {
            var fixture = new Fixture();
            IEnumerable<string> list = fixture.CreateMany<string>(6);

            var listCount = list;

            listCount.Should().HaveCount(6);

        }
```

Now Create another test method called `SequenceOfStringsAddToList`

We can also add string to an existing list with the `fixture.AddManyTo(list);` method.

```C#
        [Fact]
        public void SequenceOfStringsAddToList()
        {
             var fixture = new Fixture();
             var list = new List<string>();


             fixture.AddManyTo(list);

             list.Should().HaveCount(3);


        }
```

We can also control the count by adding

```C#
        [Fact]
        public void SequenceOfStringsAddToList()
        {
             var fixture = new Fixture();
             var list = new List<string>();


             fixture.AddManyTo(list, 10);

             list.Should().HaveCount(10);

        }
```

We can also use a delegate to set the value of items added to the list.

```C#
        [Fact]
        public void SequenceOfStringsAddToListLambda()
        {
            var fixture = new Fixture();
            var list = new List<string>();


            fixture.AddManyTo(list, () => "hi");

            list.Should().Contain("hi");
            list.Should().HaveCount(3);

        }
```

## Complex Object Creation

Lets explore object creation with AutoFixture but first we will need a test class so lets create a test class called `ComplexObjectCreationShould`

```C#
        public class ComplexObjectCreationShould
        {

        }

```

Add a new test method `CreateObject` to our test class.

We can create objects and provide values for construction.

```C#
        [Fact]
        public void CreateObject()
        {
            var fixture = new Fixture();
            var emailMessage = fixture.Create<EmailMessage>();

            emailMessage.Should().NotBeNull();
        }
```

Add a new test method `CreateComplexObject` to our test class.

We can create complex object let create a new test method to demostrate that.

```C#
        [Fact]
        public void CreateComplexObject()
        {
            var fixture = new Fixture();
            Order order = fixture.Create<Order>();

            order.Should().NotBeNull();

        }

```

Add a new test method `CreateObject` to our test class.
We can customize object creation lets explore the different method

```C#
 [Fact]
        public void CreateCustomObjects()
        {
            var fixture = new Fixture();

            Product product = fixture.Create<Product>();

        }

```

But the test failed why if we examine the code will see we have a constraint that is not being meet by the anonymous object we created.

We can address this issue with the `fixture.Inject<string>("PDO");`

```C#
[Fact]
        public void CreateCustomObjects()
        {
            var fixture = new Fixture();
            fixture.Inject<string>("PDO");
            Product product = fixture.Create<Product>();

        }

```

But when we debug the test we can see the `"PDO"` assignment to e

```C#

[Fact]
        public void CreateCustomObjectsWithProps()
        {
            var fixture = new Fixture();
            fixture.Inject(new Product
            {
                Id = 1,
                ProductCode = "PDO",
                ProductDate = DateTime.Now

            });
            Product product = fixture.Create<Product>();

        }

```

If we need to make sure we get a constant value assigned we can use the `fixture.Freeze<>()` Method

```C#
         [Fact]
        public void FreezingValues()
        {
            var fixture = new Fixture();

            var id = fixture.Freeze<int>();
            var customerName = fixture.Freeze<string>("CustomerName");

            var sut = fixture.Create<Order>();

            Assert.Equal(id + "-" + customerName, sut.ToString());

        }

```

We can Get even more control using the fluent `Build` pipeline and with can determine if a property is set or not set during the build, so lets create a new test method to try this out called `OmitSettingDuringBuild`.

```C#
        [Fact]
        public void OmitSettingDuringBuild()
        {
            var fixture = new Fixture();

            var product = fixture.Build<Product>()
                                 .Without<string>(x => x.ProductCode)
                                 .Create();

            product.ProductCode.Should().BeNull();
        }

```

We can Omit all properties if we need to by using the `.OmitAutoProperties()` let create a test method and see it in action.

```C#

[Fact]
        public void OmitAllProperties()
        {
            var fixture = new Fixture();

            var product = fixture.Build<Product>()
                                 .OmitAutoProperties()
                                 .Create();

            product.ProductCode.Should().BeNull();

        }

```

We can set properties at build time using the `..With(x => x.ProductCode, "PDO")`
lets create a test method called `CustomizeBuild` to try this out.

```C#
        [Fact]
        public void CustomizeBuild()
        {

            var fixture = new Fixture();

            var product = fixture.Build<Product>()
                                 .With(x => x.ProductCode, "PDO")
                                 .Create();

            product.ProductCode.Should().Be("PDO");
        }

```

We can preform actions on the object during build with the `.Do(x => x.OrderItems.Add(orderItem)` method like adding things to a list as in our next test method called `CustomizeBuildWithDo`.

```C#
         [Fact]
        public void CustomizeBuildWithDo()
        {

            var fixture = new Fixture();
            var orderItem = fixture.Create<OrderItem>();
            var order = fixture.Build<Order>()
                                 .With(x => x.Id, 23)
                                 .Do(x => x.OrderItems.Add(orderItem))
                                 .Create();

            order.Id.Should().Be(23);
        }

```

We can setup Customization prior to creation with the `fixture.Customize<T>()` are next test method we create called `CustomizeObjectsBuildWithCustomize` we can see this in action.

After we setup the Customize we then can create the object according to the prescribe customization we created each time a Order is created it will use the or customization

```C#
        [Fact]
        public void CustomizeObjectsBuildWithCustomize()
        {
            var fixture = new Fixture();
            var orderItem = fixture.Create<OrderItem>();
            fixture.Customize<Order>(o => o.With(x => x.Id, 23)
                                           .With(x => x.CustomerId, 2)
                                           .Do(x => x.OrderItems.Add(orderItem)));


            var order = fixture.Create<Order>();
            var order1 = fixture.Create<Order>();



        }

```

Debug test and observe the two orders.

We seen the power of AutoFixture but lets take a look at what is going on in the background.

## Fixture Pipeline

Specimen

An individual value for a specific data type used as an example of that data type.

For example 1 and 2 are specimens of int.

In the AutoFixture we can see this in the

```C#
public interface ISpecimenBuilder
{
        object Create(object request, ISpecimenContext context)
}

```

### Customizations

- Collection of ISpecimenBuilder
- "Override" default specimens builders
- Prebuilt & custom

### Default Specimen builder

- Engine
- Preconfigured in a Fixture instance
- Like when we create a Guid with the GuidGenerator specimen builder

Residue Collectors

- Lowest priority specimens builders
- Fall-back in no other matches
- Last chance before exception

A request goes through a chain of ISpecimenBuilders until a specimen is generated.

The request processing then stops and the specimen is returned to the test code.

![alt text](https://github.com/Onemanwolf/AutoFixture_How_Session/blob/master/Code/How_Session/images/PipelineImage.png?raw=true 'Request Pipeline')

Lets create customization fixture.

1. Add a new class to the test project call it `CustomProductCodeGenerator`.

2. Now Paste the below code into the class you can see we are using reflection and the AutoFixture Kernel.

```C#

using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture.Kernel;
using System.Reflection;

namespace DemoCode.Test
{
    public class CustomProductCodeGenerator : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            var propertyInfo = request as PropertyInfo;

            if (propertyInfo is null)
            {

                return new NoSpecimen();
            }

            var isProductCode = propertyInfo.Name.Contains("ProductCode");
            var isString = propertyInfo.PropertyType == typeof(string);


            if(isProductCode && isString)
            {
                return RandomProductCode();
            }

            return new NoSpecimen();
        }

        private string RandomProductCode()
        {  // code to produce Random Product Code  goes here ..
            return "PDO";
        }
    }
}

```

Now implement our new customization.

Add and new test method to the `ComplexObjectCreationShould` and call it
`CustomizeAddCustomFixture`.

```C#
[Fact]
        public void CustomizeAddCustomeFixture()
        {
            var fixture = new Fixture();

            fixture.Customizations.Add(new CustomProductCodeGenerator());


            var product = fixture.Create<Product>();




        }

```


## Auto Fixture Abstract Types

AutoFixture creates an object graph based on the public constructors of the types contained in that object graph.

This works well until you have a type that has no public constructor.

When you have a class that has a dependency on an Interface we handle this situatuion with the `Register` Method like in this example `fixture.Register<Interface>(() => new ConcertImplementation());`

For the below exercise create a interface we wiil place all of the memebers inside for demo purposes, add a interface called IMyInterface to DemoCode Project.

Replace the code with the following

```C#

 public interface IMyInterface
    {
        string results { get; set; }
        void Dosomething();
    }

    public class Myclass : IMyInterface
    {
        public string results { get; set; }

        public void Dosomething()
        {
            results = "Did something";
        }
    }

    public class MyClasseImplementsMyInterface
    {

        public IMyInterface _myClass;

        public MyClasseImplementsMyInterface(IMyInterface myclass)
        {
            _myClass = myclass;
        }

        public string DoSomething()
        {
           _myClass.Dosomething();
         return   _myClass.results;
        }
    }
```



1. Create test Class to the Test Project Called `AutoFixtureRegisterShould`.

2. Add Test Method `RegisterInterface`

```C#

        [Fact]
        public void RegisterInterface()
        {

        }

```

3. Add this code to the test method.

```C#

            var fixture = new Fixture();
            fixture.Register<IMyInterface>(() => fixture.Create<Myclass>());
            var myClass = fixture.Create<MyClasseImplementsMyInterface>();

            var results = myClass.DoSomething();

            results.Should().Be("Did something");

```

Now you can have AutoFixture Creeate the Dependency behaving much like a Dependency injection container.





