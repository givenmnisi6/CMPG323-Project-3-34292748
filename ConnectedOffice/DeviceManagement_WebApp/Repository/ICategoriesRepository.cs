using DeviceManagement_WebApp.Models;

namespace DeviceManagement_WebApp.Repository
{
    public interface ICategoriesRepository : IGenericRepository<Category>
    {
        //Inherits the IGenericRepository interface.
        Category GetMostRecentCategory();
    }

}
