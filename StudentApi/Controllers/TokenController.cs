using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Student.Core.Models.User;
using Student.Core.Services;

namespace Student.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {
        private IUserService _userService;

        public TokenController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("createtestuser")]
        public async Task<IActionResult> CreateTestUser()
        {
            var user = await _userService.CreateTestUser();

            if (user == null)
                return BadRequest(new { message = "hata oluştu" });
                
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]UserLoginModel model)
        {
            var user = await _userService.AuthenticateAsync(model.Username, model.Password);
            
            if (user == null)
                return BadRequest(new { message = "Kullanıcı adı veya şifre hatalı girildi" });
                
            return Ok(user);
        }

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var users = _userService.GetAll();
        //    return Ok(users);
        //}
    }
}