using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CertificateManagementApi.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public IList<RoleDto> Roles { get; set; } = new List<RoleDto>();
    }

    public class LoginUserModel
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int UserId { get; set; }
        public IList<RoleDto> Roles { get; set; } = new List<RoleDto>();
    }


    public class LoginUserResponseModel : BaseResponse<LoginUserModel>
    {
        public LoginUserModel Data { get; set; }
    }

    public class CreateUserRequestModel
    {
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class LoginUserRequestModel
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
    public class UserResponseModel : BaseResponse<UserDto>
    {
        public UserDto Data { get; set; }
    }


    public class UsersResponseModels : BaseResponse<UserDto>
    {
        public IEnumerable<UserDto> Data { get; set; }
    }
}