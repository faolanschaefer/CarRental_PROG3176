using WebApiMiddleware;
using Maintenance.WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Swagger to include API key authentication
//builder.Services.AddSwaggerGen(options =>
//{
//    options.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
//    {
//        In = ParameterLocation.Header,
//        Name = "X-API-KEY",
//        Type = SecuritySchemeType.ApiKey,
//        Description = "API Key authentication"
//    });

//    options.AddSecurityRequirement(doc => new OpenApiSecurityRequirement
//    {
//        {
//            new OpenApiSecuritySchemeReference("ApiKey", doc),
//            new List<string>()
//        }
//    });
//});

builder.Services.AddScoped<IRepairHistoryService, FakeRepairHistoryService>();

var usageCounts = new Dictionary<string, int>();
builder.Services.AddSingleton(usageCounts);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<InternalAccessMiddleware>();
app.UseMiddleware<ExceptionMiddleware>();

// Basic exception handling
//app.Use(async (context, next) =>
//{
//    try
//    {
//        await next();
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine(ex.Message);
//        context.Response.StatusCode = 500;
//        context.Response.ContentType = "application/json";
//        await context.Response.WriteAsJsonAsync(new
//        {
//            error = "ServerError",
//            message = "An unexpected error occurred."
//        });
//    }
//});

// Basic API key handling
//const string API_KEY = "MY_SECRET_KEY_123";
//app.Use(async (context, next) =>
//{
//    if (!context.Request.Headers.TryGetValue("X-Api-Key", out var key) ||
//    key != API_KEY)
//    {
//        context.Response.StatusCode = 401;
//        await context.Response.WriteAsJsonAsync(new
//        {
//            error = "Unauthorized",
//            message = "Missing or invalid API key."
//        });
//        return;
//    }
//    await next();
//});

// Causes problems with interservice communication when running in Docker
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
