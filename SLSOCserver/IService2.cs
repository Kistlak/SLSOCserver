using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLSOCserver
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService2" in both code and config file together.
    [ServiceContract]
    public interface IService2
    {
        [OperationContract]
        int AddModules(Modulesc md);

        //[OperationContract]
        //List<Lecturersc> GetComputingLecs();

        //[OperationContract]
        //Modulesc SearchModules(Modulesc ms);

        //[OperationContract]
        //int UpdateModules(Modulesc mu);

        //[OperationContract]
        //int DeleteModules(Modulesc mdel);


    }
}
