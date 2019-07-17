using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Activation;
using System.ServiceModel;
using System.Data.SqlClient;

namespace RESTFulDemo
{
    /// <summary>
    /// Basically this code is developed for HTTP GET, PUT, POST & DELETE operation.
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class RESTSerivce : IRestSerivce
    {
        private string dbConnectionString = Properties.Settings.Default.ConnectionString;

        /// <summary>        
        /// if we do the unit test
        /// it will be exactly same as:  public override bool WriteValue(string value)   in DllHW.cs
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool WriteWriteValue(string value)
        {
            bool success = false;

            using (SqlConnection cn = new SqlConnection(dbConnectionString))
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandText = "INSERT INTO [TestTable] " +
                                            "(Value) " +
                                            "VALUES (@Value)";
                    cm.Parameters.AddWithValue("@Value", value);
                    cn.Open();
                    cm.ExecuteNonQuery();
                    cn.Close();
                    success = true;
                }
            }

            return success;
        }

    }
}