using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
    public class DevicesRepository : GenericRepository<Device>, IDevicesRepository
    {
        //Uses the DbContext and inherits the methods.
        public DevicesRepository (ConnectedOfficeContext context) : base(context)
        {
        }

        public Device GetMostRecentDevice()
        {
            return _context.Device.OrderByDescending(device => device.DateCreated).FirstOrDefault();
        }
    }
}
