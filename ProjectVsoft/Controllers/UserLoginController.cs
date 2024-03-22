using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectVsoft.Models;
using ProjectVsoft.Repository;

namespace ProjectVsoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly IUserLogin _userLogin;
        public UserLoginController(IUserLogin userLogin)
        {
            _userLogin = userLogin;
        }
        [HttpPost]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginDetails userLoginDetails)
        {
            try
            {
                string hasedPassword = userLoginDetails.Password;
                bool result = await _userLogin.InsertUserLoginAsync(userLoginDetails);
                if (result)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest($"Error {ex.Message}");
            }
        }

        
    }
}
