using Gyldendal.Customer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Gyldendal.Customer.Data.Repository;
using Gyldendal.Customer.Core.Enums;
using Gyldendal.Customer.Extentions;
using Gyldendal.Customer.Parameters;

namespace Gyldendal.Customer.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomersRepository _customersRepository;

        public HomeController(ILogger<HomeController> logger, 
            ICustomersRepository customersRepository)
        {
            _logger = logger;
            _customersRepository = customersRepository;
        }

        //[HttpPut]
        //[ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        [Route("customers/{customerId}/orders")]
        public async Task<IActionResult> Index()
        {
            var customerParams = new CustomerParameters();
            customerParams.Ssn = 12345678912;
            customerParams.FirstName = "ola";
            customerParams.LastName = "persen";
            customerParams.Email = "feil.ikkefeil@hei.com";
            customerParams.Type = CustomerTypeEnum.Student;

            Dictionary<string, string> errors = new Dictionary<string, string>();
            customerParams.ValidateEmail(errors).ValidateSsn(errors);
            if (errors.Any())
            {
                return View();
            }
            var newCustomer = customerParams.MapToCustomer();


            await _customersRepository.DeleteAsync(customerParams.Ssn);
            //await _customersRepository.UpsertAsync(newCustomer);
            


            var allCustomers = await _customersRepository.GetAllAsync();
            return View();
        }





        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}