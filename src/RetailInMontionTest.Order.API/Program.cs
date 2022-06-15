using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RetailInMontionTest.Order.Application.Services;
using RetailInMontionTest.Order.Domain;
using RetailInMontionTest.Order.Infra.Contexts;
using RetailInMontionTest.Order.Infra.Messaging;
using RetailInMontionTest.Order.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddJsonConsole();

builder.Services.AddCors(c =>
{
    c.AddPolicy("*", opts => opts.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddDbContext<Context>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo() { Title = "Retail InMontion Test Order" });
});

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IMessagePublisher, MassTransitMessagePublisher>();

var provider = builder.Services.BuildServiceProvider();
var context = provider.GetService<Context>();
context.Database.Migrate();




var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.Run();
