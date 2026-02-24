# MiniBlogApi

A Blog System built with .Net and SQL Server (SSMS)

Used Entity Framework in this project to learn about it, instead of the previous project IMS.PRODUCTAPI which used raw sql queries.

## What it does
-Manages Post (CREATE, READ, UPDATE, DELETE)
-Manages Comment (CREATE, READ, UPDATE, DELETE)
-Search Post by Title
-Search Comment by Author

## Technologies Used
- .Net 8
-Swagger UI
-SQL Server (SSMS)

## How to run the project
### 1.Clone the repo git hub
https://github.com/Thepe314/MiniBlogAPI.git

### 2. Set up the database 
- Open SSMS  and connect to your SQL Server
- Update the connection string in appsettings with your server name: "DefaultConnection";
- "Server=YOUR_SERVER_NAME\\SQLEXPRESS;Database=BlogDB;Trusted_Connection=True;TrustServerCertificate=True;"

### 3.Run the project 
- using 'dotnet run'

### 4.Open the swagger
-Go to http://localhost:5122/swagger 
-Test the API

## Api Endpoints
### Comments
-GET /api/Comments  -> Get a list of comments

-POST /api/Comments -> Create a new comments

-GET /api/Comments/ {id} ->Find a comments with id

-PUT /api/Comments/ {id} ->Change values of comments with id

-DELETE /api/Comments/{id} ->Delete an existing comments

-GET /api/Comments/search ->Search an existing comments by Author

### Post
--GET /api/Posts  -> Get a list of post

-POST /api/Posts -> Create a new post

-GET /api/Posts/ {id} ->Find a post with id

-PUT /api/Posts/ {id} ->Change values of post with id

-DELETE /api/Posts/{id} ->Delete an existing post

-GET /api/Posts/search ->Search an existing post by Title


