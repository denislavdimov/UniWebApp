﻿using BookStore.BL.Interfaces;
using BookStore.BL.Services;
using BookStore.DL.Interfaces;
using BookStore.DL.Repositories.InMemoryRepo;
using BookStore.DL.Repositories.MongoDB;
using BookStore.Models.Configurations;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using FluentValidation.AspNetCore;
using FluentValidation;
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

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.RegisterHealthCheck();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

