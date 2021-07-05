using Cinema.Domain.DomainModels;
using Cinema.Repository.Interface;
using Cinema.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cinema.Service.Implementation
{
    public class MovieService:IMovieService
    {
        private readonly IMovieRepository movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public void CreateNewMovie(Movie t)
        {

            this.movieRepository.Insert(t);
        }

        public void DeleteMovie(Guid id)
        {
            var movie = this.GetDetailsForMovie(id);
            this.movieRepository.Delete(movie);
        }

        public List<Movie> GetAllMovies()
        {
            return this.movieRepository.GetAll().ToList();
        }

        public Movie GetDetailsForMovie(Guid? id)
        {
            return this.movieRepository.Get(id);
        }

        public void UpdateExistingMovie(Movie t)
        {
            this.movieRepository.Update(t);
        }
    }
}
