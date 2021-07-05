using Cinema.Domain.DomainModels;
using Cinema.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cinema.Repository.Implementation
{
    public class TicketRepository: ITicketRepository
    {
        private readonly ApplicationDbContext context;

        private DbSet<Ticket> entities;

        public TicketRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Ticket>();
        }
        public IEnumerable<Ticket> GetAll()
        {
            return entities.Include(s=>s.Movie).AsEnumerable();
        }
        public Ticket Get(Guid? id)
        {
            return entities.Include(s=>s.Movie).SingleOrDefault(s => s.Id == id);
        }
        public void Insert(Ticket entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(Ticket entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        public void Delete(Ticket entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public IEnumerable<Ticket> TicketsForMovie(Guid movieId)
        {
            var tickets = entities.Where(x => x.Movie.Id == movieId).ToList();
            return tickets;
        }

        public IEnumerable<Ticket> FilterTickets(DateTime date)
        {
            var tickets = entities.Include(s => s.Movie).Where(x => x.Date == date).ToList();
            return tickets;
        }
    }
}
