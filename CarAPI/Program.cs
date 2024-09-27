using CarAPI.Repositories;
using CarAPI.Services;
using Microsoft.EntityFrameworkCore;
using SendGrid;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(10),
            errorNumbersToAdd: null
        )
    ));

// Register HttpClient
builder.Services.AddHttpClient();

// Registering services and repositories with scoped lifetimes
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IInquiryRepository, InquiryRepository>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IInquiryService, InquiryService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ICarRequestRepository, CarRequestRepository>();
builder.Services.AddScoped<ICarRequestService, CarRequestService>();

// Register ContactUs service and repository
builder.Services.AddScoped<IContactUsService, ContactUsService>();
builder.Services.AddScoped<IContactUsRepository, ContactUsRepository>();

// Configure SendGrid client
builder.Services.AddSingleton<ISendGridClient>(x =>
    new SendGridClient(builder.Configuration["SendGrid:ApiKey"]));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Swagger configuration, including XML comments for documentation
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment() || app.Environment.IsStaging() || app.Environment.IsProduction())
{
    // Enable Swagger and Swagger UI in all environments (Development, Staging, Production)
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Car API V1");
        c.RoutePrefix = String.Empty; // Swagger will be served at the root URL
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
