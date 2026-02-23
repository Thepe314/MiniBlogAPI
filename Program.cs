using Microsoft.EntityFrameworkCore;
using MINIBLOGAPI;
using MINIBLOGAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

// Add services to the DI container
builder.Services.AddOpenApi();
builder.Services.AddControllers(); // Register MVC controllers
builder.Services.AddEndpointsApiExplorer();// Enable API endpoint discovery for Swagger
builder.Services.AddSwaggerGen();// Enable Swagger UI for API documentation


// Register repository for Dependency Injection

builder.Services.AddScoped<ICommentRepository,CommentRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();

//Inject the Database context
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();


//Enable Swagger UI/Configure the middleware
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS


app.MapControllers(); // Map controller routes


//Run application
app.Run();

