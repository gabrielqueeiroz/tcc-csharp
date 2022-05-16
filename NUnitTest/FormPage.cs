using OpenQA.Selenium;
using NUnit.Framework;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace NUnitTest
{
    internal class FormPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public FormPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//*[@id=\"field-customerName\"]")]
        [CacheLookup]
        private IWebElement Name { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"field-contactLastName\"]")]
        [CacheLookup]
        private IWebElement Last_name { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"field-contactFirstName\"]")]
        [CacheLookup]
        private IWebElement Contact_first_name { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"field-phone\"]")]
        [CacheLookup]
        private IWebElement Phone { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"field-addressLine1\"]")]
        [CacheLookup]
        private IWebElement AddressLine1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"field-addressLine2\"]")]
        [CacheLookup]
        private IWebElement AddressLine2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"field-city\"]")]
        [CacheLookup]
        private IWebElement City { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"field-state\"]")]
        [CacheLookup]
        public IWebElement State { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"field-postalCode\"]")]
        [CacheLookup]
        private IWebElement Postal_code { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"field-country\"]")]
        [CacheLookup]
        private IWebElement Country { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"field-salesRepEmployeeNumber\"]")]
        [CacheLookup]
        private IWebElement From_employeer { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"field-creditLimit\"]")]
        [CacheLookup]
        private IWebElement Credit_limit { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"form-button-save\"]")]
        [CacheLookup]
        private IWebElement Save_button { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"report-success\"]")]
        [CacheLookup]
        private IWebElement Form_message { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"save-and-go-back-button\"]")]
        [CacheLookup]
        private IWebElement Save_and_back_buttton { get; set; }
        public void FillForm01(Dictionary<string, string> person)
        {
            Name.SendKeys(person["name"]);
            Last_name.SendKeys(person["last_name"]);
            Contact_first_name.SendKeys(person["contact_first_name"]);
            Phone.SendKeys(person["phone"]);
            AddressLine1.SendKeys(person["addressLine1"]);
            AddressLine2.SendKeys(person["addressLine2"]);
            City.SendKeys(person["city"]);
            State.SendKeys(person["state"]);
            Postal_code.SendKeys(person["postal_code"]);
            Country.SendKeys(person["country"]);
            From_employeer.SendKeys(person["from_employeer"]);
            Credit_limit.SendKeys(person["credit_limit"]);
            Save_button.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"report-success\"]")));
            Assert.AreEqual(Form_message.Text, "Your data has been successfully stored into the database. Edit Record or Go back to list");
        }

        public void FillForm02(Dictionary<string, string> person)
        {
            Name.SendKeys(person["name"]);
            Last_name.SendKeys(person["last_name"]);
            Contact_first_name.SendKeys(person["contact_first_name"]);
            Phone.SendKeys(person["phone"]);
            AddressLine1.SendKeys(person["addressLine1"]);
            AddressLine2.SendKeys(person["addressLine2"]);
            City.SendKeys(person["city"]);
            State.SendKeys(person["state"]);
            Postal_code.SendKeys(person["postal_code"]);
            Country.SendKeys(person["country"]);
            From_employeer.SendKeys(person["from_employeer"]);
            Credit_limit.SendKeys(person["credit_limit"]);
            Save_and_back_buttton.Click();
        }
    }
}
