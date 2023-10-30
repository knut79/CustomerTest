using Microsoft.EntityFrameworkCore;
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
    [Index(nameof(ssn), IsUnique = true)]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int customerid { get; set; }

        
        [Required]
        public string ssn { get; set; }

        [Required]
        public string firstname { get; set; }
        [Required]
        public string lastname { get; set; }
        public string? email { get; set; } = string.Empty;

        public int? customertypeid { get; set; }
        public CustomerType customertype { get; set; }
    }
}
