var builder = WebApplication.CreateBuilder(args);

/* TODO: Add services to the container
 * - Vehicle repository
 * - Vehicle service
 */

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
