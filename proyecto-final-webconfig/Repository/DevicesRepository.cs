using Microsoft.EntityFrameworkCore;
using proyecto_final_webconfig.Data;
using proyecto_final_webconfig.Models.Entities;

namespace proyecto_final_webconfig.Repository
{
    public class DevicesRepository : IDevicesRepository
    {
        private readonly EspressoContext espressoContext;

        public DevicesRepository(EspressoContext espressoContext)
        {
            this.espressoContext = espressoContext;
        }

        public async Task<IEnumerable<Device>> GetAllDevices()
        {
            return await espressoContext.Devices.ToListAsync();
        }

        public async Task<Device> GetDeviceByID(int id)
        {
            return await espressoContext.Devices.Where(x => x.Id == id).FirstAsync();
        }

    }
}
