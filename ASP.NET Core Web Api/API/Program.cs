using API.Domains.Books.Data.DataSources;
using API.Domains.Books.Data.Repositories;
using API.Domains.Books.Domain;
using API.Domains.Books.Domain.Repositories;
using API.Domains.Mail.Data;
using API.Domains.Mail.Domain.Services;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
builder.Host.UseSerilog();

builder.Services.AddOpenApi();
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();
builder.Services.AddScoped<IBooksDatasource, BooksDataSource>();
builder.Services.AddScoped<IBooksRepository, BooksRepository>();
builder.Services.AddProblemDetails();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#if DEBUG
builder.Services.AddTransient<IMailService, LocalMailService>();
#else
builder.Services.AddTransient<IMailService, CloudMailService>();
#endif
builder.Services.AddControllers(options =>
{
    // Used for sending 406 code if the application/json or application/xml is not met
    options.ReturnHttpNotAcceptable = true;
}).AddXmlSerializerFormatters();

builder.Services.AddDbContext<BookContext>(optionsBuilder =>
    optionsBuilder.UseSqlite(builder.Configuration["ConnectionString:BookInfoContext"])
);

var app = builder.Build();
app.UseCors("AllowAll");

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
}
else
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();