using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CertificateManagementApi.Model
{
    public class Admin : BaseEntity
    {
        public string FirstName{get;set;}
        public string LastName { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}