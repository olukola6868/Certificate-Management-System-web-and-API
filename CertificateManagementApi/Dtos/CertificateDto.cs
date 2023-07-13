using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CertificateManagementApi.Dtos
{
    public class CertificateDto
    {
        public int Id { get; set; }
        public bool isGenerated { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Date { get; set; }
        public string Signature { get; set; }
    }
    public class CreateCertificateRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Date { get; set; }
        public IFormFile Signature { get; set; }
        public int OrganizationId { get; set; }
    }
    public class UpdateCertificateRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Date { get; set; }
        public IFormFile Signature { get; set; }
    }
    public class CertificateResponseModel : BaseResponse<CertificateDto>
    {
        public CertificateDto Data { get; set; }
    }

    public class CertificatesResponseModels : BaseResponse<CertificateDto>
    {
        public IEnumerable<CertificateDto> Data { get; set; }
    }
}
