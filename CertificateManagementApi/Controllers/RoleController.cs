using CertificateManagementApi.Dtos;
using CertificateManagementApi.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CertificateManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpPost("CreateRole")]
        public async Task<IActionResult> Create([FromForm]CreateRoleRequestModel model)
        {
            var role = await _roleService.Create(model);
            if(role.Status == true)
            {
                return Ok(role);
            }
            return BadRequest(role);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _roleService.GetAll();
            if(roles.Status == true)
            {
                return Ok(roles);
            }
            return BadRequest(roles);
        }
    }
}