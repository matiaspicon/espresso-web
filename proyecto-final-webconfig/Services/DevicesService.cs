using proyecto_final_webconfig.Models.Entities;
using proyecto_final_webconfig.Repository;

namespace proyecto_final_webconfig.Services
{
    public class DevicesService : IDevicesService
    {
        private readonly IDevicesRepository DevicesRepository;
        private readonly IDevicesBlacklistRepository DevicesBlacklistRepository;

        public DevicesService(IDevicesRepository DevicesRepository, IDevicesBlacklistRepository devicesBlacklistRepository)
        {
            this.DevicesRepository = DevicesRepository;
            this.DevicesBlacklistRepository = devicesBlacklistRepository;
        }

        public async Task<IEnumerable<Device>> GetAllDevices()
        {
            return await DevicesRepository.GetAllDevices();
        }
        public async Task<Device> GetDeviceByID(int id)
        { 
            return await DevicesRepository.GetDeviceByID(id);
        }

        //get devices from blacklist
        public async Task<IEnumerable<DeviceBlacklist>> GetAllDevicesBlacklist()
        {
            return await DevicesBlacklistRepository.GetAllDevices();
        }

        //get device from blacklist by id
        public async Task<DeviceBlacklist> GetDeviceBlacklistByID(int id)
        {
            return await DevicesBlacklistRepository.GetDeviceByID(id);
        }

        //add device to blacklist
        public async Task<int> AddDeviceToBlacklist(DeviceBlacklist device)
        {
            return await DevicesBlacklistRepository.AddDeviceToBlacklist(device);
        }

        //remove device from blacklist
        public async Task<int> RemoveDeviceToBlacklist(int id)
        {
            //TODO: add again to devices

            return await DevicesBlacklistRepository.RemoveDeviceToBlacklist(id);
        }

        //move device from device to blacklist

        public async Task<int> MoveDeviceToBlacklist(int id)
        {
            Device device = await GetDeviceByID(id);
            if (device == null)
            {
                return 0;
            }
            DeviceBlacklist deviceBlacklist = new DeviceBlacklist();

            deviceBlacklist.MacSource = device.MacSource;
            deviceBlacklist.Description = device.Description;
            deviceBlacklist.EventsDetected = device.EventsDetected;
            deviceBlacklist.TimestampOfBan = DateTime.Now;


            _ = await DevicesBlacklistRepository.AddDeviceToBlacklist(deviceBlacklist);
            return await DevicesRepository.RemoveDevice(id);
        }

    }
}
