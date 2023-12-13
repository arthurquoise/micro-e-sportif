using System.Linq.Expressions;
using MicroESport.Equipes.Domain.Interfaces;
using MicroESport.Equipes.Domain.Models;
using MongoDB.Driver;
using SharpCompress.Common;

namespace MicroESport.Equipes.Infrastructure.Repositories
{
    public class EquipeMongoRepository : IEquipeRepository
    {
        private readonly IMongoCollection<Equipe> _collection;
        private readonly IMongoDatabase _database;

        public EquipeMongoRepository(IMongoDatabase database)
        {
            _database = database;
            _collection = _database.GetCollection<Equipe>("Equipes");
        }

        public async Task<IEnumerable<Equipe>> FindAll()
        {
            return await _collection.Find(e => true).ToListAsync();
        }

        public async Task<Equipe?> FindById(string id)
        {
            return await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Equipe>> FindBySpecification(Func<Equipe, bool> predicate)
        {
            return await _collection.Find(e => predicate(e)).ToListAsync();
        }

        public async Task<Equipe> Save(Equipe equipe)
        {
            await _collection.InsertOneAsync(equipe);
            return equipe;
        }

        public async Task<Equipe> Update(Equipe equipe)
        {
            var entityFromDb = await _collection.Find(e => e.Id == equipe.Id).FirstOrDefaultAsync();
            if (entityFromDb == null)
                throw new Exception("Equipe not found");

            var result = await _collection.ReplaceOneAsync(x => x.Id == equipe.Id, equipe);
            if (result.ModifiedCount != 1)
                throw new Exception("Equipe not updated");

            return equipe;
        }

        public async Task<bool> Delete(string id)
        {
            var entityFromDb = await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
            if (entityFromDb == null)
                throw new Exception("Equipe not found");

            var result = await _collection.DeleteOneAsync(e => e.Id == id);

            return result.DeletedCount == 1;
        }
    }
}
