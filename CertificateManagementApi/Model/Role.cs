using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CertificateManagementApi.Model
{
    public class Role : BaseEntity
    {
        public string Name{get;set;}
        public string Description{get;set;}
        public IList<UserRole> UserRoles { get; set; }
    }
}