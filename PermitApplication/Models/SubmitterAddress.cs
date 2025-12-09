using System.ComponentModel.DataAnnotations;

namespace PermitApplication.Models
{
    public class SubmitterAddress
    {
        [Required]
        public string? FullUSPSAddress { get; set; }

        /* Use the properties below for split USPS address using
         * https://www.usps.com/business/web-tools-apis/ */

        //public string Street { get; set; }
        //public string City { get; set; }
        //public string State { get; set; }
        //public string ZipCode { get; set; }
    }
}
