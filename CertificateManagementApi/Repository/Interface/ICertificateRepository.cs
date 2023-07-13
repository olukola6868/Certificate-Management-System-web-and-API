using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CertificateManagementApi.Model;

namespace CertificateManagementApi.Repository.Interface
{
    public interface ICertificateRepository : IBaseRepository<Certificate>
    {
        Task<Certificate> Get(int id);
        Task<IList<Certificate>> GetAllGeneratedCertificates();
        Task<IList<Certificate>> GetAllUngeneratedCertificates(int organizationId);
        Task<Certificate> Get(Expression<Func<Certificate , bool>> expression);
        Task<IList<Certificate>> GetAll();
        Task UpdateCertToTrue(IList<Certificate> certificates);
    }
}