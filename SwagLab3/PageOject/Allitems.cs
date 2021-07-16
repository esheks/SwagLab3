using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SwagLab3.PageOject
{
    public class Allitems
    {
        IWebDriver driver;
        public Allitems(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.LinkText, Using = "Sauce Labs Backpack")]
        public IWebElement SauceLabsBackpack { get; set; }


        [FindsBy(How = How.Name, Using = "add-to-cart-sauce-labs-backpack")]
        public IWebElement AddToCart { get; set; }

        
        [FindsBy(How = How.Id, Using = "shopping_cart_container")]
        public IWebElement CartContainer { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(@data-test,'checkout')]")]
        public IWebElement Checkout { get; set; }

        [FindsBy(How = How.Id, Using = "first-name")]
        public IWebElement FirstName { get; set; }


        [FindsBy(How = How.Id, Using = "last-name")]
        public IWebElement LastName { get; set; }

        [FindsBy(How = How.Id, Using = "postal-code")]
        public IWebElement PostalCode { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@value,'Continue')]")]
        public IWebElement Continue { get; set; }

        [FindsBy(How = How.Id, Using = "finish")]
        public IWebElement FinishShoping { get; set; }

        [FindsBy(How = How.Id, Using = "back-to-products")]
        public IWebElement BackHome { get; set; }

        public About Shop()
        {


            Thread.Sleep(5000);
            SauceLabsBackpack.Click();
            AddToCart.Click();
            
            CartContainer.Click();
            Checkout.Click();
            FirstName.SendKeys("James");//implement data driven
            LastName.SendKeys("John"); //implement data driven
            PostalCode.SendKeys("T45 6B4"); //implement data driven
            Continue.Click();
            FinishShoping.Click();
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile
                    ("D:\\Desktop\\CHROME\\CheckoutSuccessful.jpeg");

            BackHome.Click();

            return new About(driver);
        }
    }


}
