using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using FacilitarPDV.Domain.Entities;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;

namespace FacilitarPDV.Infra.Context
{
    public class DataContext
    {
        private readonly IMongoDatabase _db;
        public IMongoCollection<object> Collection { get; private set; }

        public DataContext()
        {
            // impede que campos nulos sejam enviados para o banco de dados
            ConventionRegistry.Register(
                "Ignore null values",
                new ConventionPack { new IgnoreIfNullConvention(true) },
                t => true
            );

            BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;

            _db = new MongoClient("mongodb://localhost").GetDatabase("FacilitarPDV");
        }

        public void SetCollection(string collectionName)
        {
            Collection = _db.GetCollection<object>(collectionName);
        }

        private string IdFilter(Guid id)
        {
            return "{_id:UUID(\"" + id.ToString().Replace("{", "").Replace("}", "") + "\")}";
        }

        public List<object> Get()
        {
            return Collection.Find(_ => true).ToList();
        }

        public object Get(Guid id)
        {
            List<object> list = Collection
                .Find(IdFilter(id))
                .Limit(1)
                .ToList();

            return list.Count == 1 ? list[0] : null;
        }

        public void Insert(object data)
        {
            Collection.InsertOne(data);
        }

        public void Update(Guid id, object data)
        {
            Collection.ReplaceOne(IdFilter(id), data);
        }

        public void Delete(Guid id)
        {
            Collection.DeleteOne(IdFilter(id));
        }
    }
}
