using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyldendal.Customer.Core.Exceptions
{
    public class CustomDbException : System.Exception
    {
        public int StatusCode;
        
        public CustomDbException(string errorMsg = "") : base(errorMsg)
        {
            StatusCode = 500;
        }
    }
}
