using EnigmatryFinancial.Data;
using EnigmatryFinancial.Middlewares;
using EnigmatryFinancial.Repositories;
using EnigmatryFinancial.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add service registration
builder.Services.AddScoped<IFinancialDocumentRetrievalService, FinancialDocumentRetrievalService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ITenantService, TenantService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IFinancialDocumentService, FinancialDocumentService>();
builder.Services.AddScoped<IFinancialDocumentRepository, FinancialDocumentRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ITenantService, TenantService>();
builder.Services.AddScoped<IClientService, ClientService>();


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
