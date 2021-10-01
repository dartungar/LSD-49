using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Database
{
    public class GenericRepository<T>
    {
        private IMongoCollection<T> collection;
        public GenericRepository(IMongoDatabase db, string collectionName)
        {
            this.collection = db.GetCollection<T>(collectionName);
            collection.Indexes.CreateOne(new CreateIndexModel<T>(new BsonDocument("lol", 1)));
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

        public void CreateIndex(string columnName)
        {
            this.collection.Indexes.CreateOne(new CreateIndexModel<T>(new BsonDocument(columnName, 1)));
        }

        public void CreateIndex(BsonDocument keysDefinition)
        {
            this.collection.Indexes.CreateOne(new CreateIndexModel<T>(keysDefinition));
        }
    }
}
