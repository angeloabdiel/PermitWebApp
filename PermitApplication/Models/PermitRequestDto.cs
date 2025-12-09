using System.ComponentModel.DataAnnotations;

namespace PermitApplication.Models
{
    /// <summary>
    /// DTO class to manage data that will be encapsulated for permit request submission
    /// </summary>
    public class PermitRequestDto
    {
        [Required]
        public string FirstName { get; set; } = "";

        [Required]
        public string LastName { get; set; } = "";

        [Required]
        public string FullUSPSAddress { get; set; } = "";

        [Required]
        public int Type_ID { get; set; }

        [Required]
        public int County_ID { get; set; }
    }
}
