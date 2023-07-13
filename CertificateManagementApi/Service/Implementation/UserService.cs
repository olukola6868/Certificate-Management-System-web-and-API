using CertificateManagementApi.Dtos;
using CertificateManagementApi.Repository.Interface;
using CertificateManagementApi.Service.Interface;

namespace CertificateManagementApi.Service.Implementation
{
     public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepository;
        public UserService(IUserRepository userRepository)
        {
            _UserRepository = userRepository;
        }
        public async Task<UserResponseModel> Get(int id)
        {
            var user = await _UserRepository.Get(id);
            if (user != null)
            {
                return new UserResponseModel
                {
                    Message = "Successful",
                    Status = true,
                    Data = new UserDto
                    {
                        Id = user.Id,
                        EmailAddress = user.EmailAddress,
                        Password = user.Password,
                        Address = user.Address,
                        PhoneNumber = user.PhoneNumber,
                    }
                };
            }
            return new UserResponseModel
            {
                Message = "User not found",
                Status = false
            };
        }

        public async Task<UsersResponseModels> GetAll()
        {
            var users = await _UserRepository.GetAll();
            var listOfUsers = users.ToList().Select(user => new UserDto
            {
                Id = user.Id,
                EmailAddress = user.EmailAddress,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address
            });
            return new UsersResponseModels
            {
                Message = "ok",
                Status = true,
                Data = listOfUsers
            };
        }

        public async Task<BaseResponse<LoginUserModel>> Login(LoginUserRequestModel model)
        {
            var user = await _UserRepository.Get(a => a.EmailAddress == model.EmailAddress && a.Password == model.Password);
            if (user == null)
            {
                return new BaseResponse<LoginUserModel>
                {
                    Message = "user not found",
                    Status = false
                };
            }
            if (user.Organization == null)
            {
                return new BaseResponse<LoginUserModel>
                {
                    Message = "Login Successful",
                    Status = true,
                    Data = new LoginUserModel
                    {
                        Id = user.Id,
                        EmailAddress = user.EmailAddress,
                        Password = user.Password,
                        PhoneNumber = user.PhoneNumber,
                        Address = user.Address,
                        Roles = user.UserRoles.Select(a => new RoleDto
                        {
                            Id = a.Role.Id,
                            Name = a.Role.Name,
                            Description = a.Role.Description
                        }).ToList(),
                    }
                };
            };

            if (user.Organization.isApproved == false) return new BaseResponse<LoginUserModel>
            {
                Message = "User not approved",
                Status = false
            };
            return new BaseResponse<LoginUserModel>
            {
                Message = "Login Successful",
                Status = true,
                Data = new LoginUserModel
                {
                    Id = user.Id,
                    EmailAddress = user.EmailAddress,
                    Password = user.Password,
                    PhoneNumber = user.PhoneNumber,
                    Address = user.Address,
                    UserId = user.Organization.Id,
                    Roles = user.UserRoles.Select(a => new RoleDto
                    {
                        Id = a.Role.Id,
                        Name = a.Role.Name,
                        Description = a.Role.Description
                    }).ToList(),
                }
            };
        }
    }
}