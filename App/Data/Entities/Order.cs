using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    public class Order : Base
    {
        [Required] public Employee Employee { get; set; }
        [Required][StringLength(256)] public string CustomerAddress{ get; set; }
        [Required][StringLength(32)] public string CustomerFirstName { get; set; }
        [Required][StringLength(32)] public string CustomerLastName { get; set; }
        [Required] public ICollection<OrderProduct> OrderProduct { get; set; }
    }
}
