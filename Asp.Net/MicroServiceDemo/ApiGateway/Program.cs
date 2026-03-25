using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Polly;
using Ocelot.Provider.Consul;
using Ocelot.Cache.CacheManager;
using Serilog;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ApiGateway.Aggregators;
using Ocelot.Multiplexer;

var builder = WebApplication.CreateBuilder(args);

// Register custom aggregators
builder.Services.AddSingleton<IDefinedAggregator, OrderDetailsAggregator>();
builder.Services.AddSingleton<IDefinedAggregator, PaymentOrderAggregator>();

// Add Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("logs/gateway-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

// Add Ocelot configuration
var ocelotConfig = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", optional: true)
    .Build();

builder.Configuration.AddConfiguration(ocelotConfig);

// Add services
builder.Services.AddOcelot(ocelotConfig)
    .AddPolly()
    .AddConsul()
    .AddCacheManager(x =>
    {
        x.WithDictionaryHandle();
    });

// Add authentication (JWT)
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:ValidIssuer"],
            ValidAudience = builder.Configuration["Jwt:ValidAudience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]))
        };
    });

// Add authorization policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
        policy.RequireRole("admin"));

    options.AddPolicy("CustomerOnly", policy =>
        policy.RequireRole("customer"));

    options.AddPolicy("AdminOrCustomer", policy =>
        policy.RequireRole("admin", "customer"));
});

// Add Swagger for API Gateway
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Microservice Demo API Gateway",
        Version = "v1",
        Description = "API Gateway for Order, Payment, and Shipping Microservices"
    });

    // Add JWT Authentication to Swagger
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Enter 'Bearer' [space] and then your token",
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Add health checks
builder.Services.AddHealthChecks();

// Add response compression
builder.Services.AddResponseCompression();

var app = builder.Build();

// Configure pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Gateway V1");

        // Add Swagger endpoints for individual services
        c.SwaggerEndpoint("/swagger/orders/swagger.json", "Order Service");
        c.SwaggerEndpoint("/swagger/payments/swagger.json", "Payment Service");
        c.SwaggerEndpoint("/swagger/shipping/swagger.json", "Shipping Service");
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseResponseCompression();

app.UseAuthentication();
app.UseAuthorization();

// Custom middleware for request logging
app.Use(async (context, next) =>
{
    var correlationId = Guid.NewGuid().ToString();
    context.Request.Headers.Add("X-Correlation-Id", correlationId);

    Log.Information("Request {Method} {Path} started with CorrelationId: {CorrelationId}",
        context.Request.Method, context.Request.Path, correlationId);

    await next.Invoke();

    Log.Information("Request {Method} {Path} completed with StatusCode: {StatusCode}",
        context.Request.Method, context.Request.Path, context.Response.StatusCode);
});

// Health check endpoint
app.MapHealthChecks("/health");

// Use Ocelot as middleware
await app.UseOcelot();

app.Run();