using Cinema.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Repository.Interface
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAll();
        Movie Get(Guid? id);
        void Insert(Movie entity);
        void Update(Movie entity);
        void Delete(Movie entity);
    }
}
