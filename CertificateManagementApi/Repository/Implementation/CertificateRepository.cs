using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CertificateManagementApi.ApplicationContext;
using CertificateManagementApi.Model;
using CertificateManagementApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CertificateManagementApi.Repository.Implementation
{
    public class CertificateRepository : BaseRepsitory<Certificate>, ICertificateRepository
    {
         public CertificateRepository(CertificateContextClass context)
        {
            _context = context;
        }
        public async Task<Certificate> Get(int id)
        {
             return await _context.Certificates
               .Include(c => c.Organization)
               .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Certificate> Get(Expression<Func<Certificate, bool>> expression)
        {
             return await _context.Certificates
                .Include(c => c.Organization)
                .FirstOrDefaultAsync(expression);
        }

        public async Task<IList<Certificate>> GetAll()
        {
             return await _context.Certificates
                .Include(c => c.Organization)
                .ToListAsync();
        }

       public async Task<IList<Certificate>> GetAllGeneratedCertificates()
        {
             return await _context.Certificates.Where(x => x.isGenerated == true)
                .Include(c => c.Organization)
                .ToListAsync();
        }

        public async Task<IList<Certificate>> GetAllUngeneratedCertificates(int organizationId)
        {
             return await _context.Certificates
                .Include(c => c.Organization)
                .Where(x => x.isGenerated == false && x.OrganizationId == organizationId)
                .ToListAsync();
        }

        public async Task UpdateCertToTrue(IList<Certificate> certificates)
        {
            _context.UpdateRange(certificates);
            await _context.SaveChangesAsync();
        }
    }
}
