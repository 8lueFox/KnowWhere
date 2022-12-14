using KW.GeolocationService.Api.Configurations;
using KW.GeolocationService.Application;
using KW.GeolocationService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Host.AddConfiguration();
builder.Services.AddSettings(builder.Configuration);

builder.Services.AddCors(opt =>
    opt.AddPolicy("CorsPolicy", policy =>
        policy.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .WithOrigins("http://localhost:3000")));

builder.Services.AddTransient<IHooperService, HooperService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("CorsPolicy");

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
