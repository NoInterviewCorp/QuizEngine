using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Core;

namespace Evaluation_BackEnd.Persistence {
    public class LearnersContext {
        public MongoClient database;
        private const string connectionstring = "mongodb://localhost:27017";
        public LearnersContext () {
            database = new MongoClient (connectionstring);
        }
    }
}