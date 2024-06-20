using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace VehicleApp_SiskonAutomation.Models
{
    public class PlateAttribute : ValidationAttribute
    {
        private const string PlatePattern = @"^\d{2} [A-Z]{1,3} \d{2,4}$"; // RegEx For Turkish Plate Standard

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return new ValidationResult("Plate is required.");
            }

            var plate = value.ToString();
            if (!Regex.IsMatch(plate, PlatePattern))
            {
                return new ValidationResult("Plate is not in the correct format. The correct format is '35 ABC 123'.");
            }

            return ValidationResult.Success;
        }
    }
}
