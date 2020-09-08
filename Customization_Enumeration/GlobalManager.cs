using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Citrix.DeliveryServices.ResourcesCommon.Customization.Contract;
using SharedMemorySpace;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace StoreCustomization_Enumeration
{
    public sealed class GlobalManager
    {
        private static GlobalManager s_Instance;
        private static object m_Lock = new object();
        private GlobalManager() { }
        public static Timer GCCollectionTimer;
        public static SqlConnection Log;

        private static void onTimerConsoleElapsed(object sender, ElapsedEventArgs e)
        {

            //Write log to SQL.
            if (SharedMemorySpace.LogBuffer.LoggingEnabled == "true")
            {
                #if DEBUG
                Tracer.TraceInfo("SDK_DBG - SQLWriter - Collecting launch log buffer.");
                #endif
                try
                {
                    SQL.SQLAsyncInsert();
                }
                catch(Exception r)
                {
                    #if DEBUG
                    Tracer.TraceInfo("SDK_DBG_ERR - SQLWriter - Error inserting data from log to sql:" + r.Message);
                    #endif
                }

            }

            #if DEBUG
            Tracer.TraceInfo("SDK_DBG - GC Total Memory:"+ GC.GetTotalMemory(false));
            #endif         
            GC.Collect(3);

            #if DEBUG
            Tracer.TraceInfo("SDK_DBG - Finished Executing GC at " + DateTime.Now.ToString() + " Total Memory:"+GC.GetTotalMemory(false));

            #endif
        }

        public static SqlConnection LoggerSQL;

        public static GlobalManager Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    lock (m_Lock)
                    {
                        if (s_Instance == null)
                        {
                            #if DEBUG
                            Tracer.TraceInfo("SDK_DBG - Creating GC instance and SQL connection for the first time.");
                            #endif
                            s_Instance = new GlobalManager();
                            SharedMemorySpace.LogBuffer.LoggingEnabled = SQL.GetConfig("LaunchLogging");
                            if (SharedMemorySpace.LogBuffer.LoggingEnabled == "true")
                            {
                                LoggerSQL = new SqlConnection(WebConfigurationManager.AppSettings["StorefrontCustomizationDB"]);
                                LoggerSQL.Open();
                            }
                        }
                    }


                    int interval = 10;

                    try
                    {
                        interval = Convert.ToInt32(SQL.GetConfig("GlobalProcessingIntervalMin"));
                        #if DEBUG
                        Tracer.TraceInfo("SDK_DBG - GC interval set to "+interval.ToString()+" minutes.");
                        #endif
                    }
                    catch(Exception e)
                    {
                        #if DEBUG
                        Tracer.TraceInfo("SDK_DBG_ERR - GC Could not get result from SQL:"+ e.Message);
                        Tracer.TraceInfo("SDK_DBG_ERR - GC using default value of "+ interval);
                        #endif
                    }

                    GCCollectionTimer = new System.Timers.Timer();
                    GCCollectionTimer.Interval = interval * 60 * 1000;
                    GCCollectionTimer.Elapsed += onTimerConsoleElapsed;
                    GCCollectionTimer.Start();

                }

                return s_Instance;
            }
        }

    }

}


