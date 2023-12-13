using MongoDB.Bson;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

var mongoClient = new MongoClient(connectionString);
var mongoDatabase = mongoClient.GetDatabase("Joueurs");
mongoDatabase.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait(); // teste la connexion
builder.Services.AddSingleton<IMongoDatabase>(mongoDatabase);

app.MapGet("/", () => "Hello World!");

app.Run();
