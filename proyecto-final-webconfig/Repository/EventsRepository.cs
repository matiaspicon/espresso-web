using Microsoft.EntityFrameworkCore;
using proyecto_final_webconfig.Data;
using proyecto_final_webconfig.Models.Entities;

namespace proyecto_final_webconfig.Repository
{
    public class EventsRepository : IEventsRepository
    {
        private readonly EspressoContext espressoContext;

        public EventsRepository(EspressoContext espressoContext)
        {
            this.espressoContext = espressoContext;
        }

        public async Task<IEnumerable<Event>> GetAllRecentsEvents()
        {
            return await espressoContext.Events.ToListAsync();
        }

        public async Task<Event> GetEventByID(int id)
        {
            return await espressoContext.Events.Where(x => x.Id == id).FirstAsync();
        }

    }
}
