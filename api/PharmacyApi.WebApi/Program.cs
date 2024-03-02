using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PharmacyApi.Domain.Entities;
using PharmacyApi.Domain.IRepository;
using PharmacyApi.Infrastructure.Repositories.PharmacyRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PharmacyContext>(opts =>
    opts.UseSqlServer(builder.Configuration["ConnectionString:PharmacyDB"]));
builder.Services.AddScoped<IPharmacyRepository<Pharmacy>, PharmacyRepository>();
builder.Services.AddControllers();

// Enables API exploration features, essential for generating Swagger documentation.
builder.Services.AddEndpointsApiExplorer();
// Configures Swagger generation with XML comments for enhanced API documentation.
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath); // Includes XML documentation for Swagger UI.
});

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
