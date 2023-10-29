using Gyldendal.Customer.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Gyldendal.Customer.Dto
{
    public class CustomerDto
    {
        public long ssn { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; } 

        public CustomerType CustomerType { get; set; }
    }
}
