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

        [OperationContract]
        Modulesc SearchModules(string Modcode);

        [OperationContract]
        List<Modulesc> GetComModules();

        [OperationContract]
        int UpdateComModules(Modulesc cmu);

        [OperationContract]
        int DeleteComModules(Modulesc cmdel);


        [OperationContract]
        int AddLecHalls(Lechallsc lhd);

        [OperationContract]
        Lechallsc SearchLecHalls(string Lechallcode);

        [OperationContract]
        List<Lechallsc> GetComLecHalls();

        [OperationContract]
        int UpdateComlecHalls(Lechallsc clhu);

        [OperationContract]
        int DeleteComLecHalls(Lechallsc clhdel);


        [OperationContract]
        int AddLabs(Labsc lbd);

        [OperationContract]
        Labsc SearchLabs(string Labcode);

        [OperationContract]
        List<Labsc> GetComLabs();

        [OperationContract]
        int UpdateComLabs(Labsc clbu);

        [OperationContract]
        int DeleteComLabs(Labsc clbdel);


        [OperationContract]
        int AddTimetables(Timetablesc td);

        [OperationContract]
        List<Timetablesc> GetComTimetables();

        [OperationContract]
        List<Lecturersc> GetComputingLecturers();

        [OperationContract]
        List<Studentsc> GetComputingStudents();

        [OperationContract]
        Lecturersc SearchLecturers(Lecturersc ls);

        [OperationContract]
        Studentsc SearchStudents(Studentsc ss);

        [OperationContract]
        List<Feedbacksc> GetComFeedbacks();

    }
}
