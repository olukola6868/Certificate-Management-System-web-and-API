using CertificateManagementApi.Dtos;
using CertificateManagementApi.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CertificateManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;
        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }
        [HttpPost("CreateOrganization")]
        public async Task<IActionResult> CreateOrganization([FromForm] CreateOrganizationRequestModel model)
        {
            if (model != null)
            {
                var create = await _organizationService.Create(model);
                return Ok(create);
            }
            return BadRequest(model);
        }
        [HttpGet("Detail/{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            var organization = await _organizationService.Get(id);
            if (organization.Status == true)
            {
                return Ok(organization);
            }
            return BadRequest(organization);
        }
        [HttpGet("Approve/{id}")]
        public async Task<IActionResult> Approve(int id)
        {
            var approval = await _organizationService.Approve(id);
            if (approval.Status == true)
            {
                return Ok(approval);
            }
            return BadRequest(approval);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var delete = await _organizationService.Delete(id);
            return Ok(delete);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var organizations = await _organizationService.GetAll();
            if (organizations.Status == true)
            {
                return Ok(organizations);
            }
            return BadRequest(organizations);
        }
        [HttpGet("GetAllUnApprovedOrganization")]
        public async Task<IActionResult> GetAllUnApprovedOrganization()
        {
            var organizations = await _organizationService.GetAllUnApprovedOrganization();
            if (organizations.Status == true)
            {
                return Ok(organizations);
            }
            return BadRequest(organizations);
        }
        [HttpPut("UpdateOrganization/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] UpdateOrganizationRequestModel model)
        {
            if (model != null)
            {
                var update = await _organizationService.Update(model, id);
                return Ok(model);
            }
            return BadRequest(model);
        }
    }
}