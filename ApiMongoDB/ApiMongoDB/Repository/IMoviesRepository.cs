using ApiMongoDB.Collection;

namespace ApiMongoDB.Repository
{
    public interface IMoviesRepository
    {
        Task<List<Movie>> GetAllAsync();
        Task<Movie> GetByIdAsync(string id);
        Task CreateNewMovieAsync(Movie newMovie);
        Task UpdateMovieAsync(Movie movieToUpdate);
        Task DeleteMovieAsync(string id);
    }
}
