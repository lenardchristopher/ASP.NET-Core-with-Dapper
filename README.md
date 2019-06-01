# ASP.NET Core with Dapper

## Why
The majority of Microsoft documentation pushes Entity Framework (EF) as an ORM, which provides a code first approach to development. Unfortunately, [EF has a lot of overhead as an ORM](https://github.com/StackExchange/Dapper), whereas Dapper is twice as fast. I created this project to explore what implementing a Dapper Data Access Layer would look like.

## Overview
The goal of my architecture was to encapsulate any data access specific logic in the Repository layer of the app. I used the `Employee` object as an example. `EmployeeRepository` implements an abstract class which will dictate which data source it will use. In this case, it is using SQL (`SqlRepository`), but I also stubbed out Document and XML repositories.

`SqlRepository` (and all other abstract repositories) implements `IGenericRepository`, which is the minimum required contract for accessing the data source. The abstract repos implement the logic necessary to open a connection with the data sources, which they can easily get from the `DbConnectionFactory`. Finally, any extension methods that are unique to a model's repository can be implemented in an additional interface - which I demonstrate with `IEmployeeRepository`.
