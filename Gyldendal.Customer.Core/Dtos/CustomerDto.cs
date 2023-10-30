using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gyldendal.Customer.Core.Enums;

namespace Gyldendal.Customer.Core.Dtos
{
    public class CustomerDto
    {
        public string Ssn { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public CustomerTypeEnum CustomerType { get; set; }
    }
}
