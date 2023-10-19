﻿using proyecto_final_webconfig.Models.Entities;

namespace proyecto_final_webconfig.Repository
{
    public interface IEventsRepository
    {
        Task<IEnumerable<Event>> GetAllRecentsEvents();
        Task<Event> GetEventByID(int id);
    }
}