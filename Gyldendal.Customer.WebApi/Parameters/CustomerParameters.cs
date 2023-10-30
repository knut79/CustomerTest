using Gyldendal.Customer.Core.Enums;

namespace Gyldendal.Customer.WebApi.Parameters
{
    public class CustomerParameters
    {
        public string Ssn { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public CustomerTypeEnum Type { get; set; }
    }
}
