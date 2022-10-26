using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ApiMongoDB.Collection;
using ApiMongoDB.Config;

namespace ApiMongoDB.Services
{
    public class DbClient : IDbClient
    {
        private readonly string _connectionString;
        private readonly IMongoCollection<Movie> _movies;


        public DbClient(IOptions<MongoDBConfig> movieDbConfig)
        {
            var client = new MongoClient(movieDbConfig.Value.Connection_String);
            var database = client.GetDatabase(movieDbConfig.Value.Database_Name);
            _movies = database.GetCollection<Movie>(movieDbConfig.Value.Movies_Collection_Name);

            _connectionString = movieDbConfig.Value.Connection_String;

        }
        public IMongoClient GetClient()
        {
            return new MongoClient(_connectionString);
        }

        public IMongoDatabase GetDatabase(string databaseName)
        {
            var mongoDbClient = GetClient();

            return mongoDbClient.GetDatabase(databaseName);
        }

        public IMongoCollection<Movie> GetMoviesCollection() => _movies;
    }
}
