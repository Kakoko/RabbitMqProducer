using Microsoft.EntityFrameworkCore;
using Producer.API.Data;
using Producer.API.RabbitMq;
using Producer.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IRabitMQProducer, RabitMQProducer>();

//Add the COnfiguration
ConfigurationManager configuration = builder.Configuration;

// Registering a Database
builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

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
