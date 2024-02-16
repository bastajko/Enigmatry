using EnigmatryFinancial.Data;
using EnigmatryFinancial.Middlewares;
using EnigmatryFinancial.Repositories;
using EnigmatryFinancial.Services;
using EnigmatryFinancial.Swagger;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

// Add service registration

builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<IPropertyConfigRepository, PropertyConfigRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IFinancialDocumentRepository, FinancialDocumentRepository>();
builder.Services.AddScoped<ITenantRepository, TenantRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ITenantService, TenantService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IFinancialDocumentService, FinancialDocumentService>();
builder.Services.AddScoped<IFinancialDocumentRetrievalService, FinancialDocumentRetrievalService>();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

    // Add a custom header to requests made by Swagger UI
    c.OperationFilter<AddTenantIdHeaderParameter>();
});

var app = builder.Build();

// This can be also some common properties middleware, but for this api we only have tenantId
app.UseMiddleware<TenantIdMiddleware>();
// Also I could add tenant whitelisting here, but because of the document specification, I called it in controller
// app.UseMiddleware<TenantWhitelistingMiddleware>();

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
