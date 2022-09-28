using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
    public class CategoriesRepository : GenericRepository<Category>, ICategoriesRepository
    {
        //Uses the DbContext and inherits the methods.
        public CategoriesRepository(ConnectedOfficeContext context) : base(context)
        {
        }

        public Category GetMostRecentCategory()
        {
            return _context.Category.OrderByDescending(category => category.DateCreated).FirstOrDefault();
        }
    }

}
