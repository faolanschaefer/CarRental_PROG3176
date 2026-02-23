using Maintenance.WebAPI.Middleware;
using Maintenance.WebAPI.Services;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "X-API-KEY",
        Type = SecuritySchemeType.ApiKey,
        Description = "API Key authentication"
    });

    options.AddSecurityRequirement(doc => new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecuritySchemeReference("ApiKey", doc),
            new List<string>()
        }
    });
});

builder.Services.AddScoped<IRepairHistoryService, FakeRepairHistoryService>();

var usageCounts = new Dictionary<string, int>();
builder.Services.AddSingleton(usageCounts);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ExceptionMiddleware>();

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

app.UseMiddleware<ApiKeyMiddleware>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
