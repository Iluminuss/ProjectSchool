using System.ComponentModel.DataAnnotations;

namespace App.Data.Entities
{
    public class Employee : Base
    {
        [Required][StringLength(32)] public string FirstName { get; set; }
        [Required][StringLength(32)] public string LastName { get; set; }
    }
}
