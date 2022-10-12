using KW.Api.Configurations;
using KW.Application;
using KW.Infrastructure;
using KW.Infrastructure.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Host.AddConfiguration();

builder.Services.AddControllers();//.AddFluentValidation();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseInfrastructure(builder.Configuration);

app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    using(var scope = app.Services.CreateScope())
    {
        var initializer = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitializer>();
        await initializer.InitializeAsync();
        await initializer.SeedAsync();
    }
}

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
