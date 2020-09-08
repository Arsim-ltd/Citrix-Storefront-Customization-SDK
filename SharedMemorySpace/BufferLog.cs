using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Citrix.DeliveryServices.ResourcesCommon.Customization.Contract;

namespace SharedMemorySpace
{
    public static class LogBuffer
    {
        public static ConcurrentQueue<string> Log = new ConcurrentQueue<string>();
        public static string LoggingEnabled;

        
        public static void Add(string data)
        {
            Log.Enqueue(data);
        }

        public static List<string> Get()
        {
            List<string> LogList = new List<string>();
            string line;
            while (Log.TryDequeue(out line))
            {
                LogList.Add(line);
            }
            return LogList;
        }
    }
}
