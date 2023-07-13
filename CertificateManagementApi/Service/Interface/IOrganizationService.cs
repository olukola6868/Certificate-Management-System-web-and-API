using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CertificateManagementApi.Dtos;

namespace CertificateManagementApi.Service.Interface
{
    public interface IOrganizationService
    {
        Task<BaseResponse<OrganizationDto>> Create(CreateOrganizationRequestModel model);
        Task<OrganizationResponseModel> Get(int id);
        Task<OrganizationsResponseModels> GetAll();
        Task<OrganizationsResponseModels> GetAllUnApprovedOrganization();
        Task<BaseResponse<OrganizationDto>> Update(UpdateOrganizationRequestModel model, int id);
        Task<BaseResponse<OrganizationDto>> Approve(int id);
        Task<bool> Delete(int id);
    }
}