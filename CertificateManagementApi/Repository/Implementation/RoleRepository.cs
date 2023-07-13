using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CertificateManagementApi.ApplicationContext;
using CertificateManagementApi.Model;
using CertificateManagementApi.Repository.Implementation;
using CertificateManagementApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CertificateManagementApi.Repository
{
    public class RoleRepository : BaseRepsitory<Role>, IRoleRepository
    {
        public RoleRepository(CertificateContextClass context)
        {
            _context = context;
        }
        public async Task<Role> Get(int id)
        {
             return await _context.Roles
                .Include(c => c.UserRoles)
                .ThenInclude(c => c.User)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Role> Get(Expression<Func<Role, bool>> expression)
        {
             return await _context.Roles
                .Include(c => c.UserRoles)
                .ThenInclude(c => c.User)
                .FirstOrDefaultAsync(expression);
        }

        public async Task<IList<Role>> GetAll()
        {
            return await _context.Roles
                .Include(c => c.UserRoles)
                .ThenInclude(c => c.User)
                .ToListAsync();
        }
    }
}