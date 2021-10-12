using StackExchange.Redis;
using System;
using System.Text.Json;

namespace AzureCache
{
    class Program
    {
        private static Lazy<ConnectionMultiplexer> cache_connection = CreateConnection();
        public static ConnectionMultiplexer Connection
        {
            get
            {
                return cache_connection.Value;
            }
        }
        static void Main(string[] args)
        {
            IDatabase cache = Connection.GetDatabase();

            Order _order =
                new Order() { OrderID = "O1", Quantity = 10, UnitPrice = 9.99m };

            cache.StringSet(_order.OrderID, JsonSerializer.Serialize<Order>(_order));

            // Getting the object back

            Order get_order = JsonSerializer.Deserialize<Order>(cache.StringGet(_order.OrderID));

            Console.WriteLine($"The Order id is {get_order.OrderID}");
            Console.WriteLine($"The Order Quantity is {get_order.Quantity}");
            Console.WriteLine($"The Order Unit price is {get_order.UnitPrice}");

            Console.ReadKey();

        }

        private static Lazy<ConnectionMultiplexer> CreateConnection()
        {
            string cache_connectionstring = "newcache1000.redis.cache.windows.net:6380,password=lSpWcGeFeXDojdbJZtrMdISlVmyUhsIPDXTaMvZ0m1g=,ssl=True,abortConnect=False";
            return new Lazy<ConnectionMultiplexer>(() =>
            {                
                return ConnectionMultiplexer.Connect(cache_connectionstring);
            });
        }
    }
}
