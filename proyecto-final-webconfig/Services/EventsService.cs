using proyecto_final_webconfig.Models.Entities;
using proyecto_final_webconfig.Repository;

namespace proyecto_final_webconfig.Services
{
    public class EventsService : IEventsService
    {
        private readonly IEventsRepository eventsRepository;

        public EventsService(IEventsRepository eventsRepository)
        {
            this.eventsRepository = eventsRepository;
        }

        public async Task<IEnumerable<Event>> GetAllRecentsEvents()
        {
            return await eventsRepository.GetAllRecentsEvents();
        }
        public async Task<Event> GetEventByID(int id)
        { 
            return await eventsRepository.GetEventByID(id);
        }

    }
}
