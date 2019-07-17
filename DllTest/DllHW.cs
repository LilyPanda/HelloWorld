using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DllTest
{
    public class DllHW: Dll
    {
        private static string dbConnectionString = Properties.Settings.Default.ConnectionString;
        private SqlConnection cn = new SqlConnection(dbConnectionString);
        private SqlCommand cmd = new SqlCommand(); 

        /// <summary>
        /// this method has 2 ways to get the value
        /// 1. get value from database, if useDatabase is set to True in App.Config
        /// 2. just return hard coded Hello World, if we are not using database
        /// </summary>
        /// <returns></returns>
        public override string GetValue()
        {
            string value = string.Empty;
            bool useDb = Properties.Settings.Default.useDatabase;

            // this part of code is to get value from database, use config file to change the value of whether using database or not (it's set to False for now)
            if (useDb)
            {    
                using (SqlConnection cn = new SqlConnection(dbConnectionString))
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandText = "SELECT OrderNumber FROM [tdocs].[dbo].ORDERS WHERE OrdersID = '459AACD8-C387-4401-AFA0-000172691FBE'";
                        cn.Open();                        
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(cm);
                        DataTable dt = new DataTable();
                        dataAdapter.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            value = dt.Rows[0]["OrderNumber"].ToString().Trim();
                        }
                        cn.Close();
                    }
                }

                return value;
            }

            // for now we are not using database so just return Hello World
            else
            {
                return "Hello World";
            }
        }

        public override bool WriteValue(string value)
        {
            bool success = false;

            // broke down the code into 3 pieces for unit test
            Connect();
            int i = ExcuteCmd(value);
            Disconnect();

            if (i == 1)
            {
                success = true;
            }

            return success;
        }

        public bool Connect()
        {
            bool success = false;

            try
            {                
                cn.Open();
                success = true;
            }
            catch 
            { 
            
            }

            return success;
        }

        public bool Disconnect()
        {
            bool success = false;

            using (cn) 
            {
                cn.Close();
                success = true;
            }

            return success;
        }

        public int ExcuteCmd(string value)
        {
            int i = 0;
            cmd = cn.CreateCommand();
            try
            {
                cmd.CommandText = "INSERT INTO [TestTable] " +
                                        "(Value) " +
                                        "VALUES (@Value)";
                cmd.Parameters.AddWithValue("@Value", value);
                i = cmd.ExecuteNonQuery();
            }
            catch 
            { }
            return i;        
        }



    }
}
