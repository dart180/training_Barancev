using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllEmail, fromForm.AllEmail);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }

        [Test]
        public void TestContactDetails()
        {
            string fromDetails = app.Contacts.GetContactInformationFromDetails(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            string strFromForm = GetContactInformationFromForString(fromForm);

            Assert.AreEqual(strFromForm, fromDetails);
        }

        private string GetContactInformationFromForString(ContactData i)
        {
            return i.Firstname +" "+ i.Middlename + " " + i.Secondname + i.Nickname
                   + i.Title + i.Company + i.Address + i.HomePhone + i.MobilePhone 
                   + i.WorkPhone + i.Fax + i.Email + i.Email2 + i.Email3 + i.HomePage.Replace("http://", "") 
                   + i.Address2 + i.HomePhone2 + i.Notes;
        }
    }
}
