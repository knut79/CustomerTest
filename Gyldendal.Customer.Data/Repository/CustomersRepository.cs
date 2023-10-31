using Gyldendal.Customer.Data.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gyldendal.Customer.Data.Entities;
using Gyldendal.Customer.Core.Enums;
using System.Xml;
using Microsoft.EntityFrameworkCore.Internal;

namespace Gyldendal.Customer.Data.Repository
{
    public class CustomersRepository: ICustomersRepository
    {
        private readonly DataContext _dataContext;
        private readonly Func<Entities.Customer, string, bool> _filterYear = (customer, yob) => yob.Substring(2, 3).Contains(customer.ssn.Substring(4, 6));
        private readonly Func<Entities.Customer, CustomerTypeEnum?, bool> _filterType = (customer, custType) => customer.customertypeid == (int)custType;

        public CustomersRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Entities.Customer>> GetAsync(int page, int pageSize, string? yearOfBirth, CustomerTypeEnum? type)
        {
            //IQueryable<Entities.Customer> onYearOfBirth = string.IsNullOrEmpty(yearOfBirth) ?
            //    _dataContext.customers.AsQueryable() :
            //    _dataContext.customers
            //    .Where(l => yearOfBirth.Substring(2, 2).Equals(l.ssn.Substring(4, 2)));

            //IQueryable<Entities.Customer> onSsn = type == null
            //    ? _dataContext.customers.AsQueryable()
            //    : _dataContext.customers.Where(l => l.customertypeid == (int)type);


            //var innerJoin = onYearOfBirth.Join(onSsn,
            //    str1 => str1,
            //    str2 => str2,
            //    (str1, str2) => str1);

            var result = await FilterData(yearOfBirth, type)
            .Skip(pageSize * (page - 1)).Take(pageSize).ToListAsync();

            return result;
        }

        //public List<Entities.Customer> Get(int page, int pageSize, string yearOfBirth, CustomerTypeEnum? type)
        //{
        //    IQueryable<Entities.Customer> onYearOfBirth = string.IsNullOrEmpty(yearOfBirth) ?
        //        _dataContext.customers.AsQueryable() :
        //        _dataContext.customers
        //            .Where(l => _filterYear(l, yearOfBirth));

        //    IQueryable<Entities.Customer> onSsn = type == null
        //        ? _dataContext.customers.AsQueryable()
        //        : _dataContext.customers.Where(l => _filterType(l, type));


        //    var innerJoin = onYearOfBirth.Join(onSsn,
        //        str1 => str1,
        //        str2 => str2,
        //        (str1, str2) => str1);

        //    var result = innerJoin
        //        .Skip(pageSize * (page - 1)).Take(pageSize).ToList();

        //    return result;
        //}

        public async Task<int> TotalRecordsAsync( string yearOfBirth, CustomerTypeEnum? type)
        {

            return await FilterData(yearOfBirth, type).CountAsync();
        }

        public IQueryable<Entities.Customer> FilterData(string yearOfBirth, CustomerTypeEnum? type)
        {
            IQueryable<Entities.Customer> onYearOfBirth = string.IsNullOrEmpty(yearOfBirth) ?
                _dataContext.customers.AsQueryable() :
                _dataContext.customers
                    .Where(l => yearOfBirth.Substring(2, 2).Equals(l.ssn.Substring(4, 2)));

            IQueryable<Entities.Customer> onSsn = type == null
                ? _dataContext.customers.AsQueryable()
                : _dataContext.customers.Where(l => l.customertypeid == (int)type);


            var innerJoin = onYearOfBirth.Join(onSsn,
                str1 => str1,
                str2 => str2,
                (str1, str2) => str1);
            return innerJoin;
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
                _dataContext.customers.Update(existing);
            }
            else
            {
                create = true;
                await _dataContext.AddAsync(customer);
            }
            await _dataContext.SaveChangesAsync();
            return create;
        }

        public async Task<bool> DeleteAsync(string ssn)
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
        Task<bool> DeleteAsync(string ssn);
        Task<bool> UpsertAsync(Entities.Customer customer);
        Task<List<Entities.Customer>> GetAsync(int page, int pageSize,string yearOfBirth, CustomerTypeEnum? type);
        Task<int> TotalRecordsAsync(string yearOfBirth, CustomerTypeEnum? type);
    }
}
