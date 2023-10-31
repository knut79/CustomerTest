using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gyldendal.Customer.WebApi.Extensions;
using Gyldendal.Customer.WebApi.Parameters;

namespace Gyldendal.Customer.Test.WebApi
{
    [TestClass]
    public class CustomerParametersExtensionsTests
    {
        [TestMethod]
        public void ValidateSsn_Failes()
        {
            var errors = new Dictionary<string, string>();
            var classToTest = new CustomerParameters();
            classToTest.Ssn = "12345678912";
            var nameOfProperty = nameof(classToTest.Ssn);

            classToTest.ValidateSsn(errors);

            Assert.IsTrue(errors.ContainsKey(nameOfProperty));
            Assert.IsTrue(errors[nameOfProperty] != string.Empty);
            Assert.IsFalse(errors.ContainsKey(nameof(classToTest.Email)));
        }

        [TestMethod]
        public void ValidateSsn_Success()
        {
            var errors = new Dictionary<string, string>();
            var classToTest = new CustomerParameters();
            classToTest.Ssn = "02122718924";
            var nameOfProperty = nameof(classToTest.Ssn);

            classToTest.ValidateSsn(errors);

            Assert.IsFalse(errors.ContainsKey(nameOfProperty));
        }

        [TestMethod]
        public void ValidateEmail_Failes()
        {
            var errors = new Dictionary<string, string>();
            var classToTest = new CustomerParameters();
            classToTest.Email = "notValidEmail";
            var nameOfProperty = nameof(classToTest.Email);

            classToTest.ValidateEmail(errors);

            Assert.IsTrue(errors.ContainsKey(nameOfProperty));
            Assert.IsTrue(errors[nameOfProperty] != string.Empty);
            Assert.IsFalse(errors.ContainsKey(nameof(classToTest.Ssn)));
        }

        [TestMethod]
        public void ValidateEmail_Success()
        {
            var errors = new Dictionary<string, string>();
            var classToTest = new CustomerParameters();
            var nameOfProperty = nameof(classToTest.Email);
            classToTest.Email = "validEmail@mail.tv";
            
            classToTest.ValidateEmail(errors);

            Assert.IsFalse(errors.ContainsKey(nameOfProperty));
        }

        [TestMethod]
        public void ValidateEmail_longEmail_Success()
        {
            var errors = new Dictionary<string, string>();
            var classToTest = new CustomerParameters();
            var nameOfProperty = nameof(classToTest.Email);
            classToTest.Email = "valid.Email@mail.yyy";

            classToTest.ValidateEmail(errors);

            Assert.IsFalse(errors.ContainsKey(nameOfProperty));
        }
    }
}
