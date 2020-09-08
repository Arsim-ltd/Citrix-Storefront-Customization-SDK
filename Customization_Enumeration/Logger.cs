using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StoreCustomization_Enumeration
{
    public class Logger
    {
        internal static string logpath = @"C:\Temp";

        public static void DebugLine(string line)
        {
#if DEBUG
            CreateLogs();
            try{
                using (StreamWriter sw = File.AppendText(logpath+"\\sf_debug.log"))
                {
                    sw.WriteLine(System.DateTime.Now + ": " + line);
                }
            }
            catch (Exception rdx) {}
#endif
        }

        public static void DataCollectionLog(string line)
        {
            CreateLogs();
            try{
                using (StreamWriter sw = File.AppendText(logpath + "\\datacollection.log"))
                {
                    sw.WriteLine(System.DateTime.Now + ": " + line);
                }
            }
            catch (Exception rdx) {}
        }


        private static void CreateLogs()
        {
            if (!File.Exists(logpath))
            {
                using (StreamWriter sw = File.CreateText(logpath + "\\sf_debug.log"))
                {
                    sw.WriteLine(System.DateTime.Now + " Logger file created.");
                }
                using (StreamWriter sw = File.CreateText(logpath+ "\\datacollection.log"))
                {
                    sw.WriteLine(System.DateTime.Now + " Logger file created.");
                }
            }
        }
    }
}
