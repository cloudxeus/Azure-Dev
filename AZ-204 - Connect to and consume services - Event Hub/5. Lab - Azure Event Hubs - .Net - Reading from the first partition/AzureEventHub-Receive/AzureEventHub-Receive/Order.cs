using System;
using System.Collections.Generic;
using System.Text;

namespace AzureEventHub_Receive
{
    class Order
    {
        public string OrderID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string DiscountCategory { get; set; }
    }
}
