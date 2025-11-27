using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Portfolio.Config;
using Portfolio.Data;
using Portfolio.Extensions;
using Portfolio.Middleware;
using Portfolio.Models;
using System.Text.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// configuration binding to the objects

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
//auth set up
builder.Services.AddAuthSetUp(builder.Configuration.GetSection("Jwt"));

//builder.Services.Configure<MongoDbSettings>(
//builder.Configuration.GetSection("ConnectionStr"));
//builder.Services.AddSingleton<MongoDbContext>();

//db set up
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresSqlConnectionString")));
builder.Services.AddIdentity<ApplicationUser,IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// registering the automapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

//registering services
builder.Services.AddRegistrationsSetUp();

//swagger set up
builder.Services.AddSwaggerSetUp();

//api versioning set up
builder.Services.AddApiVersioningSetUp();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
//builder.Services.us
var app = builder.Build();

// swagger registrastion
app.UseSwaggerSetUp();

//app.Urls.Add("http://0.0.0.0:8080");
//var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
//app.Urls.Add($"http://0.0.0.0:{port}");
app.MapGet("/", () => Results.Ok("app running ok"));
app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseExceptionMiddleWare();
app.UseAuthentication();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
