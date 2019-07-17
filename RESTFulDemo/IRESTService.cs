using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace RESTFulDemo
{
    #region IRESTService Interface

    // http://localhost:25118/restservice/write/somestring                local
    // http://192.168.170.19:8019/restservice/write/somestring            dev server 14  
    // https://192.168.170.19:440/restservice/write/somestring            dev server 14 with https MyCert

    [ServiceContract]
    public interface IRestSerivce
    {
        [OperationContract]
        [WebGet(UriTemplate = "/write/{value}")]
        bool WriteWriteValue(string value);
    }
    
    #endregion


    //[DataContract(Namespace = "")]    // added (Namespace = "") so when client side "post" or "put" .xml, there doesn't need to have namespace in the xml such as <Person xmlns="http://schemas.datacontract.org/2004/07/RESTFulDemo">
    //public class Person               // we automatically get the default namespce <ArrayOfPerson xmlns:i="http://www.w3.org/2001/XMLSchema-instance">
    //{
    //    [DataMember]
    //    public string ID;
    //    [DataMember]
    //    public string Name;
    //    [DataMember]
    //    public string Age;

    //}
    



    //WebGet operation is logically receiving the information from a service operation & it can be called by the REST programming model. 
    //The WebGet attribute is applied to a service operation in addition to the OperationContract and associates the operation with a 
    //UriTemplate as well as the HTTP protocol Get verb.

    //WebInvoke operation logically raises a service option & it can be called by the REST programming model. The WebInvoke attribute is 
    //applied to a service operation in addition to the OperationContract and associates the operation with a UriTemplate as well as an 
    //underlying transport verb that represents an invocation (for example, HTTP POST, PUT, or DELETE). WebInvoke has a property called 
    //Method, it allows specifying different types of HTTP methods (POST, PUT or DELETE), and by default Method is POST.

}
