using EnigmatryFinancial.Data;
using EnigmatryFinancial.Middlewares;
using EnigmatryFinancial.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add service registration
builder.Services.AddScoped<IFinancialDocumentService, FinancialDocumentService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ITenantWhitelistingService, TenantWhitelistingService>();

var connectionString = string.Empty;
if (builder.Environment.IsDevelopment())
{
    connectionString = builder.Configuration.GetConnectionString("TestDbConnection");
}
else if (builder.Environment.IsProduction())
{
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
}
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString));

var app = builder.Build();

app.UseMiddleware<ProductCheckMiddleware>();
app.UseMiddleware<TenantWhitelistingMiddleware>();

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
