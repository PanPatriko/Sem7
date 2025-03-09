using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Lab4WcfService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]

    public class CovidService : ICovidService
    {
        private List<Contact> contacts = new List<Contact>();
        private Instance instance;
        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }

        //public void AddInstance(string name, string city, DateTime symptomsDate, DateTime testDate)
        //{
        //    instance = new Instance
        //    {
        //        Name = name,
        //        City = city,
        //        FirstSymptomsDate = symptomsDate,
        //        TestDate = testDate
        //    };
        //}
        public void AddInstance(Instance instance)
        {
            this.instance = instance;
        }

        public List<Contact> FinishEnteringContacts()
        {
            return contacts;
        }

        public List<Contact> GetContacts()
        {
            return contacts;
        }

        public Instance GetInstance()
        {
            return instance;
        }
    }
}
