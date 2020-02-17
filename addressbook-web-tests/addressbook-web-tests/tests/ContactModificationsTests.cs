using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationsTests : ContactTestBase
    {
        [Test]
        public void ContactModificationsTest()
        {
            ContactData newData = new ContactData("Лютомир", "Романов");

            List<ContactData> oldContacts = ContactData.GetAll();

            ContactData oldData = oldContacts[0];
            app.Contacts.Modify(oldData, newData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts[0] = newData;

            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            foreach(ContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Firstname, contact.Firstname);
                    Assert.AreEqual(newData.Secondname, contact.Secondname);
                }
            }
        }
    }
}
