using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CertificateManagementApi.Model
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool isDeleted { get; set; }
    }
}