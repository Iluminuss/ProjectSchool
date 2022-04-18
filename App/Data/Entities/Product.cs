using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    public class Product : Base
    {
        [Required][StringLength(128)] public string Name { get; set; }
        [Required][StringLength(256)] public string Description { get; set; }
        [Required][StringLength(32)] public string PortionSize { get; set; }
        [Required] public int Quantity { get; set; }
        [Required] public ICollection<OrderProduct> OrderProduct { get; set; }
    }
}
