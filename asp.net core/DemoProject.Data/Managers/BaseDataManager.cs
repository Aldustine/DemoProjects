using DemoProject.Data.Db;

namespace DemoProject.Data.Managers
{
    public abstract class BaseDataManager
    {
        protected readonly ApplicationContext _context;

        protected BaseDataManager(ApplicationContext context)
        {
            _context = context;
        }
    }
}