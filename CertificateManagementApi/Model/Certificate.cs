using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CertificateManagementApi.Model
{
    public class Certificate : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Date { get; set; }
        public bool isGenerated{get;set;}
        public string Signature { get; set; }
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }

    }
}