using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Models
{
    public class OrderProductDTO:BaseDTO
    {
        public OrderProductDTO()
        {

        }
        public OrderProductDTO(string orderId, string productId)
        {
            OrderId = orderId;
            ProductId = productId;
        }
        public int Number { get; set; }
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public uint Quantity { get; set; }
    }
}
