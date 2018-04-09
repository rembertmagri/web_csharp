# C# ASP.NET MVC - Proof of Concept project

## Purpose
> To create an MVC project on Visual Studio to run a simple CRUD web application using:
 * Multitier architecture:
   * Data layer (Entity Framework)
   * Business layer
   * Service  layer (WCF)
   * Presentation layer:
     * [Pure MVC](#pure-mvc-project)
     * [MVC + jQuery and DataTables](#mvc--jquery--datatables)
     * [MVC + AngularJS](#mvc--angularjs)

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

## Unit Test

> Text

Useful references:
* [TDD - Test-Driven Development](https://msdn.microsoft.com/en-us/library/ff847525(v=vs.100).aspx)

## Conclusion

This project demonstrated the differences when using MVC only to develop the presentation layer of a web application and when using some of the most popular javascript libraries, such as jQuery with Datatables and AngularJS.
