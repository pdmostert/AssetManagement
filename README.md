# Overview

**Asset Manager** is my Console Asset Management Application.

The purpose of this application is to manage assets in a company. The application allows the user to add, delete, and view assets. The user can also check out and check in assets. The application also allows the user to see the history of the asset.

The development fundamentals of this application will allow me to showcase the use of classes, objects, methods, and properties in C# as well as loops and conditional statements.

For this project I used the Clean Architecture pattern. The application is divided into three layers: Core, Infrastructure, and Presentation. The Core layer contains the business logic of the application. The Infrastructure layer contains the data access logic of the application. The Presentation layer contains the user interface logic of the application.

I also used the Repository pattern to access the data in the application as well as CQRS (Command Query Responsibility Segregation) pattern to separate the read and write operations in the application with MediatR.



[Software Demo Video]()

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

# Future Work

- Connect application to SQL database to store assets and history.
- Create a Web Application for the Asset Manager.