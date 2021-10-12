using StackExchange.Redis;
using System;

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

            //cache.StringSet("Course Name", "AZ-204 - Develoing Azure solutions");


            //cache.KeyExpire("Course Name", new TimeSpan(0, 0, 30));
            if (cache.KeyExists("Course Name"))
            Console.WriteLine(cache.StringGet("Course Name"));
            else
                Console.WriteLine("Key does not exist");
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
