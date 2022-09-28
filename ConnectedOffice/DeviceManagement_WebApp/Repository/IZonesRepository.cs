using DeviceManagement_WebApp.Models;

namespace DeviceManagement_WebApp.Repository
{
    public interface IZonesRepository : IGenericRepository<Zone>
    {
        //Inherits the IGenericRepository interface.
        Zone GetMostRecentZone();
    }
}
