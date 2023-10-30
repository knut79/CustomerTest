using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gyldendal.Customer.Data.DbContext;
using Gyldendal.Customer.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace Gyldendal.Customer.Test.Data
{
    [TestClass]
    public class CustomerRepositoryTests
    {
        DataContext _dataContext;
        CustomersRepository _customerRepository;

        private DataContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString("N")).Options;
            var dbContext = new DataContext(options);
            return dbContext;
        }

        [TestMethod]
        public async Task SaveReceiptAsync_successfullySave()
        {
            _dataContext = CreateDbContext();
            _customerRepository = new CustomersRepository(_dataContext);
            var ssnForThisTest = "999";
            var customerEntity = new Customer.Data.Entities.Customer
            {
                ssn = "ssnForThisTest",
                customertypeid = 1,
                email = "test@test.no",
                firstname = "test",
                lastname = "test"
            };

            var isCreated = await _customerRepository.UpsertAsync(customerEntity);

            Assert.IsTrue(isCreated);
            var customers = await _customerRepository.GetAsync(1, 1);
            Assert.AreEqual(customers[0].ssn, customerEntity.ssn);

            //clean up
            await _customerRepository.DeleteAsync(ssnForThisTest);
            _dataContext.Dispose();
        }
    }
}
