# ASP.NET Core with Dapper

## Why
The majority of Microsoft documentation recommends using Entity Framework (EF) as an ORM, which provides a code first approach to development. Unfortunately, [EF has a lot of overhead as an ORM](https://github.com/StackExchange/Dapper), whereas Dapper is an average of twice as fast as EF. I created this project to explore what implementing a Dapper Data Access Layer would look like.

## Overview
Using ASP.NET Core's built-in dependency injection, I registered `EmployeeRepository` as the concrete implementation of `IEmployeeRepository`. `EmployeeRepository` implements the abstract class `SqlGenericRepository`. The plan is for `SqlGenericRepository` to contain all the CRUD repository methods, while `IEmployeeRepository` is reserved for any Employee specific repo functions.

## [Update 12/16/18]
I tried using this architecture in other projects. The realworld has changed my thoughts on how I designed this. `SqlGenericRepository` is annoying to implement when you want a lightweight repository or unique customizations. Ultimately, I changed `SqlGenericRepository` to `SqlRepository`, with it only having the responsibility of opening the SQL Connection. Any concrete repository that uses SQL as a data store extends `SQLRepository`.

If you want to use another data store or multiple, simply follow the pattern with a `MongoRepository`, `XmlRepository`, etc.
