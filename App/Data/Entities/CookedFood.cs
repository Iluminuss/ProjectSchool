using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    public class CookedFood : Base
    {
        [Required] public Product Product{ get; set; }
        [Required] public int Quantity { get; set; }
    }
}
