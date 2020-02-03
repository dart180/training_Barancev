using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationsTests : TestBase
    {
        [Test]
        public void ContactModificationsTest()
        {
            ContactData newData = new ContactData("Лютомир", "Романов");

            app.Contacts.Modify(1, newData);
        }
    }
}
