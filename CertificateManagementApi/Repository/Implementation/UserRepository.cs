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
    public class UserRepository : BaseRepsitory<User>, IUserRepository
    {
        public UserRepository(CertificateContextClass context)
        {
            _context = context;
        }
        public async Task<User> Get(int id)
        {
            return await _context.Users
               .Include(c => c.UserRoles)
               .ThenInclude(c => c.Role)
               .Include(c => c.Organization)
               .Include(c => c.Admin)
               .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<User> Get(Expression<Func<User, bool>> expression)
        {
            return await _context.Users
               .Include(c => c.UserRoles)
                .ThenInclude(c => c.Role)
                .Include(c => c.Organization)
                .Include(c => c.Admin)
                .FirstOrDefaultAsync(expression);
        }

        public async Task<IList<User>> GetAll()
        {
            return await _context.Users
               .Include(c => c.UserRoles)
                .ThenInclude(c => c.Role)
                .Include(c => c.Organization)
                .Include(c => c.Admin)
                .ToListAsync();
        }
    }
}