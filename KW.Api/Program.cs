using KW.Application;
using KW.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();//.AddFluentValidation();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
