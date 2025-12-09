using System.ComponentModel.DataAnnotations;

namespace PermitApplication.Models
{
    /// <summary>
    /// Class to represent a permit type and county
    /// </summary>
    public class PermitTypeAndCounty
    {
        //[Required]
        public string PermitTypeName { get; set; }
        public int PermitTypeID { get; set; }

        //[Required]
        public string CountyName { get; set; }
        public int CountyID { get; set; }
    }
}
