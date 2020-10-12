using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Network.Domain.Entities;
using System.Collections.Generic;
using System.Linq;


namespace Network.Services
{
    public class PostService
    {

        private static IMongoCollection<Post> posts;

        public PostService(IConfiguration config)
        {
            string connectionString = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase("NetworkDb");
            posts = database.GetCollection<Post>("Posts");
        }

        public Post Create(Post post)
        {
            posts.InsertOne(post);
            return post;
        }

        public Post Get(string id)
        {
            return posts.Find(post => post._id == id).FirstOrDefault();
        }

        public List<Post> GetAllById(string id)
        {
            return posts.Find(post => post.UserId == id).ToList();
        }

        public List<Post> GetAll()
        {
            return posts.Find(profile => true).ToList();
        }


        public void Remove (Post postIn)
        {
            posts.DeleteOne(post => post._id == postIn._id);
        }

    }
}
