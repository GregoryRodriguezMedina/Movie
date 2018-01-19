using EnCore.Core;
using EnCore.Movie.Data;
using System.Collections.Generic;

namespace EnCore.Movie.Services
{
    public partial class MovieService
    {
        private readonly IMovieRepository movieRepository;
        private readonly ICategoryRepository categoryRepository;

        public MovieService(IMovieRepository movieRepository, ICategoryRepository categoryRepository)
        {
            this.movieRepository = movieRepository;
            this.categoryRepository = categoryRepository;
        }

        public IEnumerable<KeyNamePair> GetCategories()
        {
            return this.categoryRepository.Get();
        }

        public Core.Movie GetMovie(int id)
        {
           return  this.movieRepository.GetById(id);
        }

        public IQueryResponse<Core.Movie> GetMovies(QueryRequest queryRequest)
        {
            return this.movieRepository.Get(queryRequest);
        }

        public void AddCategory(string category)
        {
            this.categoryRepository.Insert(new Core.Category
            {
                Description = category
            });
        }

        public void AddMovie(Core.Movie movie)
        {
            this.movieRepository.Insert(movie);

            this.movieRepository.SaveChanges();
        }

        public void ModMovie(Core.Movie movie)
        {
            this.movieRepository.Update(movie);

            this.movieRepository.SaveChanges();
        }

        public void DelMovie(int id)
        {
            var movie = this.movieRepository.GetById(id);

            this.movieRepository.Delete(movie);

            this.movieRepository.SaveChanges();
        }
    }
}
