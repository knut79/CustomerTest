using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gyldendal.Customer.Business.Extensions;
using Gyldendal.Customer.Core.Dtos;
using Gyldendal.Customer.Core.Enums;
using Gyldendal.Customer.Core.Exceptions;
using Gyldendal.Customer.Core.Helpers;
using Gyldendal.Customer.Data.Repository;
using Microsoft.Extensions.Caching.Memory;

namespace Gyldendal.Customer.Business.Wrappers
{
    public class CustomersRepositoryProxy : ICustomersRepositoryProxy
    {
        private readonly ICustomersRepository _customersRepository;
        public CustomersRepositoryProxy(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public async Task<bool> DeleteAsync(string ssn)
        {
            try
            {
                return await _customersRepository.DeleteAsync(ssn);
            }
            catch
            {
                throw new CustomDbException();
            }
        }

        public async Task<bool> UpsertAsync(Data.Entities.Customer customer)
        {
            try
            {
                return await _customersRepository.UpsertAsync(customer);
            }
            catch 
            {
                throw new CustomDbException();
            }
        }

        public async Task<PagedResponse<List<CustomerDto>>> GetAsync(int page, int pagesize, string? yearOfBirth, CustomerTypeEnum? type)
        {
            try
            {
                var customers = await _customersRepository.GetAsync(page, pagesize,yearOfBirth,type);
                var totalRecords = await _customersRepository.TotalRecordsAsync(yearOfBirth,type);
                var customerDtos = customers.MapToCustomerDtos();
                var response = new PagedResponse<List<CustomerDto>>(customerDtos, page, pagesize, totalRecords);
                return response;
            }
            catch 
            {
                throw new CustomDbException($"Failed with get customers page{page} pagesize{pagesize}");
            }
        }
    }

    public interface ICustomersRepositoryProxy
    {
        Task<bool> DeleteAsync(string ssn);
        Task<bool> UpsertAsync(Data.Entities.Customer customer);
        Task<PagedResponse<List<CustomerDto>>> GetAsync(int page, int pagesize, string? yearOfBirth, CustomerTypeEnum? type);
    }
}
