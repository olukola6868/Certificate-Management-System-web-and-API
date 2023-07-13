using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CertificateManagementApi.Dtos;

namespace CertificateManagementApi.Service.Interface
{
    public interface IRoleService
    {
        public Task<BaseResponse<RoleDto>> Create(CreateRoleRequestModel model);
        public Task<RoleResponseModel> Get(int id);
        public Task<RolesResponseModels> GetAll();
        public Task<BaseResponse<RoleDto>> Update(int id, UpdateRoleRequestModel model);
        public Task<BaseResponse<RoleDto>> GetByRoleName(string Name);
        public Task<bool> Delete(int id);
    }
}