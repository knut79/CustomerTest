using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Gyldendal.Customer.Core.Enums;
using Gyldendal.Customer.Core.Parameters;

namespace Gyldendal.Customer.Core.Extentions
{
    //public static class CustomerParametersExtentions
    //{
    //    public static Dictionary<string, string> Validate(this CustomerParameters parameters)
    //    {
    //        Dictionary<string, string> errors = new Dictionary<string, string>();
    //        Regex regexEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
    //        Match matchEmail = regexEmail.Match(parameters.Email);
    //        if (!matchEmail.Success)
    //        {
    //            errors.Add("email", $"{parameters.Email}Not valid email format");
    //        }

    //        Regex regexSsn = new Regex(@"^(?=\d{11}$)0*[1-9]*$");
    //        //Regex regexSsn = new Regex(@"^(0[1-9]|[1-2][0-9]|31(?!(?:0[2469]|11))|30(?!02))(0[1-9]|1[0-2])(\d{2})(.?)(\d{5})$");
    //        Match matchSsn = regexSsn.Match(parameters.Ssn.ToString());
    //        if (!matchSsn.Success)
    //        {
    //            errors.Add("ssn", $"{parameters.Ssn.ToString()} Not valid ssn format");
    //        }

    //        return errors;
    //    }

    //    public static Customer MapToCustomer(this CustomerParameters parameters)
    //    {
    //        var newCustomer = new Data.Entities.Customer
    //        {
    //            ssn = 12345,
    //            firstname = "knutb",
    //            lastname = "hansenb",
    //            email = "cb",
    //            customertypeid = (int)CustomerTypeEnum.Bedrift
    //        };
    //    }
    //}
}
