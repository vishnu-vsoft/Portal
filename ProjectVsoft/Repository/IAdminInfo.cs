using ProjectVsoft.Models;

namespace ProjectVsoft.Repository
{
    public interface IAdminInfo
    {
         Task<IEnumerable<AdminLoginDetails>> GetAdminInfoAsync();
        

    }
    
}
