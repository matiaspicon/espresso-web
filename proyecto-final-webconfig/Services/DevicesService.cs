using proyecto_final_webconfig.Models.Entities;
using proyecto_final_webconfig.Repository;

namespace proyecto_final_webconfig.Services
{
    public class DevicesService : IDevicesService
    {
        private readonly IDevicesRepository DevicesRepository;

        public DevicesService(IDevicesRepository DevicesRepository)
        {
            this.DevicesRepository = DevicesRepository;
        }

        public async Task<IEnumerable<Device>> GetAllDevices()
        {
            return await DevicesRepository.GetAllDevices();
        }
        public async Task<Device> GetDeviceByID(int id)
        { 
            return await DevicesRepository.GetDeviceByID(id);
        }

    }
}
