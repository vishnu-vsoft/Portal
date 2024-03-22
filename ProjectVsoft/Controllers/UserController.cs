using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectVsoft.Models;
using ProjectVsoft.Repository;

namespace ProjectVsoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserDetailsPost _userDetailsPost;

        public UserController(IUserDetailsPost userDetailsPost)
        {
            _userDetailsPost = userDetailsPost;
        }
        [HttpPost("user")]
        public async Task<IActionResult> PostUser([FromBody] UserDetails userDetails)
        {
            try
            {
                bool result = await _userDetailsPost.InsertUserAsync(userDetails);
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
                Console.WriteLine(ex);

                return BadRequest($"Error Message:{ex.Message}");
            }
        }
    }
}
         

                   
    
