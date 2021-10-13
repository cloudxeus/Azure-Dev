using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace AzureEventHub_Send
{
    class Order
    {
        public string OrderID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string DiscountCategory { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }

    
}
