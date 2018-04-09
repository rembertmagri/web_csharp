# C# ASP.NET MVC - Proof of Concept project

## Purpose
> To create an solution on Visual Studio to run a simple CRUD web application using:
 * Multitier architecture:
   * Data layer (Entity Framework)
   * Business layer
   * Service  layer (WCF)
   * Presentation layer:
     * [Pure MVC](#pure-mvc-project)
     * [MVC + jQuery and DataTables](#mvc--jquery--datatables)
     * [MVC + AngularJS](#mvc--angularjs)
 * Test-Driven Development (TDD) with an example of Unit Test project for the presentation layer
 * Dependency Injection (DI) with Unity to facilitate the unit test of each individual layer

## Solution Structure and Layer Division
> After creating the projects and setting their dependencies,
![](https://github.com/rembertmagri/web_csharp/blob/master/images/architecture%20code%20map.png?raw=true)

> the database and table were created and some rows were inserted.
![](https://github.com/rembertmagri/web_csharp/blob/master/images/database%20creation.png?raw=true)
![](https://github.com/rembertmagri/web_csharp/blob/master/images/table%20creation.png?raw=true)
![](https://github.com/rembertmagri/web_csharp/blob/master/images/table%20creation2.png?raw=true)
![](https://github.com/rembertmagri/web_csharp/blob/master/images/data%20creation.png?raw=true)

> Then, the Entity Framework model was created:
![](https://github.com/rembertmagri/web_csharp/blob/master/images/ef%20model%20creation.png?raw=true)
![](https://github.com/rembertmagri/web_csharp/blob/master/images/ef%20model%20creation2.png?raw=true)

> Connection string for the creation of the Entity Framework model (database first):

    Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False

Useful references:
* [Entity Framework](https://docs.microsoft.com/en-us/aspnet/entity-framework)
* [Calling WCF Services and Entity Framework in ASP.NET MVC Application](https://www.youtube.com/watch?v=H6MzA1KW3o0)

## Pure MVC project

> Text

Useful references:
* [Learn About ASP.NET MVC](https://www.asp.net/mvc)
* [Introduction to ASP.NET MVC in C#: Basics, Advanced Topics, Tips, Tricks, Best Practices, and More](https://www.youtube.com/watch?v=phyV-OQNeRM)
* [ASP.NET MVC 5 Step by Step: Part 3 Product Application Demo Project (CRUD Operation)](https://www.youtube.com/watch?v=NAKLrsvBC6g)

## MVC + jQuery + Datatables

> Text

Useful references:
* [jQuery](https://jquery.com/)
* [jQueryUI](https://jqueryui.com/)
* [DataTables](https://datatables.net/)

## MVC + AngularJS

> Text

Useful references:
* [AngularJS](https://angularjs.org/)
* [Introduction to AngularJS in 50 Examples - part 1](https://www.youtube.com/watch?v=TRrL5j3MIvo)
* [Introduction to AngularJS in 50 Examples - part 2](https://www.youtube.com/watch?v=6J08m1H2BME)

## Dependency Injection

> To allow the execution of unit tests on each layer, the Unity library was added to the MVC project. Dependency injection allows the presentation layer (controllers) to use registered services in runtime, thus enabling the tester to easily decouple the service layer from the presentation layer and use a mock service to reduce the scope of the unit tests.

> First, Unity was installed via NuGet:
![](https://github.com/rembertmagri/web_csharp/blob/master/images/unity_nuget.png?raw=true)

> Then, UnityConfig class was created. This class is responsible for registering the interfaces of the services that will be used by the controllers (in their constructors). The binding is done automatically in runtime by the Unity.Mvc5 library.
![](https://github.com/rembertmagri/web_csharp/blob/master/images/unity_config.png?raw=true)

> Finally, the Global.asax file was to be changed to include UnityConfig.RegisterComponents() method inside Application_Start.
![](https://github.com/rembertmagri/web_csharp/blob/master/images/unity_global_asax.png?raw=true)

> The controller has to be changed to require the IProductService in the constructor. The service will be inserted by Unity (in production environment) or programmatically in the unit tests.
![](https://github.com/rembertmagri/web_csharp/blob/master/images/unity_controller.png?raw=true)

Useful references:
* [Dependency Injection with Unity](https://www.c-sharpcorner.com/article/dependency-injection-in-asp-net-mvc-5/)

## Unit Test

> In order to approximate this project even further with a real-world scenario, a new project was created to allow the execution of unit tests and thus simulate a Test-Driven Development methodology, commonly used amongst IT departments in the industry today. POC_UnitTest project was created inside the solution, and references to 

Useful references:
* [TDD - Test-Driven Development](https://msdn.microsoft.com/en-us/library/ff847525(v=vs.100).aspx)



## Conclusion

This project demonstrated the differences when using MVC only to develop the presentation layer of a web application and when using some of the most popular javascript libraries, such as jQuery with Datatables and AngularJS.
