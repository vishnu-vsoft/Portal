using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectVsoft.Models;
using Microsoft.EntityFrameworkCore;
using ProjectVsoft.Repository;
namespace ProjectVsoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly IAdminInfo _adminInfo;

       
        public DemoController(IAdminInfo adminInfo)
        {
            _adminInfo = adminInfo;
            
        }
        

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var admin = await _adminInfo.GetAdminInfoAsync();   
            return Ok(admin);
        }
        


    }
}
