// use and imports
using Microsoft.OpenApi.Models;
using TodoStore.DB;

// builder
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
   {
       c.SwaggerDoc("v1", new OpenApiInfo { Title = "Todo API", Description = "Keep track of your tasks", Version = "v1" });
   });

//app
var app = builder.Build();

// routes
app.MapGet("/", () => "Hello World!");
app.MapGet("/felipe", () => "Oi Felipe sabe que eu sou estou usando C# para ver se vc entra pq estou com saudades!");
//api rest
app.MapGet("/todo/{id}", (int id) => TodoDB.GetTodo(id));
app.MapGet("/todolist", () => TodoDB.GetTodoList());
app.MapPost("/todo", (Todo  todo ) => TodoDB.CreateTodo (todo ));
app.MapPut("/todo", (Todo  todo ) => TodoDB.UpdateTodo (todo ));
app.MapDelete("/todo/{id}", (int id) => TodoDB.RemoveTodo (id));
//swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
   {
     c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API V1");
   });

app.Run();
