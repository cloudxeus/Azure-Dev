using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosDB
{
    class Activity
    {
        public string id { get; set; }
        public string Correlationid { get; set; }        
        public string Operationname { get; set; }
        public string  Status { get; set; }        
        public string Eventcategory { get; set; }
        public string Level { get; set; }
    }
}
