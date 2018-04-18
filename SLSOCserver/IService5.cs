using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLSOCserver
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService5" in both code and config file together.
    [ServiceContract]
    public interface IService5
    {
        [OperationContract]
        int Login(Users ud);

        [OperationContract]
        List<Timetablesc> GetComTimetables();

        [OperationContract]
        List<Timetablesc> GetBusTimetables();

        [OperationContract]
        List<Timetablesc> GetEngTimetables();

        [OperationContract]
        int AddFeedback(Feedbacksc fbd);
    }
}
