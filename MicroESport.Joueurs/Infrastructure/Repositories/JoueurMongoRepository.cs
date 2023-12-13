using System.Linq.Expressions;
using MicroESport.Joueurs.Domain.Interfaces;
using MicroESport.Joueurs.Domain.Models;
using MongoDB.Driver;
using SharpCompress.Common;

namespace MicroESport.Joueurs.Infrastructure.Repositories
{
    public class JoueurMongoRepository : IJoueurRepository
    {
        private readonly IMongoCollection<Joueur> _collection;
        private readonly IMongoDatabase _database;

        public JoueurMongoRepository(IMongoDatabase database)
        {
            _database = database;
            _collection = _database.GetCollection<Joueur>("Joueurs");
        }

        public async Task<IEnumerable<Joueur>> FindAll()
        {
            return await _collection.Find(e => true).ToListAsync();
        }

        public async Task<Joueur?> FindById(string id)
        {
            return await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Joueur>> FindBySpecification(Func<Joueur, bool> predicate)
        {
            return await _collection.Find(e => predicate(e)).ToListAsync();
        }

        public async Task<Joueur> Save(Joueur joueur)
        {
            await _collection.InsertOneAsync(joueur);
            return joueur;
        }

        public async Task<Joueur> Update(Joueur joueur)
        {
            var entityFromDb = await _collection.Find(e => e.Id == joueur.Id).FirstOrDefaultAsync();
            if (entityFromDb == null)
                throw new Exception("Joueur not found");

            var result = await _collection.ReplaceOneAsync(x => x.Id == joueur.Id, joueur);
            if (result.ModifiedCount != 1)
                throw new Exception("Joueur not updated");

            return joueur;
        }

        public async Task<bool> Delete(string id)
        {
            var entityFromDb = await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
            if (entityFromDb == null)
                throw new Exception("Joueur not found");

            var result = await _collection.DeleteOneAsync(e => e.Id == id);

            return result.DeletedCount == 1;
        }
    }
}
