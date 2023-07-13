using CertificateManagementApi.Dtos;
using CertificateManagementApi.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CertificateManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromForm]LoginUserRequestModel model)
        {
            var user = await _userService.Login(model);
            if(user.Status != false)
            {
                return Ok(user);
            }
            return BadRequest(user);
        }
    }
}