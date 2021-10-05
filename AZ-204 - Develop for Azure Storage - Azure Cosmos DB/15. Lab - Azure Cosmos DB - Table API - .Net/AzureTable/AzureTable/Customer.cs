using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureTable
{
    class Customer: TableEntity
    {
        public string customerid { get; set; }       

        public Customer(string _customername,string _city)
        {
            PartitionKey = _city;
            RowKey = _customername;
        }
    }
}
