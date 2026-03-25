using Microsoft.EntityFrameworkCore;
using ShippingServiceAPI.Data;
using ShippingServiceAPI.Services;
using ShippingServiceAPI.EventHandlers;
using Shared.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton<IEventPublisher, RabbitMQEventPublisher>();
builder.Services.AddSingleton<IEventSubscriber>(sp => (RabbitMQEventPublisher)sp.GetRequiredService<IEventPublisher>());

builder.Services.AddScoped<IShippingService, ShippingServiceAPI.Services.ShippingService>();
builder.Services.AddHostedService<ShippingEventHandlers>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.EnsureCreated();
}

app.Run();