using NLog;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MoviesProj.Models;
using MoviesProj.Services;
using LoggerService;
using MoviesProj.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
//using MoviesProj.Models.User;
//using MoviesProj.Models.Role;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(),
"/nlog.config"));

// Add services to the container.

builder.Services.Configure<MovieDatabaseSettings>(
    builder.Configuration.GetSection(nameof(MovieDatabaseSettings)));

builder.Services.AddSingleton<ILoggerManager, LoggerManager>();

builder.Services.AddSingleton<IMovieDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<MovieDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetValue<string>("MovieDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IMovieService,MovieService>();
builder.Services.AddScoped<ISpecificCommentService, SpecificCommentService>();

//builder.Services.AddAntiforgery();

builder.Services.AddControllers();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

//builder.Services.AddIdentity<ApplicationUser, ApplicationRole>();

builder.Services.AddAuthentication();
//builder.Services.ConfigureIdentity();

builder.Services.ConfigureJWT(builder.Configuration);

//builder.Services.ConfigureVersioning();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Code Maze API",
        Version = "v1"
    });
    s.SwaggerDoc("v2", new OpenApiInfo
    {
        Title = "Code Maze API",
        Version = "v2"
    });
});

var app = builder.Build();


var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
    app.UseHsts();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
