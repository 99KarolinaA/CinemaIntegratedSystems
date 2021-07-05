using Cinema.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Service.Interface
{
    public interface IMovieService
    {
        List<Movie> GetAllMovies();
        void CreateNewMovie(Movie t);
        Movie GetDetailsForMovie(Guid? id);
        void UpdateExistingMovie(Movie t);
        void DeleteMovie(Guid id);
    }
}
