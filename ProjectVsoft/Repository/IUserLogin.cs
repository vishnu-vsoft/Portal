using ProjectVsoft.Models;

namespace ProjectVsoft.Repository
{
    public interface IUserLogin
    {
        Task<bool> InsertUserLoginAsync(UserLoginDetails userLoginDetails);
    }
}
