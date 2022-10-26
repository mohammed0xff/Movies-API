using MongoDB.Driver;
using ApiMongoDB.Collection;

namespace ApiMongoDB.Services
{
    public interface IDbClient
    {
        IMongoCollection<Movie> GetMoviesCollection();
        IMongoDatabase GetDatabase(string databaseName);
    }
}
