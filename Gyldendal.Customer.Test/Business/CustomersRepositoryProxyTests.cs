using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gyldendal.Customer.Business.Wrappers;
using Gyldendal.Customer.Core.Dtos;
using Gyldendal.Customer.Data.Repository;
using Moq;

namespace Gyldendal.Customer.Test.Business
{
    [TestClass]
    public class CustomersRepositoryProxyTests
    {
        private Mock<ICustomersRepository> _customersRepositoryMock;


        [TestMethod]
        public async Task UpsertAsync_Verify_Call()
        {
            var expectedResult = false;
            _customersRepositoryMock = new Mock<ICustomersRepository>();
            _customersRepositoryMock.Setup(l => l.UpsertAsync(It.IsAny<Customer.Data.Entities.Customer>()))
                .ReturnsAsync(expectedResult);
            var classToTest = new CustomersRepositoryProxy(_customersRepositoryMock.Object);

            var result = await classToTest.UpsertAsync(It.IsAny<Customer.Data.Entities.Customer>());

            Assert.IsTrue(result == expectedResult);
            _customersRepositoryMock.Verify(l=>l.
                UpsertAsync(It.IsAny<Customer.Data.Entities.Customer>()), Times.Once);
        }

        [TestMethod]
        public async Task GetAsync_Assert_Calls()
        {
            var page = 1;
            var pageSize = 10;
            var customers = new List<Customer.Data.Entities.Customer>();
            var customer = new Customer.Data.Entities.Customer
            {
                customertypeid = 1,
                email = "email",
                firstname = "firstname",
                lastname = "lastname",
                ssn = "123"
            };
            customers.Add(customer);
            _customersRepositoryMock = new Mock<ICustomersRepository>();
            _customersRepositoryMock.Setup(l => l.TotalRecordsAsync()).ReturnsAsync(100);
            _customersRepositoryMock.Setup(l => l.GetAsync(page,pageSize)).ReturnsAsync(new List<Customer.Data.Entities.Customer>());
            _customersRepositoryMock = new Mock<ICustomersRepository>();
            var classToTest = new CustomersRepositoryProxy(_customersRepositoryMock.Object);

            var result = await classToTest.GetAsync(page, pageSize);

            _customersRepositoryMock.Verify(l=>l.TotalRecordsAsync(),Times.Once);
            _customersRepositoryMock.Verify(l=>l.GetAsync(page,pageSize),Times.Once);
            Assert.AreEqual(customer.firstname, result.Data[0].FirstName);
            Assert.AreEqual(customer.lastname, result.Data[0].LastName);
            Assert.AreEqual(customer.email, result.Data[0].Email);
            Assert.AreEqual(customer.ssn, result.Data[0].Ssn);
        }
    }
}
