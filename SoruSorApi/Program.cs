using Microsoft.EntityFrameworkCore;
using Repositories.EFCore;
using SoruSorApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigRepositoryManager();
builder.Services.ConfigServiceManager();
//Configure AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();
    app.ConfigureExceptionHandler();


if (app.Environment.IsDevelopment()) 
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if (app.Environment.IsProduction())
    app.UseHsts();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
