using BookStore.BL.Interfaces;
using BookStore.BL.Services;
using BookStore.DL.Interfaces;
using BookStore.DL.Repositories.MongoDB;
using BookStore.Models.Configurations;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using System.Text;
using UniAPI.Extensions;
using UniAPI.HealthChecks;

//var logger = new LoggerConfiguration()
//    .WriteTo
//    .Console(theme: AnsiConsoleTheme.Grayscale)
//    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

//builder.Logging.AddSerilog(logger);

builder.Services.Configure<MongoDbConfiguration>(
    builder.Configuration
    .GetSection(nameof(MongoDbConfiguration)));

// Add services to the container.
builder.Services.AddSingleton<IAuthorService, AuthorService>();
builder.Services.AddSingleton<IAuthorRepository, AuthorMongoRepository>();
builder.Services.AddSingleton<IBookService, BookService>();
builder.Services.AddSingleton<IBookRepository, BookMongoRepository>();
builder.Services.AddSingleton<ILibraryService, LibraryService>();
builder.Services.AddSingleton<IUserInfoService, UserInfoService>();
builder.Services.AddSingleton<IUserInfoRepository, UserInfoMongoRepository>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Jwt:Key"))
        };
    });

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    var jwtSecurityScheme = new OpenApiSecurityScheme()
    {
        Scheme = "bearer",
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "Put **_ONLY_** JWT Bearer token in the textbox below!",
        Reference = new OpenApiReference()
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    x.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
    x.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });
});

builder.Services.AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();
builder.Services
    .AddValidatorsFromAssemblyContaining(typeof(Program));

builder.Services.AddHealthChecks().AddCheck<CustomCheck>("CustomCheck");

BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.RegisterHealthCheck();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

