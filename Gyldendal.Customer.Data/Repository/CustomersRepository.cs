using Gyldendal.Customer.Data.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gyldendal.Customer.Data.Entities;

namespace Gyldendal.Customer.Data.Repository
{
    public class CustomersRepository: ICustomersRepository
    {
        private readonly DataContext _dataContext;

        public CustomersRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Entities.Customer>> GetAsync(int page, int pageSize)
        {
            var result = await _dataContext.customers.Skip(pageSize * (page-1)).Take(pageSize).ToListAsync();
            return result;
        }

        public async Task<int> TotalRecordsAsync()
        {
            return await _dataContext.customers.CountAsync();
        }

        public async Task<bool> UpsertAsync(Entities.Customer customer)
        {
            var existing = await _dataContext.customers.SingleOrDefaultAsync(l => l.ssn == customer.ssn);
            var create = false;
            if (existing != null)
            {
                existing.customertype = customer.customertype;
                existing.email = customer.email;
                existing.firstname = customer.firstname;
                existing.lastname = customer.lastname;
            }
            else
            {
                create = true;
                await _dataContext.AddAsync(customer);
            }
            await _dataContext.SaveChangesAsync();
            return create;
        }

        public async Task<bool> DeleteAsync(long ssn)
        {
            var found = false;
            var customerToDelete = await _dataContext.customers.SingleOrDefaultAsync(l => l.ssn == ssn);
            if (customerToDelete != null)
            {
                _dataContext.customers.Remove(customerToDelete);
                await _dataContext.SaveChangesAsync();
                found = true;
            }
            return found;
        }
    }

    public interface ICustomersRepository
    {
        Task<bool> DeleteAsync(long ssn);
        Task<bool> UpsertAsync(Entities.Customer customer);
        Task<List<Entities.Customer>> GetAsync(int page, int pageSize);
        Task<int> TotalRecordsAsync();
    }
}
