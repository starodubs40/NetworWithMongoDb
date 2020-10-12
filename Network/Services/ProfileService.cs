using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Network.Domain.Entities;
using Network.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Network.Services
{
    public class ProfileService
    {
        private readonly IMongoCollection<Profile> profiles;

        public ProfileService(IConfiguration config)
        {
            string connectionString = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase("NetworkDb");
            profiles = database.GetCollection<Profile>("Profiles");
        }

        public List<Profile> Get()
        {
            return profiles.Find(profile => true).ToList();
        }

        public Profile Get(string id)
        {
            return profiles.Find(profile => profile._id == id).FirstOrDefault();
        }


        public void Update(string id, Profile profileIn)
        {
            profiles.ReplaceOne(profile => profile._id == id, profileIn);
        }

        public void Remove(Profile profileIn)
        {
            profiles.DeleteOne(profile => profile._id == profileIn._id);
        }

        public void Remove(string id)
        {
            profiles.DeleteOne(profile => profile._id == id);
        }
    }
}

