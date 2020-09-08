using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Citrix.DeliveryServices.ResourcesCommon.Customization.Contract;
using System.Web.Configuration;
using System.Threading;

namespace StoreCustomization_Enumeration
{
    class SQL
    {
        public static void GetAppList(string Username, string UserGroups,string GatewayName, out List<string> AppRules, out string PermissionType)
        {
            AppRules = new List<string>();
            PermissionType = "";
            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.AppSettings["StorefrontCustomizationDB"]);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "dbo.ListAvailableApps";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sqlConnection;
            cmd.Parameters.AddWithValue("@LdapUser", SqlDbType.NVarChar).Value = Username;
            cmd.Parameters.AddWithValue("@GroupList", SqlDbType.NVarChar).Value = UserGroups;
            cmd.Parameters.AddWithValue("@GatewayName", SqlDbType.NVarChar).Value = GatewayName;

            try
            {
                #if DEBUG
                Tracer.TraceInfo("SDK_DBG - Executing stored procedure.");
                #endif
                sqlConnection.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    PermissionType = reader.GetString(1);
                    #if DEBUG
                    Tracer.TraceInfo("SDK_DBG - SQLAppResult: Permission Type:"+ PermissionType);
                    #endif
                    AppRules.Add(reader.GetString(0));
                    #if DEBUG
                    Tracer.TraceInfo("SDK_DBG - SQLAppResult:"+ reader.GetString(0));
                    #endif

                    while (reader.Read())
                    {
                        #if DEBUG
                        Tracer.TraceInfo("SDK_DBG - SQLAppResult:"+ reader.GetString(0));
                        #endif
                        AppRules.Add(reader.GetString(0));
                    }
                }
                else
                {
                    #if DEBUG
                    Tracer.TraceInfo("SDK_DBG - SQLAppResult: No results found.");
                    #endif
                }

                try
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    sqlConnection = null;
                }
                catch (Exception er)
                {
                    #if DEBUG
                    Tracer.TraceInfo("SDK_DBG_ERR - Could not close SQL Connection.:"+ er.Message);
                    #endif
                }

                try
                {
                    reader.Close();
                    reader.Dispose();
                    reader = null;
                }
                catch (Exception er)
                {
                    #if DEBUG
                    Tracer.TraceInfo("SDK_DBG_ERR - Could not close SQL Reader:"+ er.Message);
                    #endif
                }
            }
            catch (Exception e)
            {
                #if DEBUG
                Tracer.TraceInfo("SDK_DBG_ERR - Error making SQL Connection: " + e.Message);
                #endif
            }
        }

        public static void GetDuplicateRules(out List<DuplicateApprules> DuplicateAppRules)
        {
            DuplicateAppRules = new List<DuplicateApprules>();
            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.AppSettings["StorefrontCustomizationDB"]);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "select * from dbo.DuplicateAppRules";
            cmd.Connection = sqlConnection;

            try
            {
                #if DEBUG
                Tracer.TraceInfo("SDK_DBG - Executing duplicate apprules query");
                #endif

                sqlConnection.Open();
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DuplicateApprules CurrentRule = new DuplicateApprules();

                        #if DEBUG
                        Tracer.TraceInfo("SDK_DBG - SQLAppResult: "+reader.GetString(0)+" "+reader.GetString(1));
                        #endif
                        CurrentRule.AppNames = reader.GetString(0);
                        CurrentRule.WinnerApp = reader.GetString(1);
                        CurrentRule.FinalAppName = reader.GetString(2);
                        DuplicateAppRules.Add(CurrentRule);
                    }

                    try
                    {
                        sqlConnection.Close();
                        sqlConnection.Dispose();
                        sqlConnection = null;
                    }
                    catch (Exception er)
                    {
                        #if DEBUG
                        Tracer.TraceInfo("SDK_DBG_ERR - Could not close SQL Connection:"+ er.Message);
                        #endif
                    }

                }
                else
                {
                    #if DEBUG
                    Tracer.TraceInfo("SDK_DBG - SQLAppResult Rules: No results found.");
                    #endif
                }

                try
                {
                    reader.Close();
                    reader.Dispose();
                    reader = null;
                }
                catch (Exception er)
                {
                    #if DEBUG
                    Tracer.TraceInfo("SDK_DBG_ERR - Could not close SQL reader:"+ er.Message);
                    #endif
                }

            }
            catch (Exception e)
            {
                #if DEBUG
                Tracer.TraceInfo("SDK_DBG_ERR - Error making SQL Connection: " + e.Message);
                #endif
            }
        }

        public static string GetConfig(string Param)
        {
            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.AppSettings["StorefrontCustomizationDB"]);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            string MyQuery = "select Value from dbo.GlobalConfig where Parameter = '"+Param+"'";
            cmd.CommandText = MyQuery;
            cmd.Connection = sqlConnection;
            string SqlResult = "";

            try
            {
                #if DEBUG
                Tracer.TraceInfo("SDK_DBG - Executing Global parameter query for"+Param);
                #endif

                sqlConnection.Open();
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                   reader.Read();
                   #if DEBUG
                   Tracer.TraceInfo("SDK_DBG - SQLAppResult:"+ reader.GetString(0));
                   #endif
                   SqlResult = reader.GetString(0);

                    try
                    {
                        sqlConnection.Close();
                        sqlConnection.Dispose();
                        sqlConnection = null;
                    }
                    catch (Exception er)
                    {
                        #if DEBUG
                        Tracer.TraceInfo("SDK_DBG_ERR - Could not close SQL Connection:"+ er.Message);
                        #endif      
                    }
                }
                else
                {
                    #if DEBUG
                    Tracer.TraceInfo("SDK_DBG - SQLAppResult Rules: No results found.");
                    #endif
                }

                try
                {
                    reader.Close();
                    reader.Dispose();
                    reader = null;
                }
                catch (Exception er)
                {
                    #if DEBUG
                    Tracer.TraceInfo("SDK_DBG_ERR - Could not close SQL reader:"+ er.Message);
                    #endif
                }
                return SqlResult;
            }
            catch (Exception e)
            {
                #if DEBUG
                Tracer.TraceInfo("SDK_DBG_ERR - Error making SQL Connection: " + e.Message);
                #endif
                return null;
            }
        }

        private static readonly ManualResetEvent _reset = new ManualResetEvent(false);

        public static void SQLAsyncInsert()
        {
            _reset.Reset();
            try
            {
                DataTable InsertTable = new DataTable();
                InsertTable.Columns.Add("username");
                InsertTable.Columns.Add("AppName");
                InsertTable.Columns.Add("AppParam");
                InsertTable.Columns.Add("ServerName");
                InsertTable.Columns.Add("startdate");

                foreach (string line in SharedMemorySpace.LogBuffer.Get())
                {
                    InsertTable.Rows.Add(line.Split(','));
                }

                using (SqlCommand cmd = new SqlCommand("InsertLaunchData", GlobalManager.LoggerSQL))
                {
                    cmd.Parameters.AddWithValue("@Data", InsertTable);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3;
                    cmd.Connection.InfoMessage += ConnectionInfoMessage;
                    AsyncCallback result = NonQueryCallBack;
                    cmd.BeginExecuteNonQuery(result, cmd);
                    InsertTable.Clear();
                    InsertTable.Dispose();
                    InsertTable = null;
                    _reset.WaitOne();
                }
            }
            catch (SqlException ex)
            {
                #if DEBUG
                Tracer.TraceInfo("SDK_DBG_ERR - SQLWriter - Error inserting data to SQL:" + ex.Message);
                #endif
            }
        }

        private static void ConnectionInfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            if (e.Errors.Count > 0)
            {
                foreach (SqlError info in e.Errors)
                {
                    if (info.Class > 9)
                    {
                        //FlexibleMessageBox.Show("Message: " + info.Message + " : State : " + info.State);
                    }
                }
            }
        }

        private static void NonQueryCallBack(IAsyncResult result)
        {
            SqlCommand command = (SqlCommand)result.AsyncState;
            try
            {
                if (command != null)
                {
                    command.EndExecuteNonQuery(result);
                }
            }
            catch (SqlException ex)
            {
                #if DEBUG
                Tracer.TraceInfo("SDK_DBG_ERR - SQLWriter - Error executing stored procedure: "+ex.Message);
                #endif
            }
            finally
            {
                _reset.Set();
            }
        }
    }
}
