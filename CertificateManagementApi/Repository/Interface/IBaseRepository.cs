using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CertificateManagementApi.Repository.Interface
{
    public interface IBaseRepository<T>
    {
        Task<T> Create(T entity);
        Task<T> Update(T entity);
    }
}