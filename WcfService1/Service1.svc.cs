using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;

namespace WcfService1
{   
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class Service1 : IService1
    {
        private string dbConnectionString = Properties.Settings.Default.ConnectionString;

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        /// <summary>        
        /// if we do the unit test
        /// it will be exactly same as:  public override bool WriteValue(string value)   in DllHW.cs
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool WriteValue(string value)
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
