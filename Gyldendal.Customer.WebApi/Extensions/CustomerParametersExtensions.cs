using System.Text.RegularExpressions;
using Gyldendal.Customer.WebApi.Parameters;

namespace Gyldendal.Customer.WebApi.Extensions
{
    public static class CustomerParametersExtensions
    {

        public static CustomerParameters ValidateSsn(this CustomerParameters parameters, Dictionary<string, string> errors)
        {
            Regex regexSsn = new Regex(@"^(0[1-9]|[1-2][0-9]|31(?!(?:0[2469]|11))|30(?!02))(0[1-9]|1[0-2])(\d{2})(.?)(\d{5})$");
            Match matchSsn = regexSsn.Match(parameters.Ssn);
            var nameOfProperty = nameof(parameters.Ssn);
            if (!matchSsn.Success)
            {
                errors.Add(nameOfProperty, $"{parameters.Ssn} Not valid {nameOfProperty.ToLower()} format");
            }

            return parameters;
        }

        public static CustomerParameters ValidateEmail(this CustomerParameters parameters, Dictionary<string, string> errors)
        {
            var nameOfProperty = nameof(parameters.Email);
            if (string.IsNullOrEmpty(parameters.Email))
            {
                errors.Add(nameOfProperty, $"{nameOfProperty} is required");
            }
            else
            {
                Regex regexEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match matchEmail = regexEmail.Match(parameters.Email);
                if (!matchEmail.Success)
                {
                    errors.Add(nameOfProperty, $"{parameters.Email} Not valid {nameOfProperty.ToLower()} format");
                }
            }
            return parameters;
        }

        public static Data.Entities.Customer MapToCustomer(this CustomerParameters parameters)
        {
            var newCustomer = new Data.Entities.Customer
            {
                ssn = parameters.Ssn,
                firstname = parameters.FirstName,
                lastname = parameters.LastName,
                email = parameters.Email,
                customertypeid = (int)parameters.Type
            };
            return newCustomer;
        }
    }
}
