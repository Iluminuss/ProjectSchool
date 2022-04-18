using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Models
{
    public class CookedFoodDTO : BaseDTO
    {
        [Required] public string ProductId{ get; set; }
        [Required] public int Quantity { get; set; }
    }
}
