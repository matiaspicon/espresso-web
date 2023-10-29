using proyecto_final_webconfig.Models.Entities;

namespace proyecto_final_webconfig.Repository
{
    public interface IDevicesRepository
    {
        Task<IEnumerable<Device>> GetAllDevices();
        Task<Device> GetDeviceByID(int id);
        Task<int> RemoveDevice(int id);
    }
}