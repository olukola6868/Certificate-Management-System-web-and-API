using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CertificateManagementApi.Dtos;
using CertificateManagementApi.Model;

namespace CertificateManagementApi.Service.Interface
{
    public interface ICertificateService
    {
        Task<BaseResponse<CertificateDto>> Create(CreateCertificateRequestModel model, int OrganizationId);
        Task<bool> Delete(int id);
        Task<CertificateResponseModel> Get(int id);
        Task<CertificatesResponseModels> GetAll();
        Task<CertificatesResponseModels> GetAllGeneratedCertificates();
        Task<CertificatesResponseModels> GetAllUnGeneratedCertificates(int organizationId);
        Task<BaseResponse<CertificateDto>> Update(UpdateCertificateRequestModel model, int id);
    }
}