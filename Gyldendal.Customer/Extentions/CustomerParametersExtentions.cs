using System.Text;
using Gyldendal.Customer.Core.Enums;
using Gyldendal.Customer.Parameters;
using System.Text.RegularExpressions;

namespace Gyldendal.Customer.Extentions
{
    public static class CustomerParametersExtentions
    {

        public static CustomerParameters ValidateSsn(this CustomerParameters parameters, Dictionary<string, string> errors)
        {
            Regex regexSsn = new Regex(@"^(?=\d{11}$)0*[1-9]*$");
            //Regex regexSsn = new Regex(@"^(0[1-9]|[1-2][0-9]|31(?!(?:0[2469]|11))|30(?!02))(0[1-9]|1[0-2])(\d{2})(.?)(\d{5})$");
            Match matchSsn = regexSsn.Match(parameters.Ssn.ToString());
            if (!matchSsn.Success)
            {
                errors.Add("ssn", $"{parameters.Ssn.ToString()} Not valid ssn format");
            }

            return parameters;
        }

        public static CustomerParameters ValidateEmail(this CustomerParameters parameters, Dictionary<string,string> errors)
        {
            if (string.IsNullOrEmpty(parameters.Email))
            {
                errors.Add("email","Email is required");
            }
            else
            {
                Regex regexEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match matchEmail = regexEmail.Match(parameters.Email);
                if (!matchEmail.Success)
                {
                    errors.Add("email", $"{parameters.Email}Not valid email format");
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
