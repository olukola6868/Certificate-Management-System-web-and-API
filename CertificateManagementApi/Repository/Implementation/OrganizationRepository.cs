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
    public class OrganizationRepository : BaseRepsitory<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(CertificateContextClass context)
        {
            _context = context;
        }
        public async Task<Organization> Get(int id)
        {
            return await _context.Organizations
                .Include(c => c.Certificates)
                .Include(c => c.User)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Organization> Get(Expression<Func<Organization, bool>> expression)
        {
             return await _context.Organizations
                .Include(c => c.Certificates)
                .Include(c => c.User)
                .FirstOrDefaultAsync(expression);
        }

        public async Task<IList<Organization>> GetAll()
        {
            return await _context.Organizations
               .Include(c => c.User)
               .Include(c => c.Certificates)
               .ToListAsync();
        }

        public async Task<IList<Organization>> GetUnapprovedOrganizations()
        {
             return await _context.Organizations.Where(x => x.isApproved == false)
                .Include(c => c.User)
                .ToListAsync();
        }
    }
}