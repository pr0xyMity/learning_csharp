using API.Domains.Books.Controller;
using API.Domains.Books.Data.DataSources;
using API.Domains.Books.Data.Repositories;
using API.Domains.Books.Domain.Repositories;
using Microsoft.AspNetCore.StaticFiles;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
builder.Host.UseSerilog();

builder.Services.AddOpenApi();
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();
builder.Services.AddSingleton<IBooksDatasource, BooksDataSource>();
builder.Services.AddSingleton<IBooksRepository, BooksRepository>();
builder.Services.AddProblemDetails();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(options =>
{
    // Used for sending 406 code if the application/json or application/xml is not met
   options.ReturnHttpNotAcceptable = true; 
}).AddXmlSerializerFormatters();

var app = builder.Build();
app.UseCors("AllowAll");

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
} else 
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.MapControllers();
app.Run();