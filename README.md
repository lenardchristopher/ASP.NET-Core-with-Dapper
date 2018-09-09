# AdoAspDotNetCoreTest

## Why
I want to build an ASP.NET Core Web API with performance as the primary focus. Almost every ASP.NET Core data layer tutorial uses Entity Framework Core. EF is is a large ORM, which has lower
performance levels compared to micro-ORMs like ADO.NET and Dapper. Both EF and Dapper are built on ADO.NET, but Dapper's footprint is very small. EF is mostly bogged down by change tracking, which is 
baked into it's core functionality of `DbContext`. `DbContext` is essdentially a repository pattern and unit of work pattern in one.

## Overview
Using ASP.NET Core's built in Dependency Injection, I register `IEmployeeRepository` with a concrete implementation of `EmployeeRepository, which implements 
abstract class `SqlGenericRepository`. `SqlGenericRepository` is the concrete implementation to handle SQL data source data access. If Mongo were also
being used, then I would implement a `MongoGenericRepository`.

While `SqlGenericRepository`'s contract has all core repository methods, `IEmployeeRepository` is reserved for any Employee specific repo functions.
