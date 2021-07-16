using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SwagLab3.PageOject;
using SwagLab3.BaseClass;

namespace SwagLab3.TestScript
{
    [TestFixture]
    public class MainTest : BaseTest
    {
        [Test]
        public void TestMethod()
        {
            var login = new Login(driver);
            var Allitems = login.ClickLoginButton();
            var About = Allitems.Shop();
            About.ClickAbout();
            Thread.Sleep(10000);


        }
    }
}
