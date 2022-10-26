using MongoDB.Driver;
using ApiMongoDB.Collection;
using ApiMongoDB.Services;

namespace ApiMongoDB.Repository
{
    public class MovieRepository : IMoviesRepository
    {
        private readonly IMongoCollection<Movie> _moviesCollection;

        public MovieRepository(IDbClient mongoDatabase)
        {
            _moviesCollection = mongoDatabase.GetMoviesCollection();
        }

        public async Task CreateNewMovieAsync(Movie newMovie)
        {
            await _moviesCollection.InsertOneAsync(newMovie);
        }

        public async Task DeleteMovieAsync(string id)
        {
            await _moviesCollection.DeleteOneAsync(m => m.Id == id);
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            return await _moviesCollection.Find(m => true).ToListAsync();
        }

        public async Task<Movie> GetByIdAsync(string id)
        {
            return await _moviesCollection.Find(m => m.Id == id).FirstOrDefaultAsync();
        }   

        public async Task UpdateMovieAsync(Movie moviepeopleToUpdate)
        {
            await _moviesCollection.ReplaceOneAsync(x => x.Id == moviepeopleToUpdate.Id, moviepeopleToUpdate);
        }
    }
}
