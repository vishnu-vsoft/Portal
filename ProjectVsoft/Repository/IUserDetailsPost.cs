using ProjectVsoft.Models;

namespace ProjectVsoft.Repository
{
    public interface IUserDetailsPost
    {
       Task<bool> InsertUserAsync(UserDetails userDetails);
       
    }
}