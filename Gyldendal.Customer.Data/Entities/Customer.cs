using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyldendal.Customer.Data.Entities
{
    public class Customer
    {
        [Key]
        [Required]
        public long ssn { get; set; }

        [Required]
        [Column("firstname")]
        public string firstname { get; set; }
        [Required]
        public string lastname { get; set; } 
        public string? email { get; set; } = string.Empty;

        public int? customertypeid { get; set; }
        public CustomerType customertype { get; set; }
    }
}
