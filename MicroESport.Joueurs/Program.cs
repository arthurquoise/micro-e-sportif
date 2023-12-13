using MicroESport.Joueurs.Domain.Interfaces;
using MicroESport.Joueurs.Domain.Services;
using MicroESport.Joueurs.Infrastructure.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);


string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var mongoClient = new MongoClient(connectionString);
var mongoDatabase = mongoClient.GetDatabase("Joueurs");

//mongoDatabase.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait(); // teste la connexion
builder.Services.AddSingleton<IMongoDatabase>(mongoDatabase);

builder.Services.AddControllers();

builder.Services.AddScoped<IJoueurRepository, JoueurMongoRepository>();
builder.Services.AddScoped<JoueurService>();

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
