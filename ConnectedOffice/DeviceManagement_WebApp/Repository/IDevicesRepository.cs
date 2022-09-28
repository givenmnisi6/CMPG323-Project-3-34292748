using DeviceManagement_WebApp.Models;

namespace DeviceManagement_WebApp.Repository
{
    public interface IDevicesRepository : IGenericRepository<Device>
    {
        //Inherits the IGenericRepository interface.
        Device GetMostRecentDevice();
    }
}
