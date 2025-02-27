## La chaîne de certificats a été fournie par une autorité qui n’est pas approuvée)
TrustServerCertificate=True

## code first migration
dotnet ef migrations add InitialCreate

## install first tool
dotnet tool install --global dotnet-ef --version 9.*

## Unit Testing XUnit
dotnet new xunit -n MyApi.Tests
dotnet add reference ../MyApi/MyApi.csproj


dotnet add package xunit
dotnet add package Microsoft.AspNetCore.Mvc.Testing
dotnet add package Moq

dotnet new sln -n MySolution
dotnet sln add MyApi/MyApi.csproj
dotnet sln add MyApi.Tests/MyApi.Tests.csproj


## Mock data



### Separation of Concerns 

🏗 Steps to Add a Service to Your ASP.NET Core Web API
Create the Service Interface (ISchoolService)
Implement the Service (SchoolService)
Register the Service in Dependency Injection (Program.cs)
Modify the Controller to Use the Service




