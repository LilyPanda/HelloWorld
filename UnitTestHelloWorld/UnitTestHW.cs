using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DllTest;
using System.Data;
using System.Data.SqlClient;


namespace UnitTestHelloWorld
{
    [TestClass]
    public class UnitTestHW
    {  
        /// <summary>
        /// this is to test:  public override string GetValue()   in DllHW.cs
        /// this test will be passed if we set: useDatabase to False   in App.config in DllTest project  (rebuild the dll after make this change)
        /// </summary>
        [TestMethod]
        public void GetValue_Return()
        {
            // Arrange
            DllHW d = new DllHW();

            // Act
            var result = d.GetValue();

            // Assert
            // if the return value is Hello World then it's passed
            Assert.AreEqual("Hello World", result);
        }

        /// <summary>
        /// this is to test:  public override bool WriteValue(string value)   in DllHW.cs
        /// 1. connect to DB
        /// 2. excute INSERT query
        /// 3. disconnect from DB        
        /// </summary>
        [TestMethod]
        public void Connect_Insert_Disconnect_FromDatabase()
        {
            DllHW d = new DllHW();

            bool connected = d.Connect();
            int i = d.ExcuteCmd(string.Empty);
            bool disconnected = d.Disconnect();            

            Assert.IsTrue(connected);            
            Assert.AreEqual("1", i.ToString());  
            Assert.IsTrue(disconnected);
        }

    }
}
