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
* MS SQL Developer Edition

# Packages

* MediatR
* Newtonsoft.Json
* Dapper ORM

# Useful Websites

- [Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/csharp/))
- [W3 Schools](https://www.w3schools.com/cs/index.php)
- [CQRS by Martin Fowler](https://martinfowler.com/bliki/CQRS.html)


## Connect application to SQL database to store assets and history.

For this refactoring of the application I have extended the application to use a SQL database to store the assets details. To this end building the initial project with a clean architecture patterns has made this refactoring easier. The use if interfaces at integration points has also made it easier to swap out the data access layer with a SQL database. The application layer and domain layer was not affected by the change in the data access layer.

During my research phase I identified for C# that there are two mainstream ORM libraries that are used to access SQL databases. These are Entity Framework and Dapper. I chose to use Dapper because it is a lightweight ORM and is faster than Entity Framework. Dapper is also easier to use and has a lower learning curve than Entity Framework. Dapper is also more flexible than Entity Framework and allows for more control over the SQL queries that are executed.

As part of this refactoring, I have adjusted the AssetDbContext to use Dapper ORM to access the SQL database. I have also created a new repository for the assets and the asset history. The repository is responsible for the CRUD operations of the assets and the asset history. The repository is also responsible for the queries to the database. The repository is injected into the AssetService class which is responsible for the business logic of the application. This new repository makes used of SQL queries to perform the CRUD and Summary operations on the database.

## Useful Websites
- [Learn Dapper](https://www.learndapper.com/)
- [Dapper Github](https://github.com/DapperLib/Dapper)

[Software Demo for SQL refactoring](https://youtu.be/xkzQwVxwZmo)


# Future Work

- Create a Web Application for the Asset Manager.
- Export asset data in a CSV file.