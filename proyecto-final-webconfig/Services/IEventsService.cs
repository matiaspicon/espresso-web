using proyecto_final_webconfig.Models.Entities;

namespace proyecto_final_webconfig.Services
{
    public interface IEventsService
    {
        Task<IEnumerable<Event>> GetAllRecentsEvents();
    }
}