using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CertificateManagementApi.Model;

namespace CertificateManagementApi.Repository.Interface
{
    public interface IOrganizationRepository : IBaseRepository<Organization>
    {
        Task<Organization> Get(int id);
        Task<IList<Organization>> GetUnapprovedOrganizations();
        Task<Organization> Get(Expression<Func<Organization, bool>> expression);
        Task<IList<Organization>> GetAll();
    }
}