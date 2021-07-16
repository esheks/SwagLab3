using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace SwagLab3.PageOject
{
    public class About 
    {
        IWebDriver driver;
        public About(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);


        }

        [FindsBy(How = How.Id, Using = "react-burger-menu-btn")]
        public IWebElement Menu { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'about_sidebar_link')]")]
        public IWebElement AboutLink { get; set; }

        
        



        public void ClickAbout()
        {

            Thread.Sleep(5000);
            
            Menu.Click();
            
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", AboutLink);

            //verify link

            string ExpectedUrl = "https://saucelabs.com/";

            if (driver.Url.Contains(ExpectedUrl))
            {
                Console.WriteLine("Sauce Labs open successfully");
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile
                    ("D:\\Desktop\\CHROME\\SauceLabOpens.jpeg");


            }
            else
            {
                Console.WriteLine("Sauce Labs did not open successfully");
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile
                    ("D:\\Desktop\\CHROME\\SauceLabFailed.jpeg");


                Assert.Fail("Sauce Labs did not successfully; Error Page");
            }

        }
    }


}
