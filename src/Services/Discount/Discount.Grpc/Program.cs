using Discount.Grpc.Data;
using Discount.Grpc.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DiscountDb") ?? throw new NullReferenceException("Connection string cannot be null!");
builder.Services.AddDbContext<DiscountDbContext>(options =>
{
    options.UseSqlite(connectionString);
});

builder.Services.AddGrpc();

var app = builder.Build();
app.UseMigration();

app.MapGrpcService<DiscountService>();

app.MapGet("/", () => "Communication over gRPC Server.");

app.Run();