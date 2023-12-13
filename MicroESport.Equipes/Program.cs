using MicroESport.Equipes.Domain.Interfaces;
using MicroESport.Equipes.Domain.Services;
using MicroESport.Equipes.Infrastructure.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var mongoClient = new MongoClient(connectionString);
var mongoDatabase = mongoClient.GetDatabase("Equipes");

//mongoDatabase.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait(); // teste la connexion
builder.Services.AddSingleton<IMongoDatabase>(mongoDatabase);

builder.Services.AddControllers();

builder.Services.AddScoped<IEquipeRepository, EquipeMongoRepository>();
builder.Services.AddScoped<EquipeService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
