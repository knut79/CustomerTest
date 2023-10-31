using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Gyldendal.Customer.Core.Enums;
using Gyldendal.Customer.Data.DbContext;
using Gyldendal.Customer.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace Gyldendal.Customer.Test.Data
{
    [TestClass]
    public class CustomerRepositoryTests
    {
        private DataContext _dataContext;
        private CustomersRepository _customerRepository;
        private List<string> _customerSsns;

        [TestInitialize]
        public async Task InitAsync()
        {
            _customerSsns = new List<string>();
            _customerSsns.Add("18019503301");
            _customerSsns.Add("30102210103");
            _customerSsns.Add("14111553069");
            _customerSsns.Add("01083337679");
            _customerSsns.Add("05087545107");
            _customerSsns.Add("23037513717");
            _dataContext = CreateDbContext();
            _customerRepository = new CustomersRepository(_dataContext);
            var typeId = 1;
            foreach (var customerSsn in _customerSsns)
            {
                var customerEntity = new Customer.Data.Entities.Customer
                {
                    ssn = customerSsn,
                    customertypeid = typeId,
                    email = "test@test.no",
                    firstname = "test",
                    lastname = "test"
                };
                typeId = ((typeId + 1) % 3) + 1;
                await _customerRepository.UpsertAsync(customerEntity);

            }

        }

        private DataContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString("N"));
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            var dbContext = new DataContext(optionsBuilder.Options);
            return dbContext;
        }

        [TestMethod]
        public async Task Get_withoutFilter_AllRecords()
        {
            var customers = await _customerRepository.GetAsync(1, _customerSsns.Count, string.Empty, null);

            Assert.AreEqual(customers.Count, _customerSsns.Count);
        }

        [TestMethod]
        public async Task Get_filterOnYear_SomeRecords()
        { 
            var customers = await _customerRepository.GetAsync(1, _customerSsns.Count, "1995", null);
            
            Assert.AreEqual(customers.Count, 1);
        }

        [TestMethod]
        public async Task Get_filterOntype_SomeRecords()
        {
            var customers = await _customerRepository.GetAsync(1, _customerSsns.Count, string.Empty, CustomerTypeEnum.Bedrift);
            
            Assert.AreEqual(customers.Count, 2);
        }

        [TestCleanup]
        public async Task CleanUp()
        {
            foreach (var customerSsn in _customerSsns)
            {
                //await _customerRepository.DeleteAsync(customerSsn);

            }
            _dataContext.Dispose();
        }
    }
}
