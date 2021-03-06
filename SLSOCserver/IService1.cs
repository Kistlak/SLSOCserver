﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLSOCserver
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        int Login(Users ud);

        [OperationContract]
        int SaveLecturers(Lecturersc ld);

        [OperationContract]
        List<Lecturersc> GetLecturersDetails();

        [OperationContract]
        Lecturersc SearchLecturers(Lecturersc ls);

        [OperationContract]
        int UpdateLecturers(Lecturersc lu);

        [OperationContract]
        int DeleteLecturers(Lecturersc ldel);


        [OperationContract]
        int SaveStudents(Studentsc sd);

        [OperationContract]
        List<Studentsc> GetStudentsDetails();

        [OperationContract]
        Studentsc SearchStudents(Studentsc ss);

        [OperationContract]
        int UpdateStudents(Studentsc su);

        [OperationContract]
        int DeleteStudents(Studentsc sdel);

        [OperationContract]
        Lecturersc SearchLecsForm(string Username);

        [OperationContract]
        Studentsc SearchStuForm(string Username);

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "SLSOCserver.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
