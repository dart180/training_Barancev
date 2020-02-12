using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using WebAddressbookTests;
using Formatting = Newtonsoft.Json.Formatting;

namespace common_address_book_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataFormat = args[0];
            int count = Convert.ToInt32(args[1]);
            string filename = args[2];
            string format = args[3];
            StreamWriter writer = new StreamWriter(filename);
            List<GroupData> group = new List<GroupData>();
            List<ContactData> contact = new List<ContactData>();

            if (dataFormat == "group")
            {
                for (int i = 0; i < count; i++)
                {
                    
                    group.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(100),
                        Footer = TestBase.GenerateRandomString(100)
                    });
                }
            }
            else if (dataFormat == "contact")
            {
                for (int i = 0; i < count; i++)
                {
                    
                    contact.Add(new ContactData(TestBase.GenerateRandomString(30),
                        TestBase.GenerateRandomString(30))
                    {
                        Middlename = TestBase.GenerateRandomString(100),
                        Nickname = TestBase.GenerateRandomString(100),
                        Company = TestBase.GenerateRandomString(100),
                        Title = TestBase.GenerateRandomString(100),
                        Address = TestBase.GenerateRandomString(100),
                        HomePhone = TestBase.GenerateRandomString(20),
                        Address2 = TestBase.GenerateRandomString(100),
                    });
                }
            }
            else
            {
                System.Console.Out.Write("Unrecognized formatDate" + dataFormat);
            }

            if (format == "xml")
            {
                if (dataFormat == "group")
                {
                    writeGroupsToXmlFile(group, writer);
                }
                else
                    writeGroupsToXmlFile(contact, writer);
            }
            else if (format == "json")
            {
                if (dataFormat == "group")
                {
                    writeGroupsToJsonFile(group, writer);
                }
                else if (dataFormat == "contact")
                {
                    writeGroupsToJsonFile(contact, writer);
                }
            }
            else
            {
                System.Console.Out.Write("Unrecognized format " + format);
            }

            writer.Close();
        }
        static void writeGroupsToXmlFile(List<GroupData> group, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, group);
        }
        static void writeGroupsToXmlFile(List<ContactData> contact, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contact);
        }

        static void writeGroupsToJsonFile(List<GroupData> group, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(group, Formatting.Indented));
        }
        static void writeGroupsToJsonFile(List<ContactData> contact, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contact, Formatting.Indented));
        }
    }
}
