using Gyldendal.Customer.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gyldendal.Customer.Core.Enums;

namespace Gyldendal.Customer.Business.Extensions
{
    public static class CustomerExtensions
    {
        public static List<CustomerDto> MapToCustomerDtos(this List<Data.Entities.Customer> customers)
        {
            return customers.Select(customer => customer.MapToCustomerDto()).ToList();
        }

        public static CustomerDto MapToCustomerDto(this Data.Entities.Customer customer)
        {
            var customerDto = new CustomerDto();
            customerDto.ssn = customer.ssn;
            customerDto.FirstName = customer.email;
            customerDto.LastName = customer.lastname;
            customerDto.Email = customer.email;
            customerDto.CustomerType = (CustomerTypeEnum) customer.customertypeid;
            return customerDto;
        }
    }
}
