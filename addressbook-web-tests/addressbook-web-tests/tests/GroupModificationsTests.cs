﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationsTests : TestBase
    {
        [Test]
        public void GroupModificationsTest()
        {
            GroupData newData = new GroupData("zzz");
            newData.Header = "ttt";
            newData.Footer = "qqq";

            app.Groups.Modify(1, newData);
        }
    }
}
