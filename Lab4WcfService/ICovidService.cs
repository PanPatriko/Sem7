using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Lab4WcfService
{
    [ServiceContract (SessionMode = SessionMode.Required)]
    public interface ICovidService
    {
        [OperationContract(IsInitiating = true, IsTerminating = false)]
        void AddInstance(Instance instance);

        //[OperationContract(IsInitiating = true, IsTerminating = false)]
        //void AddInstance(string name, string city, DateTime symptomsDate, DateTime testDate);

        [OperationContract(IsInitiating = false, IsTerminating = false)]
        Instance GetInstance();

        [OperationContract(IsInitiating = false, IsTerminating = false)]
        void AddContact(Contact contact);

        //[OperationContract(IsInitiating = false, IsTerminating = false)]
        //void AddContact(string name,string city, DateTime contactDate, Instance instance);

        [OperationContract(IsInitiating = false, IsTerminating = false)]
        List<Contact> GetContacts();

        [OperationContract(IsInitiating = false, IsTerminating = true)]
        List<Contact> FinishEnteringContacts();

    }

    [DataContract]
    public class Instance
    {
        string name;
        string city;
        DateTime firstSymptomsDate;
        DateTime testDate;

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        [DataMember]
        public DateTime FirstSymptomsDate
        {
            get { return firstSymptomsDate; }
            set { firstSymptomsDate = value; }
        }

        [DataMember]
        public DateTime TestDate
        {
            get { return testDate; }
            set { testDate = value; }
        }
    }

    [DataContract]
    public class Contact
    {
        string name;
        string city;
        DateTime contactDate;
        string contactWith;

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        [DataMember]
        public DateTime ContactDate
        {
            get { return contactDate; }
            set { contactDate = value; }
        }

        [DataMember]
        public string ContactWith
        {
            get { return contactWith; }
            set { contactWith = value; }
        }
    }
   
}
