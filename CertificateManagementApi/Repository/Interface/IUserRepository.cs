using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CertificateManagementApi.Model;

namespace CertificateManagementApi.Repository.Interface
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> Get(int id);
        Task<User> Get(Expression<Func<User, bool>> expression);
        Task<IList<User>> GetAll();
    }
}