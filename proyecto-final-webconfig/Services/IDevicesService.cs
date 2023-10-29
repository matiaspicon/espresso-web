using proyecto_final_webconfig.Models.Entities;

namespace proyecto_final_webconfig.Services
{
    public interface IDevicesService
    {
        Task<int> AddDeviceToBlacklist(DeviceBlacklist device);
        Task<IEnumerable<Device>> GetAllDevices();
        Task<IEnumerable<DeviceBlacklist>> GetAllDevicesBlacklist();
        Task<DeviceBlacklist> GetDeviceBlacklistByID(int id);
        Task<Device> GetDeviceByID(int id);
        Task<int> MoveDeviceToBlacklist(int id);
        Task<int> RemoveDeviceToBlacklist(int id);
    }
}