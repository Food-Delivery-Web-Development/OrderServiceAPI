using Microsoft.EntityFrameworkCore;
using OrderServiceAPI.src.Aplication.Services.Concretes;
using OrderServiceAPI.src.Aplication.Services.Interfaces;
using OrderServiceAPI.src.Database;
using OrderServiceAPI.src.Infrastructure.Interfaces;
using OrderServiceAPI.src.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => 
    {
        app.UseSwaggerUI(c => 
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order Service API v1");
            c.RoutePrefix = "swagger";
        });

    });
}


// app.UseHttpsRedirection();

app.Run();
