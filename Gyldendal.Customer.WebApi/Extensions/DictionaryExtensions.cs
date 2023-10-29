using Gyldendal.Customer.WebApi.Dtos;

namespace Gyldendal.Customer.WebApi.Extensions
{
    public static class DictionaryExtensions
    {
        public static CustomerValidationErrorsDto MapToCustomerValidationErrorDto(
            this Dictionary<string, string> dictionary)
        {
            var emailKey = "email";
            var ssnKey = "ssn";
            var returnType = new CustomerValidationErrorsDto();
            if (dictionary.ContainsKey(emailKey))
            {
                returnType.Email = dictionary[emailKey];
            }

            if (dictionary.ContainsKey(ssnKey))
            {
                returnType.Ssn = dictionary[ssnKey];
            }
            return returnType;
        }
    }
}
