using eTickets.Data;
using eTickets.Models.Repositories;

namespace eTickets.Models.Services
{
    public class ProducerService : Repository<Producer>
    {
        private readonly AppDbContext context;

        public ProducerService(AppDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
