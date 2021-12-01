using Microsoft.EntityFrameworkCore;
using ShortUrl.DataAccess;
using ShortUrl.DataAccess.Interfaces;
using ShortUrl.DataAccess.Repositories;
using ShortUrl.UI.Infra;
using ShortUrl.UI.Interfaces;
using ShortUrl.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var cnnString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<AddressContext>(options => options.UseSqlServer(cnnString));
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IAddressService, AddressService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionHandler>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
