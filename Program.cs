using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Portfolio.Data;
using Portfolio.Interfaces.IRepository_s;
using Portfolio.Interfaces.IServices;
using Portfolio.Repositories;
using Portfolio.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
    options.SwaggerDoc("CMS", new OpenApiInfo
    {
        Title="Portfolio CMS",
        Version="v1",
        Description="use this end points for handeling the content of the websites"
    });
});
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("ConnectionStr"));
builder.Services.AddSingleton<MongoDbContext>();
builder.Services.AddAuthentication(
    options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }    
    ).AddJwtBearer(
    options =>
    {

    }
    );
//registering services
builder.Services.AddScoped<IProfileRepository,ProfileRepository>();
builder.Services.AddScoped<IProfileService, ProfileService>();
//builder.Services.us
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();
