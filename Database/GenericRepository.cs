using System.Collections.Generic;
using MongoDB.Driver;

namespace Database
{
    public class GenericRepository<T>
    {
        private IMongoCollection<T> collection;
        public GenericRepository(IMongoDatabase db, string collectionName)
        {
            this.collection = db.GetCollection<T>(collectionName);
        }

        public void Insert(T data)
        {
            collection.InsertOne(data);
        }

        public List<T> GetList()
        {
            return collection.AsQueryable().ToList();
        }

        public T GetById(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            return collection.Find(filter).FirstOrDefault();
        }

        public void Update(string id, T document)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            collection.ReplaceOne(filter, document);
        }

        public void Delete(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            collection.FindOneAndDelete<T>(filter);
        }
    }
}
