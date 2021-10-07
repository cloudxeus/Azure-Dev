using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunction_QueueTrigger_Table
{
    public class Order
    {
        // This will map to the Category property of the data
        public string PartitionKey { get; set; }
        // This will map to the Order ID property of the data
        public string RowKey { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
