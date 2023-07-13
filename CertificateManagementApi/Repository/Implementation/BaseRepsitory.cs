using CertificateManagementApi.ApplicationContext;
using CertificateManagementApi.Model;
using CertificateManagementApi.Repository.Interface;

namespace CertificateManagementApi.Repository.Implementation
{
    public class BaseRepsitory<T> : IBaseRepository<T> where T : BaseEntity, new()
    {
        protected CertificateContextClass _context;
        public async Task<T> Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}