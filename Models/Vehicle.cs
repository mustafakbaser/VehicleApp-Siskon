using System.ComponentModel.DataAnnotations;

namespace VehicleApp_SiskonAutomation.Models
{
    public class Vehicle
    {
        [Key]
        [Required]
        [Plate]
        public string Plate { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nickname of Vehicle")]
        public string Nickname { get; set; }

        [Required]
        [StringLength(100)]
        public string Brand { get; set; }

        [Required]
        [StringLength(100)]
        public string Model { get; set; }

        [Required]
        [Range(1900, 2100)]
        [Display(Name = "Model Year")]
        public int ModelYear { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Vehicle Type")]
        public string VehicleType { get; set; }

        [Required]
        [StringLength(50)]
        public string Color { get; set; }

        [Required]
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
    }
}
