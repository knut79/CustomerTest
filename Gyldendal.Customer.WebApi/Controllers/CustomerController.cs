using Gyldendal.Customer.Business.Wrappers;
using Gyldendal.Customer.Core.Dtos;
using Gyldendal.Customer.Core.Enums;
using Gyldendal.Customer.Core.Helpers;
using Gyldendal.Customer.WebApi.Dtos;
using Gyldendal.Customer.WebApi.Extensions;
using Gyldendal.Customer.WebApi.Parameters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Gyldendal.Customer.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomersRepositoryProxy _customersRepositoryProxy;

        public CustomerController(ICustomersRepositoryProxy customersRepositoryProxy)
        {
            _customersRepositoryProxy = customersRepositoryProxy;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResponse<List<CustomerDto>>>> GetAsync(int pageNumber, int pageSize, string? yearOfBirth, CustomerTypeEnum? type)
        {
            var customersPage = await _customersRepositoryProxy.GetAsync(pageNumber,pageSize,yearOfBirth,type);
            return customersPage;
        }

        [HttpPost]
        [Route("Upsert")]
        [ProducesResponseType(typeof(CustomerValidationErrorsDto), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(CustomerDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<CustomerDto>> UpsertAsync(CustomerParameters parameters)
        {
            Dictionary<string, string> errors = new Dictionary<string, string>();
            parameters.ValidateEmail(errors).ValidateSsn(errors);
            if (errors.Any())
            {
                return BadRequest(errors);

            }
            var customer = parameters.MapToCustomer();
            await _customersRepositoryProxy.UpsertAsync(customer);
            return Ok(customer);
        }


        [HttpDelete]
        [Route("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CustomerDto>> DeleteAsync(string ssn)
        {
            var found = await _customersRepositoryProxy.DeleteAsync(ssn);
            return found ? Ok() : NotFound(); 
        }
    }
}
