Web API in C#
ASP.NET Identity is a membership system that allows you to manage user authentication and authorization in ASP.NET applications. It provides features such as user registration, login, role-based access control, two-factor authentication, and external authentication (Google, Facebook, etc.).
Key Features of ASP.NET Identity:
1. User Authentication & Authorization
   * Supports user registration and login.
   * Provides role-based and claims-based authorization.
2. Customizable User Store
   * Uses Entity Framework and can be customized to store additional user information.
3. External Authentication Providers
   * Supports login via Google, Facebook, Microsoft, and Twitter.
4. Two-Factor Authentication (2FA)
   * Enhances security by requiring an additional authentication step.
5. Token-Based Authentication
   * Supports OAuth and JWT for securing APIs.
6. Password Hashing & Security
   * Uses hashing algorithms for secure password storage.
________________


Components of ASP.NET Identity
1. IdentityUser – Represents a user in the system.
2. IdentityRole – Represents a role (e.g., Admin, User).
3. UserManager – Manages user-related operations (create, delete, update).
4. RoleManager – Manages role-related operations.
5. SignInManager – Handles user sign-in and authentication.


ASP.NET Web API & RESTful Services
ASP.NET Web API is a framework that allows you to build RESTful services in .NET. It supports HTTP verbs like GET, POST, PUT, PATCH, and DELETE to interact with resources.
________________


1. RESTful APIs (Examples)
In this tutorial, we will create the following RESTful APIs for our Product Store web application.
HTTP Methods in REST API
API
	Description
	Request body
	Response body
	GET /api/products
	Get all products
	None
	Array of Products
	GET /api/products/{id}
	Get a product by ID
	None
	Product
	POST /api/products
	Add a new product
	Product
	Product
	PUT /api/products/{id}
	Update a product
	Product
	None
	PATCH /api/products/{id}
	Partially update a resource
	Product
	

	DELETE /api/products/{id}
	Delete a product
	None
	None
	POST /api/upload
	Upload an image
	Image File
	Image URL
	

What is HttpClient?
HttpClient is a C# class in the System.Net.Http namespace used for sending HTTP requests and receiving HTTP responses from web servers. It is commonly used in ASP.NET Core and .NET applications to interact with RESTful APIs.
________________


Key Features of HttpClient
1. Supports HTTP Methods – GET, POST, PUT, PATCH, DELETE.
2. Asynchronous Requests – Uses async/await for non-blocking network calls.
3. Built-in JSON Serialization – Works with System.Net.Http.Json for automatic serialization.
4. Handles Timeouts & Errors – Can set request timeouts and handle errors gracefully.
5. Supports Reuse – It is designed to be reused rather than created per request (to avoid socket exhaustion).


Web API Documentation in C#
1. Introduction
This document provides a detailed overview of a Web API developed using C# and ASP.NET Core. It includes setup instructions, API endpoints, request and response formats, authentication methods, and error handling.
2. Prerequisites
* .NET SDK (latest version)
* Visual Studio or VS Code
* Postman or any API testing tool
* SQL Server (if database integration is required)


3. Setting Up the Web API
1. Open Visual Studio and create a new ASP.NET Core Web API project.
2. Configure the project settings and install necessary dependencies: 
3. dotnet add package Microsoft.AspNetCore.Mvc.Core
4. dotnet add package Microsoft.EntityFrameworkCore.SqlServer
5. Create the database and apply migrations using Entity Framework Core: 
6. dotnet ef migrations add InitialCreate
7. dotnet ef database update
8. Run the application using: 
9. dotnet run


4. API Controllers and Routes
Sample Controller: UsersController
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _userService.GetUsersAsync();
        return Ok(users);
    }
}
6. Request and Response Format
Request Example (POST /api/users)
{
  "name": "John Doe",
  "email": "john.doe@example.com"
}


Response Example (200 OK)
{
  “status” : 200,
  “message” : “YOUR_MESSAGE ”,
  “data”: 
  {
  "id": 1,
  "name": "John Doe",
  "email": john.doe@example.com
  }
}
















Steps to Setup your first WebAPI Application
7. Web API Project
7.1 Creating Project
1. Open Visual Studio.
2. Navigate to File → New Solution.
3. Select .NET Core → App → ASP.NET Core Web API, then click Next.
4. Specify the Project Name, Solution Name, and Location.
5. Click Create.
6. A solution and project will be created, with a default controller ValuesController in the project.
 image 



Specify the Project Name, Solution Name and Location, Create. image 

























One solution and one project are created. This Web API project is based on ASP.NET Core. There is one default controller ‘ValuesController’ in the new project
Note:-Packages should be above .Net 6 versions(Please make sure).
 image 











9. Conclusion
This document outlines the key components of the Web API. Further enhancements can include logging, caching, and role-based authentication.


TASK:-
UC1:- Create an API for User RegistrationSystem.
PROGRAM.CS:-
using BusinessLayer.Service;
using RepositoryLayer.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<UserRegistrationBL>();
builder.Services.AddScoped<UserRegistrationRL>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
	

userRegistrationRL.cs:-
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Service
{
   public class UserRegistrationRL
   {
       public string registrationRL(string username, string password)
       {
           return "Login Successful."; 
       }
   }
}
	

userRegistrationController.cs:-
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Service;

namespace UserRegistration.Controllers;

[ApiController]
[Route("[controller]")]
public class UserRegistrationController : ControllerBase
{
   UserRegistrationBL _userRegistrationBL;
   string username = "root";
   string password = "root";

   public UserRegistrationController(UserRegistrationBL userRegistrationBL)
   {
       _userRegistrationBL = userRegistrationBL;
   }

   [HttpGet]
   public string registration()
   {
       return _userRegistrationBL.registrationBL(username, password);   
   }
}
	



userRegistrationBL.cs:-
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
   public class UserRegistrationBL
   {
       UserRegistrationRL _userRegistrationRL;

       public UserRegistrationBL(UserRegistrationRL userRegistrationRL)
       {
           _userRegistrationRL = userRegistrationRL;
       }

       public string registrationBL(string username, string password)
       {
           return _userRegistrationRL.registrationRL(username, password);   
       }

       public string checkRegistration(string username, string password)
       {
           if(username == "root" && password == "root")
           {
               return registrationBL(username, password);
           }
           return "Invalid Username and Password";
       }
   }
}