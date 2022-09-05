# WebAPIRestApp
## Explanation of the project:
Developing an ASP .Net Core WebAPI to serve the client project(MVC app). 
this project manage the data for a commercial company(Employees, Salaries, Positions, Departments), by get requests from client side, process them and take care of them  ,and send response. 
The client side repository: https://github.com/NativBashari/AspNetCoreMvc-App
## About code design:
As you can see, my project is devide like this:
1. WebAPIRest - this is the main project, it contains an API controller for each entity with all opertions(CRUD).
2. Contract - this is an API between the main project and the repository project.
3. Repository - Implementing the interfaces in the contract dll (Repository pattern).
4. Entities - it contains the ORM (EF Core library), models, migrations and mapping.

## Things I learned from this project:
- Implement repository pattern.
- Maintaining the Open-Close principle by using interfaces.
- Designing the architecture of Web-API app + Db and ORM library.

## How to run the project?
1. Open Visual Studio 2022.
2. Open the WebAPIRestApp file.
3. A database (SQLServer) is used and we need to adapt it to our local server, The definition of the database server is found in the APIDbContext.cs file in the Entities dll project where we will have to change to our local server in the ConnectionString(found in the OnConfigure method).
4. Run the project (Ctrl + f5).
5. test the project by send http requests from https://postman.com

