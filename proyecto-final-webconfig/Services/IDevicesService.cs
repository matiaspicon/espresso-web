﻿using proyecto_final_webconfig.Models.Entities;

namespace proyecto_final_webconfig.Services
{
    public interface IDevicesService
    {
        Task<IEnumerable<Device>> GetAllDevices();
        Task<Device> GetDeviceByID(int id);
    }
}