using System.ComponentModel.DataAnnotations;
using System.Net;

namespace PermitApplication.Models
{
    /// <summary>
    /// Class to represent a submitter user and their details
    /// </summary>
    public class SubmitterUser
    {
        [Required]
        public string? FirstName { get; set; } = "";

        [Required]
        public string? LastName { get; set; } = "";

        [Required]
        public SubmitterAddress Address { get; set; } = new();

        public PermitTypeAndCounty PermitType { get; set; } = new();

        public PermitTypeAndCounty County { get; set; } = new();
    }
}
