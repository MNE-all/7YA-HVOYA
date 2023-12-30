using Microsoft.EntityFrameworkCore;
using _7YA_HVOYA.API.Infrastructures;
using _7YA_HVOYA.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(x =>
{
    x.Filters.Add<FamilyHvoyaExceptionFilter>();
})
    .AddControllersAsServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.GetSwaggerDocument();

// У кого логгер есть - тот использует это
//builder.Services.AddLoggerRegistr();

builder.Services.AddDependencies();

var conString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContextFactory<FamilyHvoyaContext>(options => options.UseSqlServer(conString),
    ServiceLifetime.Scoped);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.GetSwaggerDocumentUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

public partial class Program { }