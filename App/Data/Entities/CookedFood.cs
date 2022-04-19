using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    public class CookedFood : Base
    {
        [ForeignKey("CookedFood_ProductId_FK")]
        [Required] public Product Product{ get; set; }
        [Required] public int Quantity { get; set; }
    }
}
