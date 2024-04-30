# Overview

**Asset Manager** is my Console Asset Management Application.

The purpose of this application is to manage assets in a company. The application allows the user to add, delete, update and view assets. 

The development fundamentals of this application will allow me to showcase the use of classes, objects, methods, and properties in C# as well as loops and conditional statements.

For this project I used the Clean Architecture pattern. The application is divided into three layers: Core, Infrastructure, and Presentation. The Core layer contains the business logic and domain models of the application. The Infrastructure layer contains the data access logic of the application or external concerns. The Presentation layer contains the user interface logic of the application. The motivation for this design is to separate the concerns of the application and make it easier to maintain and test. It is also less complicated to change the front end or the database of the application without affecting the other layers.

I also used the Repository pattern to access the data in the application as well as CQRS (Command Query Responsibility Segregation) pattern to separate the read and write operations in the application with MediatR. This application might not be the best suited for CQRS but I wanted to practice the pattern.



[Software Demo Video](https://youtu.be/fcmdIBgdGb4)

# Development Environment

* Visual Studio 2022
* C# and .NET 8
* Git / Github

# Packages

* MediatR
* Newtonsoft.Json

# Useful Websites

- [Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/csharp/))
- [W3 Schools](https://www.w3schools.com/cs/index.php)
- [CQRS by Martin Fowler](https://martinfowler.com/bliki/CQRS.html)

# Future Work

- Connect application to SQL database to store assets and history.
- Create a Web Application for the Asset Manager.
- Export asset data in a CSV file.