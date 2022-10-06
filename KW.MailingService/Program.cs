using KW.MailingService.Api.Configurations;
using KW.MailingService.Application;
using KW.MailingService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Host.AddConfiguration();
builder.Services.AddSettings(builder.Configuration);

// Add services to the container.
builder.Services.AddSingleton<IMailService, SmtpMailService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
