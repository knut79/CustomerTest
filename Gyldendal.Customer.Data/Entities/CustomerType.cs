using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyldendal.Customer.Data.Entities
{
    public class CustomerType
    {
        [Key]
        public int customertypeid { get; set; }
        public string name { get; set; }
        public ICollection<Customer> customers { get; set; }
    }
}
