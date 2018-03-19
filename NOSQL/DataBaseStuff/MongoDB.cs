using MongoDB.Driver;
using MongoDB.Driver.Core;
using System.Diagnostics;
using MongoDB.Driver.Linq;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseStuff
{
    class MongoDB
    {

        Stopwatch timer = new Stopwatch();
        IMongoDatabase db;
        IMongoCollection<BsonDocument> collection;
        public MongoDB()
        {
            
           
            
        }

        /** 
             Create a connection to an open port 27017 on your local machine
         */
        private void connect()
        {
            var connectionString = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connectionString);
            db = client.GetDatabase("Netflix");
            collection = db.GetCollection<BsonDocument>("NetflixMovie");
        
        }

        /** 
             A Method to insert random documents in the MongoDB
         */
        public void insertData()
        {
            connect();
            timer.Start();
            for(int i=0; i< 100; i++)
            {
                var document = new BsonDocument
            {
                {"MovieName", new BsonString("movie")},
                {"MinAge", new BsonInt32(6)},
                { "Rating", new BsonInt32(5) },
                };
                collection.InsertOne(document);
            }
            timer.Stop();
            Console.WriteLine("done inserting in {0}", timer.ElapsedMilliseconds);
            timer.Reset();

        }

        /** 
             Update the same amount of records inserted
         */

        public void updateData()
        {
            connect();
            timer.Start();
            collection.UpdateMany(Builders<BsonDocument>.Filter.Eq("MinAge",6), Builders<BsonDocument>.Update.Set("MovieName", "newMovie"));
            collection.UpdateMany(Builders<BsonDocument>.Filter.Eq("MinAge", 6), Builders<BsonDocument>.Update.Set("MinAge", 14));
            timer.Stop();
            Console.WriteLine("done updating in {0}", timer.ElapsedMilliseconds);
            timer.Reset();


        }

        /** 
             A Method to delete allthe inserted records
         */
        public void deleteData()
        {
            connect();
            timer.Start();
            db.DropCollection("NetflixMovie");
            timer.Stop();
            Console.WriteLine("done deleting in {0}", timer.ElapsedMilliseconds);
            timer.Reset();

        }
    }
}
