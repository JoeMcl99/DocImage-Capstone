using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DocImageServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IDocImageServer
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        string scrapeTest(string hstNumber, string legalName);


        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "DocImageServer.ContractType".
    [DataContract]
    public class Contractor
    {
        [DataMember]
        public string hstNumber;
        [DataMember]
        public string legalName;
    }
}
