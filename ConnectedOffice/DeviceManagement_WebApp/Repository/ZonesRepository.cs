using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
    public class ZonesRepository : GenericRepository<Zone>, IZonesRepository
    {
        //Uses the DbContext and inherits the methods.
        public ZonesRepository(ConnectedOfficeContext context) : base(context)
        {
        }

        public Zone GetMostRecentZone()
        {
            return _context.Zone.OrderByDescending(zone => zone.DateCreated).FirstOrDefault();
        }

    }
}
