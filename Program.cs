using MINIBLOGAPI;
using MINIBLOGAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Register repository for DI

builder.Services.AddScoped<ICommentRepository,CommentRepository>()
builder.Services.AddScoped<IPostRepository, PostRepository>()


var app = builder.Build();


//Enable Swagger UI/Configure the middleware
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

