using CertificateManagementApi.Dtos;
using CertificateManagementApi.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CertificateManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CertificateController : Controller
    {
        private readonly ICertificateService _certificateService;
        public CertificateController(ICertificateService certificateService)
        {
            _certificateService = certificateService;
        }
        [HttpPost("CreateCertificate/{OrganizationId}")]
        public async Task<IActionResult> Create([FromForm]CreateCertificateRequestModel model , int OrganizationId)
        {
            if (model != null)
            {
                var cert = await _certificateService.Create(model , OrganizationId);
                return Ok(cert);
            }
            return BadRequest(model);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var delete = await _certificateService.Delete(id);
            return Ok(delete);
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            var certificate = await _certificateService.Get(id);
            if(certificate.Status == true)
            {
                return Ok(certificate);
            }
            return BadRequest(certificate);
        }
        
        [HttpGet("GetAllCertificates")]
        public async Task<IActionResult> GetAll()
        {
            var certificates = await _certificateService.GetAll();
            if(certificates == null)
            {
                return BadRequest(certificates);
            }
            return Ok(certificates);
        }
        [HttpGet("GetAllUnGeneratedCertificates/{organizationId}")]
        public async Task<IActionResult> GetAllUnGeneratedCertificates(int organizationId)
        {
            var certificates = await _certificateService.GetAllUnGeneratedCertificates(organizationId);
            if (certificates.Status == true)
            {
                return Ok(certificates);
            }
            return BadRequest(certificates);
        }
         [HttpGet("GetAllGeneratedCertificates")]
        public async Task<IActionResult> GetAllGeneratedCertificates()
        {
            var certificates = await _certificateService.GetAllGeneratedCertificates();
            if (certificates.Status == true)
            {
                return Ok(certificates);
            }
            return BadRequest(certificates);
        }

    }
}