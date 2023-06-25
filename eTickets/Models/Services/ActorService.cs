using eTickets.Data;
using eTickets.Models.Repositories;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Models.Services
{
    public class ActorService : Repository<Actor>
    {
        private readonly AppDbContext context;

        public ActorService(AppDbContext context) : base(context)
        {
        }
    }
}
