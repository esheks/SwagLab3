using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SwagLab3.PageOject
{
    public class Login
    {
        IWebDriver driver;
        public Login(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.Id, Using = "user-name")]
        public IWebElement EnterUserName { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement EnterPassword { get; set; }

        [FindsBy(How = How.Id, Using = "login-button")]
        public IWebElement LoginButton { get; set; }

       

        public Allitems ClickLoginButton()
        {
            EnterUserName.SendKeys("standard_user"); //implement data driven
            EnterPassword.SendKeys("secret_sauce");//implement data driven
            LoginButton.Click();

            // verify login link 

            string ExpectedUrl = "https://www.saucedemo.com/inventory.html";

            if (driver.Url.Contains(ExpectedUrl))
            {
                Console.WriteLine("Swag Labs open successfully");
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile
                    ("D:\\Desktop\\CHROME\\PASSSignInSwagLab.jpeg");
           
            }
            else
            {
                Console.WriteLine("Swag Labs did not open successfully");
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile
                    ("D:\\Desktop\\CHROME\\FAILEDSignInSwagLab.jpeg");


                Assert.Fail("Swag Labs did not successfully; Error Page");
            }
            
            return new Allitems(driver);
        }


    }
}
