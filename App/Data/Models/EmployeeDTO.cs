using System.ComponentModel.DataAnnotations;

namespace App.Data.Models
{
    public class EmployeeDTO : BaseDTO
    {
        [Required][StringLength(32)] public string FirstName { get; set; }
        [Required][StringLength(32)] public string LastName { get; set; }
    }
}
