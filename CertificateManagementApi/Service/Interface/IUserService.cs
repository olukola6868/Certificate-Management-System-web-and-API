using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CertificateManagementApi.Dtos;

namespace CertificateManagementApi.Service.Interface
{
    public interface IUserService
    {
        
        public Task<UserResponseModel> Get(int id);
        public Task<UsersResponseModels> GetAll();
        public Task<BaseResponse<LoginUserModel>> Login(LoginUserRequestModel model);
    }
}